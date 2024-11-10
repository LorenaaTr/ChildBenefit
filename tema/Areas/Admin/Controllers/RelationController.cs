using Microsoft.AspNetCore.Mvc;
using tema.Data;
using Tema.DataAccess.Repository.IRepository;
using Tema.Models;

namespace tema.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RelationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public RelationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Relation> objCategoryList = _unitOfWork.Relation.GetAll().ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Relation obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Relation.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Relacioni eshte krijuar me sukses";
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
            Relation relationFromDb = _unitOfWork.Relation.Get(u => u.Id == id);
            if (relationFromDb == null)
            {
                return NotFound();
            }
            return View(relationFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Relation obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Relation.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Relacioni eshte perditsuar me sukses";
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
            Relation? relationFromDb = _unitOfWork.Relation.Get(u => u.Id == id);
            if (relationFromDb == null)
            {
                return NotFound();
            }
            return View(relationFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Relation? obj = _unitOfWork.Relation.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Relation.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Relacioni eshte fshire me sukses";
            return RedirectToAction("Index");

        }
    }
}
