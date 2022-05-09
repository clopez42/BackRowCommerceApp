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
            NotificationController n = new NotificationController(_db);
            UserController u = new UserController(_db);
            var user = _db.UserInfo.FirstOrDefault(u => u.UserName == User.Identity.Name);
            if(user == null)
            {
                //u.CreateUser(Constants.States.MO);
                user = _db.UserInfo.FirstOrDefault(u => u.UserName == User.Identity.Name);
            }
            obj.UserName = user.UserName;

            if (ModelState.IsValid)
            {
                if (obj.CR_DR == Constants.TransactionType.CR)
                {
                    var newBalance = user.Balance + obj.Amount;
                    user.Balance = newBalance;
                    _db.UserInfo.Update(user);
                }
                else if (obj.CR_DR == Constants.TransactionType.DR)
                {
                    var newBalance = user.Balance - obj.Amount;
                    user.Balance = newBalance;
                    _db.UserInfo.Update(user);
                }
                obj.AccountNum = user.AccountNum;
                obj.Balance = user.Balance;
                _db.Transactions.Add(obj);
                _db.SaveChanges();
                
                n.Create();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
