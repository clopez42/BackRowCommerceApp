using BackRowCommerceApp.Data;
using BackRowCommerceApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackRowCommerceApp.Controllers
{
    public class NotificationController : Controller
    {
        private ApplicationDbContext _db;

        public NotificationController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

       
    }
}
