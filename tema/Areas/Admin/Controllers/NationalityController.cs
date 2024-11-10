using Microsoft.AspNetCore.Mvc;
using tema.Data;
using Tema.DataAccess.Repository.IRepository;
using Tema.Models;

namespace tema.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NationalityController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public NationalityController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Nationality> objCategoryList = _unitOfWork.Nationality.GetAll().ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Nationality obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Nationality.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Nacionaliteti eshte krijuar me sukses";
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
            Nationality nationalityFromDb = _unitOfWork.Nationality.Get(u => u.Id == id);
            if (nationalityFromDb == null)
            {
                return NotFound();
            }
            return View(nationalityFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Nationality obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Nationality.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Nacionaliteti eshte perditsuar me sukses";
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
            Nationality? nationalityFromDb = _unitOfWork.Nationality.Get(u => u.Id == id);
            if (nationalityFromDb == null)
            {
                return NotFound();
            }
            return View(nationalityFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Nationality? obj = _unitOfWork.Nationality.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Nationality.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Nacionaliteti eshte fshire me sukses";
            return RedirectToAction("Index");

        }
    }
}
