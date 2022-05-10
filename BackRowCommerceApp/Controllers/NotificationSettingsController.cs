using BackRowCommerceApp.Data;
using BackRowCommerceApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackRowCommerceApp.Controllers
{
    public class NotificationSettingsController : Controller
    {
        private ApplicationDbContext _db;

        public NotificationSettingsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            NotificationSettings objNotificationSettingsList = _db.NotificationSettings.FirstOrDefault(u => u.UserName == User.Identity.Name);
            if(objNotificationSettingsList == null)
            {
                NotificationSettings notificationSettings = new NotificationSettings
                {
                    UserName = User.Identity.Name,
                    LessThan100 = false,
                    OutOfStateTransaction = false,
                    Withdrawal = false,
                    Deposit = false,
                    Overdraft = false,
                    TransactionDescription = false
                };
                _db.NotificationSettings.Add(notificationSettings);
                _db.SaveChanges();
                objNotificationSettingsList = _db.NotificationSettings.FirstOrDefault(u => u.UserName == User.Identity.Name);
            }
            return View(objNotificationSettingsList);
        }

        //GET 
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var notificationSettingsFromDb = _db.NotificationSettings.Find(id);

            if (notificationSettingsFromDb == null)
            {
                return NotFound();
            }
            return View(notificationSettingsFromDb);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(NotificationSettings obj)
        {
            obj.UserName = User.Identity.Name;
            if (ModelState.IsValid)
            {
                _db.NotificationSettings.Update(obj);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
