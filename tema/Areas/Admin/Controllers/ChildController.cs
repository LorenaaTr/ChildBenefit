using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tema.DataAccess.Repository.IRepository;
using Tema.Models;
using Tema.Models.ViewModels;

namespace tema.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChildController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ChildController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Child> objChildList = _unitOfWork.Child.GetAll().ToList();
            return View(objChildList);
        }
        public IActionResult Create()
        {
            //IEnumerable<SelectListItem> StatusList = _unitOfWork.Status.GetAll().Select(u => new SelectListItem
            //{
            //    Text = u.AlDescription,
            //    Value = u.Id.ToString()
            //});
            ChildVM childVM = new()
            {
                RelationList = _unitOfWork.Relation.GetAll().Select(u => new SelectListItem
                {
                    Text = u.AlDescription,
                    Value = u.Id.ToString()
                }),
                StatusList = _unitOfWork.Status.GetAll().Select(u => new SelectListItem
                {
                    Text = u.AlDescription,
                    Value = u.Id.ToString()
                }),
                Child = new Child()
            };
            return View(childVM);
        }
        [HttpPost]
        public IActionResult Create(ChildVM childVM)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Child.Add(childVM.Child);
                _unitOfWork.Save();
                TempData["success"] = "Femija eshte krijuar me sukses";
                return RedirectToAction("Index");
            }
            else {
                childVM.RelationList = _unitOfWork.Relation.GetAll().Select(u => new SelectListItem
                {
                    Text = u.AlDescription,
                    Value = u.Id.ToString()
                });
                childVM.StatusList = _unitOfWork.Status.GetAll().Select(u => new SelectListItem
                {
                    Text = u.AlDescription,
                    Value = u.Id.ToString()
                });
                return View(childVM);
            }
          
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Child genderFromDb = _unitOfWork.Child.Get(u => u.IdChild == id);
            if (genderFromDb == null)
            {
                return NotFound();
            }
            return View(genderFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Child obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Child.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Femija eshte perditsuar me sukses";
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
            Child? genderFromDb = _unitOfWork.Child.Get(u => u.IdChild == id);
            if (genderFromDb == null)
            {
                return NotFound();
            }
            return View(genderFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Child? obj = _unitOfWork.Child.Get(u => u.IdChild == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Child.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Femija eshte fshire me sukses";
            return RedirectToAction("Index");

        }
    }
}
