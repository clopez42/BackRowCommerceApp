using BackRowCommerceApp.Data;
using BackRowCommerceApp.Infrastructure;
using BackRowCommerceApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BackRowCommerceApp.Controllers
{
    public class TransactionController : Controller
    {
        private ApplicationDbContext _db;

        public TransactionController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Transaction> objTransactionList = _db.Transactions;
            return View(objTransactionList);
        }

        //GET action method
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Transaction obj)
        {
            var user = _db.UserInfo.Find(1);
            if(user == null)
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
                user = _db.UserInfo.FirstOrDefault(u => u.UserName == User.Identity.Name);
            }
            //var user = _db.UserInfo.Find(obj.AccountNum);
            var balance = user.Balance;

            if (ModelState.IsValid)
            {
                if (obj.CR_DR == Constants.TransactionType.CR)
                {
                    var newBalance = balance + obj.Amount;
                    user.Balance = newBalance;
                    _db.UserInfo.Update(user);
                }
                else if (obj.CR_DR == Constants.TransactionType.DR)
                {
                    var newBalance = balance - obj.Amount;
                    user.Balance = newBalance;
                    _db.UserInfo.Update(user);
                }
                obj.AccountNum = user.AccountNum;
                obj.Balance = user.Balance;
                //obj.Location = user.Location;
                _db.Transactions.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Transaction created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        private int AccountNumberGenerator()
        {
            Random random = new Random();
            int accountNum = random.Next(123456789, 999999999);
            return accountNum;
        }
    }
}
