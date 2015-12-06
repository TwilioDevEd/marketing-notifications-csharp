using System.Collections.Generic;
using MarketingNotifications.Web.Controllers;
using MarketingNotifications.Web.Domain;
using MarketingNotifications.Web.Models;
using MarketingNotifications.Web.Models.Repository;
using MarketingNotifications.Web.ViewModels;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace MarketingNotifications.Web.Tests.Controllers
{
    public class NotificationsControllerTest
    {
        [Test]
        public void GivenACreateAction_ThenRendersDefaultView()
        {
            var controller = new NotificationsController();

            controller.WithCallTo(c => c.Create())
                .ShouldRenderDefaultView();
        }

        [Test]
        public void GivenACreateAction_WhenModelStateIsValid_ThenRendersDefaultViewWithoutModel()
        {
            var mockMessageSender = new Mock<IMessageSender>();
            var mockRepository = new Mock<ISubscribersRepository>();
            mockRepository.Setup(r => r.FindActiveSubscribersAsync()).ReturnsAsync(
                new List<Subscriber>
                {
                    new Subscriber(),
                    new Subscriber(),
                });

            var model = new NotificationViewModel();
            var controller =
                new NotificationsController(mockRepository.Object, mockMessageSender.Object);

            controller.WithCallTo(c => c.Create(model))
                .ShouldRenderDefaultView();

            mockMessageSender.Verify(m => m.Send(
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Exactly(2));
        }

        [Test]
        public void GivenACreateAction_WhenModelStateIsInvalid_ThenRendersDefaultViewWithModel()
        {
            var model = new NotificationViewModel();
            var controller = new NotificationsController();
            controller.ModelState.AddModelError("Message", "The Message field is required");

            controller.WithCallTo(c => c.Create(model))
                .ShouldRenderDefaultView()
                .WithModel(model);
        }
    }
}
