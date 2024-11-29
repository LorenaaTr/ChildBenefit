using Microsoft.AspNetCore.Mvc;
using tema.Data;
using Tema.DataAccess.Repository.IRepository;
using Tema.Models;

namespace tema.Areas.Admin.Controllers
{
    [Area("User")]
    public class FeedbackController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public FeedbackController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Feedback> objCategoryList = _unitOfWork.Feedback.GetAll().ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Feedback obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Feedback.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Mesazhi eshte derguar me sukses";
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            return View();
        }

    }
}
