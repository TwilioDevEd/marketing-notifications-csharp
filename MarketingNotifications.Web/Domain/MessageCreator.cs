using System;
using System.Threading.Tasks;
using MarketingNotifications.Web.Models;
using MarketingNotifications.Web.Models.Repository;

namespace MarketingNotifications.Web.Domain
{
    public class MessageCreator
    {
        private readonly ISubscribersRepository _repository;

        public MessageCreator(ISubscribersRepository repository)
        {
            _repository = repository;
        }

        public async Task<String> Create(string phoneNumber, string message)
        {
            var subscriber = await _repository.FindByPhoneNumberAsync(phoneNumber);
            var subscriberExists = subscriber != null;
            if (!subscriberExists)
            {
                subscriber = new Subscriber
                {
                    PhoneNumber = phoneNumber,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                await _repository.CreateAsync(subscriber);
            }

            return subscriberExists
                ? await CreateOutputMessage(subscriber, message.ToLower())
                : "Thanks for contacting TWBC! Text 'subscribe' if you would to receive updates via text message.";

        }

        private async Task<string> CreateOutputMessage(Subscriber subscriber, string message)
        {
            const string subscribe = "subscribe";
            const string unsubscribe = "unsubscribe";

            if (!message.StartsWith(subscribe) && !message.StartsWith(unsubscribe))
            {
                return "Sorry, we don't recognize that command. Available commands are: 'subscribe' or 'unsubscribe'.";
            }

            var isSubscribed = message.StartsWith(subscribe);
            subscriber.Subscribed = isSubscribed;
            subscriber.UpdatedAt = DateTime.Now;
            await _repository.UpdateAsync(subscriber);

            return !isSubscribed
                ? "You have unsubscribed from notifications. Test 'subscribe' to start receieving updates again"
                : "You are now subscribed for updates.";
        }
    }
}