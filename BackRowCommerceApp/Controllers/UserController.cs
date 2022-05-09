using BackRowCommerceApp.Data;
using BackRowCommerceApp.Infrastructure;
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
       
        public void CreateUser(Constants.States st)
        {
            UserInfo userInfo = new UserInfo
            {
                AccountNum = AccountNumberGenerator(),
                UserName = User.Identity.Name,
                Balance = 0,
                Location = st
            };
            _db.UserInfo.Add(userInfo);
            _db.SaveChanges();
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

        private int AccountNumberGenerator()
        {
            Random random = new Random();
            int accountNum = random.Next(123456789, 999999999);
            return accountNum;
        }
    }
}
