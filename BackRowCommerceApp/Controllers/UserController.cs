using BackRowCommerceApp.Data;
using BackRowCommerceApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackRowCommerceApp.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext _db;

        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public UserController()
        {

        }
        public void CreateUser(UserInfo user)
        {
            if (ModelState.IsValid)
            {
                _db.UserInfo.Add(user);
                _db.SaveChanges();
            }
        }

        public IActionResult Create(UserInfo user)
        {
            if (ModelState.IsValid)
            {
                _db.UserInfo.Add(user);
                _db.SaveChanges();
            }
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
