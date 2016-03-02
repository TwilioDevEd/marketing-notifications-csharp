using System.Threading.Tasks;
using MarketingNotifications.Web.Domain;
using MarketingNotifications.Web.Models;
using MarketingNotifications.Web.Models.Repository;
using Moq;
using NUnit.Framework;

namespace MarketingNotifications.Web.Tests.Domain
{
    class MessageCreatorTest
    {
        [Test]
        public async Task WhenSubscriberDoesNotExist_ThenResponseContainsThanksMessage()
        {
            var mockRepository = new Mock<ISubscribersRepository>();
            mockRepository.Setup(r => r.FindByPhoneNumberAsync(It.IsAny<string>())).ReturnsAsync(null);

            var messageCreator = new MessageCreator(mockRepository.Object);
            var message = await messageCreator.Create("555-5555", "");

            StringAssert.Contains("Thanks", message);
            mockRepository.Verify(r => r.CreateAsync(It.IsAny<Subscriber>()), Times.Once);
        }

        [Test]
        public async Task WhenSubscriberExistAndMessageIsSubscribe_ThenResponseContainsSubscribedMessage()
        {
            var mockRepository = new Mock<ISubscribersRepository>();
            mockRepository.Setup(r => r.FindByPhoneNumberAsync(It.IsAny<string>()))
                .ReturnsAsync(new Subscriber { PhoneNumber = "555-5555" });

            var messageCreator = new MessageCreator(mockRepository.Object);
            var message = await messageCreator.Create("555-5555", "add");

            StringAssert.Contains("subscribed", message);
            mockRepository.Verify(r => r.UpdateAsync(It.IsAny<Subscriber>()), Times.Once);
        }

        [Test]
        public async Task WhenSubscriberExistAndMessageIsUnsubscribe_ThenResponseContainsUnsubscribedMessage()
        {
            var mockRepository = new Mock<ISubscribersRepository>();
            mockRepository.Setup(r => r.FindByPhoneNumberAsync(It.IsAny<string>()))
                .ReturnsAsync(new Subscriber { PhoneNumber = "555-5555" });

            var messageCreator = new MessageCreator(mockRepository.Object);
            var message = await messageCreator.Create("555-5555", "remove");

            StringAssert.Contains("unsubscribed", message);
            mockRepository.Verify(r => r.UpdateAsync(It.IsAny<Subscriber>()), Times.Once);
        }

        [Test]
        public async Task WhenSubscriberExistAndMessageIsNotAllowed_ThenResponseContainsSorryMessage()
        {
            var mockRepository = new Mock<ISubscribersRepository>();
            mockRepository.Setup(r => r.FindByPhoneNumberAsync(It.IsAny<string>()))
                .ReturnsAsync(new Subscriber { PhoneNumber = "555-5555" });

            var messageCreator = new MessageCreator(mockRepository.Object);
            var message = await messageCreator.Create("555-5555", "create");

            StringAssert.Contains("Sorry", message);
        }
    }
}
