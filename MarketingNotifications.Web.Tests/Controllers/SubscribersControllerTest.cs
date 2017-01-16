using System.Xml.XPath;
using FluentMvcTesting.Extensions;
using MarketingNotifications.Web.Controllers;
using MarketingNotifications.Web.Models.Repository;
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
            var controller = new SubscribersController(mockRepository.Object);

            controller.WithCallTo(c => c.Register("555-5555", string.Empty))
                .ShouldReturnXmlResult(data =>
                {
                    StringAssert.Contains("Thanks", data.XPathSelectElement("Response/Message").Value);
                });
        }
    }
}
