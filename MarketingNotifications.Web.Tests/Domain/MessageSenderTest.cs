using MarketingNotifications.Web.Domain;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Twilio;
using Twilio.Http;
using Twilio.Clients;

namespace MarketingNotifications.Web.Tests.Domain
{
    public class MessageSenderTest
    {
        [Test]
        public void SendMessage()
        {
            var twilioClientMock = new Mock<ITwilioRestClient>();
            twilioClientMock.Setup(c => c.AccountSid).Returns("AccountSID");
            twilioClientMock.Setup(c => c.Request(It.IsAny<Request>()))
                .Returns(new Response(System.Net.HttpStatusCode.Created, ""));

            TwilioClient.SetRestClient(twilioClientMock.Object);

            var messageSender = new MessageSender();
            var messageUrl = new List<Uri> { new Uri("http://example.com") };
            messageSender.Send("555-5555", "message", messageUrl);

            twilioClientMock.Verify(
                c => c.Request(It.IsAny<Request>()), Times.Exactly(1));
        }
    }
}
