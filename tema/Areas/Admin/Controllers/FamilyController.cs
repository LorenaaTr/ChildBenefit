using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using Tema.DataAccess.Repository.IRepository;
using Tema.Models;

namespace tema.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FamilyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public FamilyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: Family/Create
        public IActionResult Create()
        {
            var familyVM = new FamilyVM
            {
                RelationList = _unitOfWork.Relation.GetAll().Select(r => new SelectListItem { Text = r.AlDescription, Value = r.Id.ToString() }),
                BankList = _unitOfWork.Bank.GetAll().Select(s => new SelectListItem { Text = s.BankName, Value = s.Id.ToString() }),
                GenderList = _unitOfWork.Gender.GetAll().Select(g => new SelectListItem { Text = g.AlDescription, Value = g.Id.ToString() }),
                MaritalStatusList = _unitOfWork.MaritalStatus.GetAll().Select(g => new SelectListItem { Text = g.AlDescription, Value = g.Id.ToString() }),
                LanguageList = _unitOfWork.Language.GetAll().Select(g => new SelectListItem { Text = g.AlDescription, Value = g.Id.ToString() }),
                NationalityList = _unitOfWork.Nationality.GetAll().Select(g => new SelectListItem { Text = g.AlDescription, Value = g.Id.ToString() }),
                RegionList = _unitOfWork.Region.GetAll().Select(g => new SelectListItem { Text = g.AlDescription, Value = g.Id.ToString() })
            };
            return View(familyVM);
        }

        // POST: Family/Create
        [HttpPost]
        public IActionResult Create(FamilyVM familyVM)
        {
            if (!ModelState.IsValid)
            {
                // Reload dropdowns and return the view if any validation errors occurred
                ReloadDropdowns(familyVM);
                return View(familyVM);
            }
            // Check if any child's PersonalNo already exists in the database
            foreach (var child in familyVM.Children)
            {
                var existingChild = _unitOfWork.Child.Get(c => c.PersonalNo == child.PersonalNo);
                if (existingChild != null)
                {
                    // If PersonalNo exists, add an error and return to the view
                    ModelState.AddModelError($"Children[{familyVM.Children.IndexOf(child)}].PersonalNo",
                    $"Femija me numer personal  {child.PersonalNo} tashme egziston e sistem");

                    ReloadDropdowns(familyVM);
                    return View(familyVM);
                }
            }


            // Save Parent
            familyVM.Parent.ApplicationDate ??= DateTime.Now;
            familyVM.Parent.CountryId = 1;  // Set default CountryId to 1
            familyVM.Parent.StatusId = 4;   // Set default StatusId to 4

            // After saving all children, count the number of children for the parent
            var childrenCount = familyVM.Children.Count();

            // Set CriteriaId based on the number of children
            if (childrenCount == 1 || childrenCount == 2)
            {
                familyVM.Parent.CriteriaId = 1;  // Set CriteriaId to 1 if 1 or 2 children
            }
            else if (childrenCount > 2)
            {
                familyVM.Parent.CriteriaId = 2;  // Set CriteriaId to 2 if more than 2 children
            }

            _unitOfWork.Parent.Add(familyVM.Parent);
            _unitOfWork.Save();

            foreach (var child in familyVM.Children)
            {
                child.ParentId = familyVM.Parent.IdParent;  // Now ParentId should be populated
                child.ApplicationDate ??= DateTime.Now;
                child.StatusId = 4;
                child.RelationId = 1;

                if (ModelState.IsValid)
                {
                    _unitOfWork.Child.Add(child);  // Add child to the repository
                }
            }
            _unitOfWork.Save();

            TempData["success"] = "Family created successfully";
            return RedirectToAction("Index");
        }

        private void ReloadDropdowns(FamilyVM familyVM)
        {
            familyVM.RelationList = _unitOfWork.Relation.GetAll().Select(r => new SelectListItem { Text = r.AlDescription, Value = r.Id.ToString() });
            familyVM.BankList = _unitOfWork.Bank.GetAll().Select(c => new SelectListItem { Text = c.BankName, Value = c.Id.ToString() });
            familyVM.GenderList = _unitOfWork.Gender.GetAll().Select(g => new SelectListItem { Text = g.AlDescription, Value = g.Id.ToString() });
            familyVM.MaritalStatusList = _unitOfWork.MaritalStatus.GetAll().Select(g => new SelectListItem { Text = g.AlDescription, Value = g.Id.ToString() });
            familyVM.LanguageList = _unitOfWork.Language.GetAll().Select(g => new SelectListItem { Text = g.AlDescription, Value = g.Id.ToString() });
            familyVM.RegionList = _unitOfWork.Region.GetAll().Select(g => new SelectListItem { Text = g.AlDescription, Value = g.Id.ToString() });
            familyVM.NationalityList = _unitOfWork.Nationality.GetAll().Select(g => new SelectListItem { Text = g.AlDescription, Value = g.Id.ToString() });
        }
    }
}
