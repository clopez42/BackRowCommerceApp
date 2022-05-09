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
