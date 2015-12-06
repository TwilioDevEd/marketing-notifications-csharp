using MarketingNotifications.Web.Domain;
using Moq;
using NUnit.Framework;
using Twilio;

namespace MarketingNotifications.Web.Tests.Domain
{
    public class MessageSenderTest
    {
        [Test]
        public void SendMessage()
        {
            var mockClient = new Mock<TwilioRestClient>(string.Empty, string.Empty);

            var messageSender = new MessageSender(mockClient.Object);
            messageSender.Send("555-5555", "message", "message-url");

            mockClient.Verify(c => c.SendMessage(null, "555-5555", "message", new[] {"message-url"}));
        }
    }
}
