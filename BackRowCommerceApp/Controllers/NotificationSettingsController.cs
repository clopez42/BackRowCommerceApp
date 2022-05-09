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
            IEnumerable<NotificationSettings> objNotificationSettingsList = _db.NotificationSettings;
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
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            //}
            if (ModelState.IsValid)
            {
                _db.NotificationSettings.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Notifications updated successfully";

                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
