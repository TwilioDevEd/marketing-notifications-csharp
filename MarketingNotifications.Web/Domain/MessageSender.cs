using MarketingNotifications.Web.Domain.Twilio;
using Twilio;

namespace MarketingNotifications.Web.Domain
{
    public interface IMessageSender
    {
        void Send(string to, string body, params string[] imageUrl);
    }

    public class MessageSender : IMessageSender
    {
        private readonly TwilioRestClient _client;

        public MessageSender() :
            this(new TwilioRestClient(
                Configuration.Credentials.AccountSID, Configuration.Credentials.AuthToken))
        {
        }

        public MessageSender(TwilioRestClient client)
        {
            _client = client;
        }


        public void Send(string to, string body, params string[] imageUrl)
        {
            _client.SendMessage(Configuration.PhoneNumbers.Twilio, to, body, imageUrl);
        }
    }
}
