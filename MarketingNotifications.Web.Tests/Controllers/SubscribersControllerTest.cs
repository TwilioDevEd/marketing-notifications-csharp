using System.Xml.XPath;
using MarketingNotifications.Web.Controllers;
using MarketingNotifications.Web.Models.Repository;
using MarketingNotifications.Web.Tests.Extensions;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace MarketingNotifications.Web.Tests.Controllers
{
    public class SubscribersControllerTest
    {

        [Test]
        public void RegisterRespondsWithMessage()
        {
            var mockRepository = new Mock<ISubscribersRepository>();
            mockRepository.Setup(r => r.FindByPhoneNumberAsync(It.IsAny<string>())).ReturnsAsync(null);

            var controller = new SubscribersController(mockRepository.Object);
            controller.WithCallTo(c => c.Register("555-5555", string.Empty))
                .ShouldReturnTwiMLResult(data =>
                {
                    StringAssert.Contains("Thanks", data.XPathSelectElement("Response/Message").Value);
                });
        }
    }
}
