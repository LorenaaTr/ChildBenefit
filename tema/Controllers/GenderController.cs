using Microsoft.AspNetCore.Mvc;
using tema.Data;
using tema.Models;

namespace tema.Controllers
{
    public class GenderController : Controller
    {
        private readonly ApplicationDbContext _db;
        public GenderController(ApplicationDbContext db)
        {
           _db = db;
        }
        public IActionResult Index()
        {
                List<Gender> objCategoryList = _db.Genders.ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
