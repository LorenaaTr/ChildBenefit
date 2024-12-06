using Microsoft.AspNetCore.Mvc;
using tema.Data;
using Tema.DataAccess.Repository.IRepository;
using Tema.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Tema.Utility;

namespace tema.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
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
                obj.DateSubmitted = DateTime.Now;
                _unitOfWork.Feedback.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Mesazhi është dërguar me sukses";
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Feedback feedbackFromDb = _unitOfWork.Feedback.Get(u => u.Id == id);
            if (feedbackFromDb == null)
            {
                return NotFound();
            }
            return View(feedbackFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Feedback obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Feedback.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Mesazhi është përditësuar me sukses";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Feedback? feedbackFromDb = _unitOfWork.Feedback.Get(u => u.Id == id);
            if (feedbackFromDb == null)
            {
                return NotFound();
            }
            return View(feedbackFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Feedback? obj = _unitOfWork.Feedback.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Feedback.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Mesazhi është fshirë me sukses";
            return RedirectToAction("Index");
        }
    }
}
