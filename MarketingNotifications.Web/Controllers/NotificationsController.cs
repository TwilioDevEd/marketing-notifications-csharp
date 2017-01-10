using System.Threading.Tasks;
using System.Web.Mvc;
using System;
using MarketingNotifications.Web.Domain;
using MarketingNotifications.Web.Models.Repository;
using MarketingNotifications.Web.ViewModels;
using System.Collections.Generic;

namespace MarketingNotifications.Web.Controllers
{
    public class NotificationsController : Controller
    {
        private readonly ISubscribersRepository _repository;
        private readonly IMessageSender _messageSender;

        public NotificationsController() : this(new SubscribersRepository(), new MessageSender())
        {
        }

        public NotificationsController(ISubscribersRepository repository, IMessageSender messageSender)
        {
            _messageSender = messageSender;
            _repository = repository;
        }

        // GET: Notifications/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Notifications/Create
        [HttpPost]
        public async Task<ActionResult> Create(NotificationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var mediaUrl = new List<Uri> { new Uri(model.ImageUrl) };
                var subscribers = await _repository.FindActiveSubscribersAsync();
                foreach (var subscriber in subscribers)
                {
                    await _messageSender.Send(
                        subscriber.PhoneNumber,
                        model.Message,
                        mediaUrl);
                }

                ModelState.Clear();
                ViewBag.FlashMessage = "Messages on their way!";
                return View();
            }

            return View(model);
        }
    }
}