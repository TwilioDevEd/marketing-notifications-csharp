using System.Web.Mvc;
using MarketingNotifications.Web.ViewModels;

namespace MarketingNotifications.Web.Controllers
{
    public class NotificationsController : Controller
    {
        // GET: Notifications
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(NotificationViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Send message
                // Sender.send();
                ModelState.Clear();
                ViewBag.FlashMessage = "Messages on their way!";
                return View();
            }

            return View(model);
        }
    }
}