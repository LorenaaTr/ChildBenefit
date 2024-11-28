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
            List<Child> objChildList = _unitOfWork.Child.GetAll(includeProperties: "Status,Relation,Parent").ToList();
            return View(objChildList);
        }
        public IActionResult Create()
        {
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
                ParentList = _unitOfWork.Parent.GetAll().Select(u => new SelectListItem
                {
                    Text = u.PersonalNo,
                    Value = u.IdParent.ToString()
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
            else
            {
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
                childVM.ParentList = _unitOfWork.Parent.GetAll().Select(u => new SelectListItem
                {
                    Text = u.PersonalNo,
                    Value = u.IdParent.ToString()
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
            Child childFromDb = _unitOfWork.Child.Get(u => u.IdChild == id);
            if (childFromDb == null)
            {
                return NotFound();
            }

            ChildVM childVM = new()
            {
                Child = childFromDb,
                RelationList = _unitOfWork.Relation.GetAll().Select(u => new SelectListItem
                {
                    Text = u.AlDescription,
                    Value = u.Id.ToString(),
                    Selected = u.Id == childFromDb.RelationId // Set selected based on existing relation
                }),
                StatusList = _unitOfWork.Status.GetAll().Select(u => new SelectListItem
                {
                    Text = u.AlDescription,
                    Value = u.Id.ToString(),
                    Selected = u.Id == childFromDb.StatusId // Set selected based on existing status
                }),
                ParentList = _unitOfWork.Parent.GetAll().Select(u => new SelectListItem
                {
                    Text = u.PersonalNo,
                    Value = u.IdParent.ToString(),
                    Selected = u.IdParent == childFromDb.ParentId // Set selected based on existing status
                })
            };

            return View(childVM);
        }

        [HttpPost]
        public IActionResult Edit(ChildVM childVM)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Child.Update(childVM.Child);
                _unitOfWork.Save();
                TempData["success"] = "Femija eshte perditsuar me sukses";
                return RedirectToAction("Index");
            }

            // Repopulate lists in case of validation errors
            childVM.RelationList = _unitOfWork.Relation.GetAll().Select(u => new SelectListItem
            {
                Text = u.AlDescription,
                Value = u.Id.ToString(),
                Selected = u.Id == childVM.Child.RelationId // Maintain selection
            });

            childVM.StatusList = _unitOfWork.Status.GetAll().Select(u => new SelectListItem
            {
                Text = u.AlDescription,
                Value = u.Id.ToString(),
                Selected = u.Id == childVM.Child.StatusId // Maintain selection
            });
            childVM.ParentList = _unitOfWork.Parent.GetAll().Select(u => new SelectListItem
            {
                Text = u.PersonalNo,
                Value = u.IdParent.ToString(),
                Selected = u.IdParent == childVM.Child.ParentId // Maintain selection
            });
            return View(childVM);
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Child> objChildList = _unitOfWork.Child.GetAll(includeProperties: "Relation,Status,Parent").ToList();
            return Json(new { data = objChildList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var ChildToBeDeleted = _unitOfWork.Child.Get(u => u.IdChild == id);
            if (ChildToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.Child.Remove(ChildToBeDeleted);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Femija eshte fshire me sukses! " });
        }
        #endregion
    }
}
