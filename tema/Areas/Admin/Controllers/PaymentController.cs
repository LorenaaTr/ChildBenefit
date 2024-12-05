using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using tema.Data;
using Tema.DataAccess.Repository;
using Tema.DataAccess.Repository.IRepository;
using Tema.Models;
using Tema.Models.ViewModels;

namespace tema.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PaymentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public PaymentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

            // Marrja e pagesës nga databaza
            Payment paymentFromDb = _unitOfWork.Payment.Get(u => u.IdPayment == id);
            if (paymentFromDb == null)
            {
                return NotFound();
            }

            // Krijimi i modelit për View Details
            PaymentVM paymentVM = new PaymentVM
            {
                Payment = paymentFromDb,
                ParentList = _unitOfWork.Parent.GetAll().Select(p => new SelectListItem
                {
                    Text = p.PersonalNo,
                    Value = p.IdParent.ToString()
                }),
                Children = _unitOfWork.Child.GetAll(c => c.ParentId == paymentFromDb.IdParent).ToList(),
                ChildCount = _unitOfWork.Child.GetAll(c => c.ParentId == paymentFromDb.IdParent).Count()
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
