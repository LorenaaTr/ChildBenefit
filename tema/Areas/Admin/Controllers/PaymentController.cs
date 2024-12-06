using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Stripe.Checkout;
using Stripe;
using tema.Data;
using Tema.DataAccess.Repository;
using Tema.DataAccess.Repository.IRepository;
using Tema.Models;
using Tema.Models.ViewModels;
using Tema.Utility;

namespace tema.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PaymentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly StripeSettings _stripeSettings;
        public PaymentController(IUnitOfWork unitOfWork, IOptions<StripeSettings> stripeSettings)
        {
            _unitOfWork = unitOfWork;
            _stripeSettings = stripeSettings.Value;
        }
        public IActionResult Index()
        {
            List<Payment> objCategoryList = _unitOfWork.Payment.GetAll(includeProperties: "Parent").ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            PaymentVM paymentVM = new()
            {
                ParentList = _unitOfWork.Parent.GetAll().Select(p => new SelectListItem
                {
                    Text = p.PersonalNo,
                    Value = p.IdParent.ToString()
                }),
                Payment = new Payment()
            };

            return View(paymentVM);
        }
        [HttpPost]
        public IActionResult Create(PaymentVM paymentVM)
        {
            if (ModelState.IsValid)
            {
                // Retrieve the children based on the selected parent ID
                paymentVM.Children = _unitOfWork.Child.GetAll(c => c.ParentId == paymentVM.Payment.IdParent).ToList();

                // Calculate the number of children
                paymentVM.ChildCount = paymentVM.Children.Count;

                // Calculate the payment amount based on the number of children
                if (paymentVM.ChildCount == 1 || paymentVM.ChildCount == 2)
                {
                    paymentVM.CalculatedAmount = paymentVM.ChildCount * 20m;
                }
                else if (paymentVM.ChildCount >= 3)
                {
                    paymentVM.CalculatedAmount = paymentVM.ChildCount * 30m;
                }
                else
                {
                    paymentVM.CalculatedAmount = 0m; // No children, no payment
                }

                // Assign the calculated amount to the payment object
                paymentVM.Payment.Amount = paymentVM.CalculatedAmount;

                // Save the payment to the database
                _unitOfWork.Payment.Add(paymentVM.Payment);
                _unitOfWork.Save();

                TempData["success"] = "Pagesa është krijuar me sukses";
                return RedirectToAction("Index");
            }

            // Re-populate ParentList in case of validation failure
            paymentVM.ParentList = _unitOfWork.Parent.GetAll().Select(u => new SelectListItem
            {
                Text = u.PersonalNo,
                Value = u.IdParent.ToString()
            });

            return View(paymentVM);
        }

        public IActionResult ViewDetails(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            // Retrieve the payment from the database
            Payment paymentFromDb = _unitOfWork.Payment.Get(u => u.IdPayment == id);
            if (paymentFromDb == null)
            {
                return NotFound();
            }

            // Retrieve the payment history for the parent of the current payment
            var paymentHistory = _unitOfWork.Payment
                                              .GetAll(p => p.IdParent == paymentFromDb.IdParent)
                                              .OrderBy(p => p.PaymentDate) // Sort by payment date
                                              .ToList();

            // Create the ViewModel for the view
            PaymentVM paymentVM = new PaymentVM
            {
                Payment = paymentFromDb,
                ParentList = _unitOfWork.Parent.GetAll().Select(p => new SelectListItem
                {
                    Text = p.PersonalNo,
                    Value = p.IdParent.ToString()
                }),
                Children = _unitOfWork.Child.GetAll(c => c.ParentId == paymentFromDb.IdParent).ToList(),
                ChildCount = _unitOfWork.Child.GetAll(c => c.ParentId == paymentFromDb.IdParent).Count(),
                PaymentHistory = paymentHistory // Pass the payment history to the view model
            };

            return View(paymentVM);
        }


        [HttpPost]
        public IActionResult CalculatePaymentsForParentsNotInPayment()
        {
            // Merr të gjithë prindërit që nuk kanë një Pagesë të regjistruar
            var parentsWithoutPayments = _unitOfWork.Parent.GetAll()
                .Where(p => !_unitOfWork.Payment.GetAll().Any(payment => payment.IdParent == p.IdParent))
                .ToList();

            // Kontrolloni se a ka ndonjë prind që nuk ka pagesë
            if (parentsWithoutPayments.Any())
            {
                // Loop për secilin prind dhe llogarit pagesën
                foreach (var parent in parentsWithoutPayments)
                {
                    // Merr fëmijët e këtij prindi
                    var children = _unitOfWork.Child.GetAll(c => c.ParentId == parent.IdParent).ToList();

                    // Llogarit numrin e fëmijëve
                    int childCount = children.Count;

                    // Llogarit pagesën në bazë të numrit të fëmijëve
                    decimal calculatedAmount = 0m;
                    if (childCount == 1 || childCount == 2)
                    {
                        calculatedAmount = childCount * 20m;
                    }
                    else if (childCount >= 3)
                    {
                        calculatedAmount = childCount * 30m;
                    }

                    // Krijo një rekord të ri për pagesën
                    Payment payment = new Payment
                    {
                        IdParent = parent.IdParent,
                        Amount = calculatedAmount,
                        PaymentDate = DateOnly.FromDateTime(DateTime.Now) // Convert DateTime to DateOnly
                    };

                    // Ruaj pagesën në bazë
                    _unitOfWork.Payment.Add(payment);
                }

                // Ruaj ndryshimet në bazë
                _unitOfWork.Save();

                TempData["success"] = "Pagesat janë llogaritur dhe ruajtur për prindërit që nuk kishin pagesa.";
            }
            else
            {
                TempData["success"] = "Nuk ka prindër pa pagesa në sistem.";
            }

            return RedirectToAction("Index"); // Ose mund të ridrejtoni diku tjetër
        }

        // Method to create a Stripe Checkout session for each parent
        [HttpPost]
        public IActionResult CreateCheckoutSession(int parentId)
        {
            // Get the payment details for the parent
            var parentPayment = _unitOfWork.Payment.GetAll(includeProperties: "Parent")
                                                   .FirstOrDefault(p => p.Parent.IdParent == parentId);

            if (parentPayment == null)
            {
                return NotFound("Payment details not found.");
            }

            decimal amountToPay = parentPayment.Amount; // Assume the amount is stored in the Payment table
            string currency = "usd"; // You can change this to your currency

            StripeConfiguration.ApiKey = _stripeSettings.SecretKey;

            // Create a Stripe Checkout session for this parent
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            Currency = currency,
                            UnitAmount = Convert.ToInt32(amountToPay * 100), // Amount in cents
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = $"Payment for {parentPayment.Parent.Name}" // Dynamic product name based on parent
                            }
                        },
                        Quantity = 1
                    }
                },
                Mode = "payment",
                SuccessUrl = "https://localhost:7227/Stripe/Success", // URL to redirect after payment success
                CancelUrl = "https://localhost:7227/Stripe/Cancel" // URL to redirect after payment cancel
            };

            var service = new SessionService();
            var session = service.Create(options);

            // Redirect to the Stripe Checkout session
            return Redirect(session.Url);
        }


        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Payment> objPaymentList = _unitOfWork.Payment.GetAll(includeProperties: "Parent").ToList();
            return Json(new { data = objPaymentList });
        }

        
        #endregion
    }
}
