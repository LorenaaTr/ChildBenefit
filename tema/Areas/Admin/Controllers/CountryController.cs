using Microsoft.AspNetCore.Mvc;
using tema.Data;
using Tema.DataAccess.Repository.IRepository;
using Tema.Models;

namespace tema.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CountryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CountryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Country> objCategoryList = _unitOfWork.Country.GetAll().ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Country obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Country.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Shteti eshte krijuar me sukses";
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
            Country countryFromDb = _unitOfWork.Country.Get(u => u.Id == id);
            if (countryFromDb == null)
            {
                return NotFound();
            }
            return View(countryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Country obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Country.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Shteti eshte perditsuar me sukses";
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
            Country? countryFromDb = _unitOfWork.Country.Get(u => u.Id == id);
            if (countryFromDb == null)
            {
                return NotFound();
            }
            return View(countryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Country? obj = _unitOfWork.Country.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Country.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Shteti eshte fshire me sukses";
            return RedirectToAction("Index");

        }
    }
}
