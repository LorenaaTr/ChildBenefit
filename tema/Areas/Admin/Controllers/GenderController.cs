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
    public class GenderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public GenderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Gender> objCategoryList = _unitOfWork.Gender.GetAll().ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Gender obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Gender.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Gjinia eshte krijuar me sukses";
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
            Gender genderFromDb = _unitOfWork.Gender.Get(u => u.Id == id);
            if (genderFromDb == null)
            {
                return NotFound();
            }
            return View(genderFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Gender obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Gender.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Gjinia eshte perditsuar me sukses";
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
            Gender? genderFromDb = _unitOfWork.Gender.Get(u => u.Id == id);
            if (genderFromDb == null)
            {
                return NotFound();
            }
            return View(genderFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Gender? obj = _unitOfWork.Gender.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Gender.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Gjinia eshte fshire me sukses";
            return RedirectToAction("Index");

        }
    }
}
