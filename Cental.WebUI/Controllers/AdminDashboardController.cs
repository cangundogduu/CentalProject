using Cental.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminDashboardController(IDashboardService _dashboardService) : Controller
    {
        public IActionResult Index()
        {
            ViewBag.TotalUsers = _dashboardService.TGetTotalUsers();
            ViewBag.TotalCars = _dashboardService.TGetTotalCars();
            ViewBag.TotalBrands = _dashboardService.TGetTotalBrands();
            ViewBag.ReviewCount = _dashboardService.TGetReviewCount();
            ViewBag.LastAddedCars = _dashboardService.TGetLastAddedCars();
            ViewBag.LastBookings = _dashboardService.TGetLastBookings();
            ViewBag.ApprovedBookingCount = _dashboardService.TApprovedBookingCount();
            ViewBag.WaitingBookingCount = _dashboardService.TWaitingBookingCount();
            ViewBag.DeclineBookingCount = _dashboardService.TDeclineBookingCount();
            ViewBag.Messages = _dashboardService.TGetMessages();
            ViewBag.Testimonials = _dashboardService.TGetTestimonials();
            ViewBag.MessageCount = _dashboardService.TGetMessageCount();
            
            
            return View();
        }
    }
}
