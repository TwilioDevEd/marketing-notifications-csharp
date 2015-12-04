using MarketingNotifications.Web.Controllers;
using MarketingNotifications.Web.ViewModels;
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
            var model = new NotificationViewModel();
            var controller = new NotificationsController();

            controller.WithCallTo(c => c.Create(model))
                .ShouldRenderDefaultView();
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
