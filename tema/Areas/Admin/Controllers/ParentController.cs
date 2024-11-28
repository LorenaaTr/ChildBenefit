using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tema.DataAccess.Repository.IRepository;
using Tema.Models;
using Tema.Models.ViewModels;

namespace tema.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ParentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ParentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Parent> objParentList = _unitOfWork.Parent.GetAll(includeProperties: "Relation,Gender,Language,Country,Region,Nationality,Bank,Criteria,MaritalStatus").ToList();
            return View(objParentList);
        }
        public IActionResult Create()
        {

            ParentVM parentVM = new()
            {
                RelationList = _unitOfWork.Relation.GetAll().Select(u => new SelectListItem
                {
                    Text = u.AlDescription,
                    Value = u.Id.ToString()
                }),
                GenderList = _unitOfWork.Gender.GetAll().Select(u => new SelectListItem
                {
                    Text = u.AlDescription,
                    Value = u.Id.ToString()
                }),
                LanguageList = _unitOfWork.Language.GetAll().Select(u => new SelectListItem
                {
                    Text = u.AlDescription,
                    Value = u.Id.ToString()
                }),
                CountryList = _unitOfWork.Country.GetAll().Select(u => new SelectListItem
                {
                    Text = u.AlDescription,
                    Value = u.Id.ToString()
                }),
                RegionList = _unitOfWork.Region.GetAll().Select(u => new SelectListItem
                {
                    Text = u.AlDescription,
                    Value = u.Id.ToString()
                }),
                NationalityList = _unitOfWork.Nationality.GetAll().Select(u => new SelectListItem
                {
                    Text = u.AlDescription,
                    Value = u.Id.ToString()
                }),
                BankList = _unitOfWork.Bank.GetAll().Select(u => new SelectListItem
                {
                    Text = u.BankName,
                    Value = u.Id.ToString()
                }),
                CriteriaList = _unitOfWork.Criteria.GetAll().Select(u => new SelectListItem
                {
                    Text = u.AlDescription,
                    Value = u.Id.ToString()
                }),
                MaritalStatusList = _unitOfWork.MaritalStatus.GetAll().Select(u => new SelectListItem
                {
                    Text = u.AlDescription,
                    Value = u.Id.ToString()
                }),
                Parent = new Parent()
            };
            return View(parentVM);
        }
        [HttpPost]
        public IActionResult Create(ParentVM parentVM)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Parent.Add(parentVM.Parent);
                _unitOfWork.Save();
                TempData["success"] = "Prindi eshte krijuar me sukses";
                return RedirectToAction("Index");
            }
            else
            {
                parentVM.RelationList = _unitOfWork.Relation.GetAll().Select(u => new SelectListItem
                {
                    Text = u.AlDescription,
                    Value = u.Id.ToString()
                });
                parentVM.GenderList = _unitOfWork.Gender.GetAll().Select(u => new SelectListItem
                {
                    Text = u.AlDescription,
                    Value = u.Id.ToString()
                });
                parentVM.LanguageList = _unitOfWork.Language.GetAll().Select(u => new SelectListItem
                {
                    Text = u.AlDescription,
                    Value = u.Id.ToString()
                });
                parentVM.CountryList = _unitOfWork.Country.GetAll().Select(u => new SelectListItem
                {
                    Text = u.AlDescription,
                    Value = u.Id.ToString()
                });
                parentVM.RegionList = _unitOfWork.Region.GetAll().Select(u => new SelectListItem
                {
                    Text = u.AlDescription,
                    Value = u.Id.ToString()
                });
                parentVM.NationalityList = _unitOfWork.Nationality.GetAll().Select(u => new SelectListItem
                {
                    Text = u.AlDescription,
                    Value = u.Id.ToString()
                });
                parentVM.BankList = _unitOfWork.Bank.GetAll().Select(u => new SelectListItem
                {
                    Text = u.BankName,
                    Value = u.Id.ToString()
                });
                parentVM.CriteriaList = _unitOfWork.Criteria.GetAll().Select(u => new SelectListItem
                {
                    Text = u.AlDescription,
                    Value = u.Id.ToString()
                });
                parentVM.MaritalStatusList = _unitOfWork.MaritalStatus.GetAll().Select(u => new SelectListItem
                {
                    Text = u.AlDescription,
                    Value = u.Id.ToString()
                });
                return View(parentVM);
            }

        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Parent parentFromDb = _unitOfWork.Parent.Get(u => u.IdParent == id);
            if (parentFromDb == null)
            {
                return NotFound();
            }
            return View(parentFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Parent obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Parent.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Prindi eshte perditsuar me sukses";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult ViewDetails(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            // Fetch parent including related properties for a detailed view
            Parent parentFromDb = _unitOfWork.Parent.GetFirstOrDefault(
                p => p.IdParent == id,
                includeProperties: "Relation,Gender,Language,Country,Region,Nationality,Bank,Criteria,MaritalStatus"
            );

            if (parentFromDb == null)
            {
                return NotFound();
            }

            // Create an instance of ParentVM and populate it with the parent data
            var parentVM = new ParentVM
            {
                Parent = parentFromDb,
                // The data is already included in the parent object, so you can directly pass it to the view
                RelationList = parentFromDb.Relation != null ? new List<SelectListItem> { new SelectListItem { Text = parentFromDb.Relation.AlDescription, Value = parentFromDb.Relation.Id.ToString() } } : new List<SelectListItem>(),
                GenderList = parentFromDb.Gender != null ? new List<SelectListItem> { new SelectListItem { Text = parentFromDb.Gender.AlDescription, Value = parentFromDb.Gender.Id.ToString() } } : new List<SelectListItem>(),
                LanguageList = parentFromDb.Language != null ? new List<SelectListItem> { new SelectListItem { Text = parentFromDb.Language.AlDescription, Value = parentFromDb.Language.Id.ToString() } } : new List<SelectListItem>(),
                CountryList = parentFromDb.Country != null ? new List<SelectListItem> { new SelectListItem { Text = parentFromDb.Country.AlDescription, Value = parentFromDb.Country.Id.ToString() } } : new List<SelectListItem>(),
                RegionList = parentFromDb.Region != null ? new List<SelectListItem> { new SelectListItem { Text = parentFromDb.Region.AlDescription, Value = parentFromDb.Region.Id.ToString() } } : new List<SelectListItem>(),
                BankList = parentFromDb.Bank != null ? new List<SelectListItem> { new SelectListItem { Text = parentFromDb.Bank.BankName, Value = parentFromDb.Bank.Id.ToString() } } : new List<SelectListItem>(),
                CriteriaList = parentFromDb.Criteria != null ? new List<SelectListItem> { new SelectListItem { Text = parentFromDb.Criteria.AlDescription, Value = parentFromDb.Criteria.Id.ToString() } } : new List<SelectListItem>(),
                MaritalStatusList = parentFromDb.MaritalStatus != null ? new List<SelectListItem> { new SelectListItem { Text = parentFromDb.MaritalStatus.AlDescription, Value = parentFromDb.MaritalStatus.Id.ToString() } } : new List<SelectListItem>(),
                NationalityList = parentFromDb.Nationality != null ? new List<SelectListItem> { new SelectListItem { Text = parentFromDb.Nationality.AlDescription, Value = parentFromDb.Nationality.Id.ToString() } } : new List<SelectListItem>(),
            };

            // Pass the ParentVM to the view
            return View(parentVM);
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Parent> objParentList = _unitOfWork.Parent.GetAll(includeProperties: "Gender").ToList();
            return Json(new { data = objParentList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var ParentToBeDeleted = _unitOfWork.Parent.Get(u => u.IdParent == id);
            if (ParentToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.Parent.Remove(ParentToBeDeleted);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Prindi eshte fshire me sukses! " });
        }
        #endregion

    }
}
