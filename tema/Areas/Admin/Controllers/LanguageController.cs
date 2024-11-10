using Microsoft.AspNetCore.Mvc;
using tema.Data;
using Tema.DataAccess.Repository.IRepository;
using Tema.Models;

namespace tema.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LanguageController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public LanguageController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Language> objCategoryList = _unitOfWork.Language.GetAll().ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Language obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Language.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Gjuha eshte krijuar me sukses";
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
            Language languageFromDb = _unitOfWork.Language.Get(u => u.Id == id);
            if (languageFromDb == null)
            {
                return NotFound();
            }
            return View(languageFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Language obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Language.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Gjuha eshte perditsuar me sukses";
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
            Language? languageFromDb = _unitOfWork.Language.Get(u => u.Id == id);
            if (languageFromDb == null)
            {
                return NotFound();
            }
            return View(languageFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Language? obj = _unitOfWork.Language.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Language.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Gjuha eshte fshire me sukses";
            return RedirectToAction("Index");

        }
    }
}
