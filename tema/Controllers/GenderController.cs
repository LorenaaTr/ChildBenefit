using Microsoft.AspNetCore.Mvc;
using tema.Data;
using Tema.DataAccess.Repository.IRepository;
using Tema.Models;

namespace tema.Controllers
{
    public class GenderController : Controller
    {
        private readonly IGenderRepository _genderRepo;
        public GenderController(IGenderRepository db)
        {
           _genderRepo = db;
        }
        public IActionResult Index()
        {
                List<Gender> objCategoryList = _genderRepo.GetAll().ToList();
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
                _genderRepo.Add(obj);
                _genderRepo.Save();
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
            Gender genderFromDb = _genderRepo.Get(u=>u.Id == id);
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
                _genderRepo.Update(obj);
                _genderRepo.Save();
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
            Gender? genderFromDb = _genderRepo.Get(u => u.Id == id);
            if (genderFromDb == null)
            {
                return NotFound();
            }
            return View(genderFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Gender? obj = _genderRepo.Get(u=>u.Id==id);
            if (obj == null)
            {
                return NotFound();
            }

            _genderRepo.Remove(obj);
            _genderRepo.Save();
            TempData["success"] = "Gjinia eshte fshire me sukses";
            return RedirectToAction("Index");
          
        }
    }
}
