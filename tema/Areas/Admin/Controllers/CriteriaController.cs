using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tema.Data;
using Tema.DataAccess.Repository.IRepository;
using Tema.Models;
using Tema.Utility;

namespace tema.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CriteriaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CriteriaController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Criteria> objCategoryList = _unitOfWork.Criteria.GetAll().ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Criteria obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Criteria.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Kriteri eshte krijuar me sukses";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Criteria criteriaFromDb = _unitOfWork.Criteria.Get(u => u.Id == id);
            if (criteriaFromDb == null)
            {
                return NotFound();
            }
            return View(criteriaFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Criteria obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Criteria.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Kriteri eshte perditsuar me sukses";
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
            Criteria? criteriaFromDb = _unitOfWork.Criteria.Get(u => u.Id == id);
            if (criteriaFromDb == null)
            {
                return NotFound();
            }
            return View(criteriaFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Criteria? obj = _unitOfWork.Criteria.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Criteria.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Kriteri eshte fshire me sukses";
            return RedirectToAction("Index");

        }
    }
}
