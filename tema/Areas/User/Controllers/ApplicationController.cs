//using Microsoft.AspNetCore.Mvc;
//using System.Linq;
//using System.Threading.Tasks;
//using Tema.Models;
//using Tema.Models.ViewModels;

//using Microsoft.AspNetCore.Mvc.Rendering;
//using Tema.DataAccess.Repository.IRepository;

//namespace Tema.Areas.User.Controllers
//{
//    [Area("User")]
//    public class ApplicationController : Controller
//    {
//        private readonly IUnitOfWork _unitOfWork;

//        public ApplicationController(IUnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//        }
//        public IActionResult Create()
//        {
//            // Create a new instance of the FamilyVM ViewModel
//            FamilyVM familyVM = new FamilyVM
//            {
//                Parent = new ParentVM(),
//                Child = new ChildVM()
//            };

//            // Populate necessary dropdowns for Parent and Child data
//            // (This can be customized for your case, e.g., selecting country, gender, etc.)
//            familyVM.Parent.GenderList = _unitOfWork.Gender.GetAll().Select(u => new SelectListItem
//            {
//                Text = u.AlDescription,
//                Value = u.Id.ToString()
//            });

//            return View(familyVM);
//        }
//        [HttpPost]
//        public IActionResult Create(FamilyVM familyVM)
//        {
//            if (ModelState.IsValid)
//            {
//                // Save the Parent data
//                Parent parent = new Parent
//                {
//                    Name = familyVM.Parent.Parent.Name,
//                    Surname = familyVM.Parent.Parent.Surname,
//                    MaidenName = familyVM.Parent.Parent.MaidenName,
//                    PersonalNo = familyVM.Parent.Parent.PersonalNo,
//                    Address = familyVM.Parent.Parent.Address,
//                    MaritalStatus = familyVM.Parent.MaritalStatusList
//                };

//                Child child = new Child
//                {
//                    Name = familyVM.Child.Child.Name,
//                    DateOfBirth = familyVM.Child.Child.DateOfBirth,
//                    PersonalNo = familyVM.Child.Child.PersonalNo,
//                };

//                // Save Parent and Child to the database
//                _unitOfWork.Parent.Add(parent);
//                _unitOfWork.Child.Add(child);

//                // Save changes to the database
//                _unitOfWork.Save();

//                TempData["success"] = "Application submitted successfully!";
//                return RedirectToAction("Index");
//            }

//            // If the model is not valid, return the view with validation errors
//            return View(familyVM);
//        }


//    }
//}
