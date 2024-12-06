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
using tema.Services;

namespace tema.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PaymentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly StripeSettings _stripeSettings;
        private readonly IEmailSender _emailSender;
        public PaymentController(IUnitOfWork unitOfWork, IOptions<StripeSettings> stripeSettings, IEmailSender emailSender)
        {
            _unitOfWork = unitOfWork;
            _stripeSettings = stripeSettings.Value;
            _emailSender = emailSender;
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
        public IActionResult CalculatePaymentsForAllActiveParents()
        {
            // Step 1: Get the current month and year
            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;

            // Step 2: Check if payments have already been calculated for the current month
            var existingPaymentsForCurrentMonth = _unitOfWork.Payment.GetAll(p =>
                p.PaymentDate.Year == currentYear && p.PaymentDate.Month == currentMonth).ToList();

            // Step 3: If payments already exist for the current month, prevent further calculations
            if (existingPaymentsForCurrentMonth.Any())
            {
                TempData["success"] = "Pagesat për këtë muaj janë llogaritur tashmë.";
                return RedirectToAction("Index"); // Or redirect to another page as necessary
            }

            // Step 4: Retrieve all active parents (StatusId = 1)
            var activeParents = _unitOfWork.Parent.GetAll(p => p.StatusId == 1).ToList();

            // Step 5: Iterate through each active parent and calculate payments
            foreach (var parent in activeParents)
            {
                // Step 6: Retrieve the children for this parent
                var children = _unitOfWork.Child.GetAll(c => c.ParentId == parent.IdParent).ToList();

                // Step 7: Calculate the number of children
                int childCount = children.Count;

                // Step 8: Calculate the payment amount based on the number of children
                decimal calculatedAmount = 0m;
                if (childCount == 1 || childCount == 2)
                {
                    calculatedAmount = childCount * 20m;
                }
                else if (childCount >= 3)
                {
                    calculatedAmount = childCount * 30m;
                }

                // Step 9: Create a new payment record for this parent
                Payment payment = new Payment
                {
                    IdParent = parent.IdParent,
                    Amount = calculatedAmount,
                    PaymentDate = new DateOnly(currentYear, currentMonth, DateTime.Now.Day) // Set the payment date to the current month and day
                };

                // Step 10: Save the payment to the database
                _unitOfWork.Payment.Add(payment);
            }

            // Step 11: Save all changes to the database
            _unitOfWork.Save();

            // Step 12: Provide feedback to the user
            TempData["success"] = "Pagesat janë llogaritur dhe ruajtur për prindërit aktivë për këtë muaj.";
            return RedirectToAction("Index"); // Or redirect to another page as necessary
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

        [HttpPost]
        public IActionResult SendPaymentNotificationToActiveParents()
        {
            // Get all parents whose StatusId is "active"
            var activeParents = _unitOfWork.Parent.GetAll(p => p.StatusId == 1).ToList();

            // Check if there are any active parents
            if (!activeParents.Any())
            {
                TempData["error"] = "No active parents found in the system.";
                return RedirectToAction("Index"); // or another appropriate action
            }

            foreach (var parent in activeParents)
            {
                // Send email to each active parent
                var emailSubject = "Mbeshtetja e Shtesave te Femijeve Nga Qeveria e Kosoves";
                var emailBody = $"I/E nderuar {parent.Name},<br><br>" +
                   "Mbeshtetja e Shtesave te Femijeve Nga Qeveria e Kosoves tashme eshte procesuar me sukses. Per me shume detaje kontrollo llogarine bankare.<br><br>" +
                   "Faleminderit!";
    
                // Use IEmailSender service to send the email
                _emailSender.SendEmailAsync(parent.Email, emailSubject, emailBody).Wait();
            }

            TempData["success"] = "Emails have been sent to all active parents.";
            return RedirectToAction("Index"); // or another appropriate action
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
