using Microsoft.AspNetCore.Mvc;

namespace tema.Controllers
{
    public class GenderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
