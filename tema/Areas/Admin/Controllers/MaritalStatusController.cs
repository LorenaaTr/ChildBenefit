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
    public class MaritalStatusController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public MaritalStatusController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<MaritalStatus> objCategoryList = _unitOfWork.MaritalStatus.GetAll().ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(MaritalStatus obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.MaritalStatus.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Statusi Martesor eshte krijuar me sukses";
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
            MaritalStatus maritalstatusFromDb = _unitOfWork.MaritalStatus.Get(u => u.Id == id);
            if (maritalstatusFromDb == null)
            {
                return NotFound();
            }
            return View(maritalstatusFromDb);
        }
        [HttpPost]
        public IActionResult Edit(MaritalStatus obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.MaritalStatus.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Statusi Martesor eshte perditsuar me sukses";
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
            MaritalStatus? maritalstatusFromDb = _unitOfWork.MaritalStatus.Get(u => u.Id == id);
            if (maritalstatusFromDb == null)
            {
                return NotFound();
            }
            return View(maritalstatusFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            MaritalStatus? obj = _unitOfWork.MaritalStatus.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.MaritalStatus.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Statusi Martesor eshte fshire me sukses";
            return RedirectToAction("Index");

        }
    }
}
