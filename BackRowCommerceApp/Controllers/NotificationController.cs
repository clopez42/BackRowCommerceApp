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
            IEnumerable<Notification> objNotificationList = _db.Notifications;
            return View(objNotificationList);
        }

        public void GenerateNotification(Transaction obj)
        {
            string message = "Transaction: ";
            /*var notificationSettingsFromDb = _db.NotificationSettings.FirstOrDefault(u => u.UserName == User.Identity.Name);
            var userInfoFromDb = _db.UserInfo.FirstOrDefault(u => u.UserName == User.Identity.Name);
            if (notificationSettingsFromDb != null)
            {
                if(notificationSettingsFromDb.TransactionDate == true)
                {
                    string tDate = obj.ProcessDate.ToString();
                    message += tDate;
                }
                if(notificationSettingsFromDb.TransactionTime == true)
                {
                    string tTime = obj.ProcessDate.ToString();
                    message += tTime;
                }
                if(notificationSettingsFromDb.OutOfStateTransaction == true)
                {
                    string oost = obj.Location.ToString();
                    message += oost;
                }
                if(notificationSettingsFromDb.Withdrawal == true)
                {
                    string w = "Withdrawal of $" + obj.Amount.ToString();
                    message += w;
                }
                if(notificationSettingsFromDb.Deposit == true)
                {
                    string d = "Deposit of $" + obj.Amount.ToString(); 
                    message += d;
                }
                if((notificationSettingsFromDb.Overdraft == true) && (userInfoFromDb.Balance < 0))
                {
                    string o = "Your account has overdrafted";
                    message += o;
                }
                if(notificationSettingsFromDb.TransactionDescription == true)
                {
                    string description = obj.Description;
                    message += description;
                }
                if((notificationSettingsFromDb.TransactionDate == true) || (notificationSettingsFromDb.TransactionTime == true)
                    || (notificationSettingsFromDb.OutOfStateTransaction == true) || (notificationSettingsFromDb.Withdrawal == true)
                    || (notificationSettingsFromDb.Deposit == true) || (notificationSettingsFromDb.Overdraft == true)
                    || (notificationSettingsFromDb.TransactionDescription == true))
                {
                    Notification notification = new Notification
                    {
                        UserName = User.Identity.Name,
                        Message = message,
                    };
                    _db.Notifications.Add(notification);
                    _db.SaveChanges();
                }
            }*/
        }

        //GET 
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var notificationFromDb = _db.Notifications.Find(id);

            if (notificationFromDb == null)
            {
                return NotFound();
            }
            return View(notificationFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Notifications.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Notifications.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
