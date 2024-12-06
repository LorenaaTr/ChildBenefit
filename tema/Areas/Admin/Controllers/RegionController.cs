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
    public class RegionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public RegionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Region> objCategoryList = _unitOfWork.Region.GetAll().ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Region obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Region.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Regjioni eshte krijuar me sukses";
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
            Region regionFromDb = _unitOfWork.Region.Get(u => u.Id == id);
            if (regionFromDb == null)
            {
                return NotFound();
            }
            return View(regionFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Region obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Region.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Regjioni eshte perditsuar me sukses";
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
            Region? regionFromDb = _unitOfWork.Region.Get(u => u.Id == id);
            if (regionFromDb == null)
            {
                return NotFound();
            }
            return View(regionFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Region? obj = _unitOfWork.Region.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Region.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Regjioni eshte fshire me sukses";
            return RedirectToAction("Index");

        }
    }
}
