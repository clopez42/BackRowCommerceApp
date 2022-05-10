using BackRowCommerceApp.Data;
using BackRowCommerceApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BackRowCommerceApp.Infrastructure;


namespace BackRowCommerceApp.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated 
                && (_db.UserInfo.FirstOrDefault(u => u.UserName == User.Identity.Name) == null))
            {
                UserInfo userInfo = new UserInfo
                {
                    AccountNum = AccountNumberGenerator(),
                    UserName = User.Identity.Name,
                    Balance = 0,
                    Location = Constants.States.MO
                };
                _db.UserInfo.Add(userInfo);
                _db.SaveChanges();
            }
            UserInfo currentUser = new UserInfo();
            IEnumerable<UserInfo> userlist = _db.UserInfo;
            foreach(var u in userlist)
            {
                if(u.UserName == User.Identity.Name)
                {
                    currentUser.AccountNum = u.AccountNum;
                    currentUser.UserName = u.UserName;
                    currentUser.Balance = u.Balance;
                }
            }
            return View(currentUser);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private int AccountNumberGenerator()
        {
            Random random = new Random();
            int accountNum = random.Next(123456789, 999999999);
            return accountNum;
        }
    }
}