using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using MarketingNotifications.Web.Domain;
using MarketingNotifications.Web.Models.Repository;
using Twilio.TwiML;
using Twilio.TwiML.Mvc;

namespace MarketingNotifications.Web.Controllers
{
    public class SubscribersController : TwilioController
    {
        private readonly ISubscribersRepository _repository;

        public SubscribersController() : this(new SubscribersRepository()) { }

        public SubscribersController(ISubscribersRepository repository)
        {
            _repository = repository;
        }

        // POST: Subscribers/Register
        [HttpPost]
        public async Task<ActionResult> Register(string from, String body)
        {
            var phoneNumber = from;
            var message = body;

            var messageCreator = new MessageCreator(_repository);
            var outputMessage = await messageCreator.Create(phoneNumber, message);

            var response = new TwilioResponse();
            response.Message(outputMessage);

            return TwiML(response);
        }
    }
}
