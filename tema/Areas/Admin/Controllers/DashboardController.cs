using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tema.Data;
using Tema.DataAccess.Repository.IRepository;
using Tema.Models.ViewModels;
using Tema.Utility;

namespace tema.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class DashboardController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public DashboardController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            // Create a view model to hold the dashboard data
            var model = new DashboardVM
            {
                TotalUsers = _unitOfWork.ApplicationUser.GetAll().Count(),
                TotalChildren = _unitOfWork.Child.GetAll().Count(),
                TotalParents = _unitOfWork.Parent.GetAll().Count(),
                FeedbackList = _unitOfWork.Feedback.GetAll().ToList() // Retrieve the feedback data
            };

            return View(model);
        }
    }
}
