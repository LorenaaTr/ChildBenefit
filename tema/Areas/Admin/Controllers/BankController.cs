using Microsoft.AspNetCore.Mvc;
using Tema.DataAccess.Repository.IRepository;
using Tema.Models;

namespace tema.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BankController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public BankController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Bank> objCategoryList = _unitOfWork.Bank.GetAll().ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Bank obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Bank.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Banka eshte krijuar me sukses";
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
            Bank bankFromDb = _unitOfWork.Bank.Get(u => u.Id == id);
            if (bankFromDb == null)
            {
                return NotFound();
            }
            return View(bankFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Bank obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Bank.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Banka eshte perditsuar me sukses";
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
            Bank? bankFromDb = _unitOfWork.Bank.Get(u => u.Id == id);
            if (bankFromDb == null)
            {
                return NotFound();
            }
            return View(bankFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Bank? obj = _unitOfWork.Bank.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Bank.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Banka eshte fshire me sukses";
            return RedirectToAction("Index");

        }
    }
}
