using System.Web.Mvc;
using System.Web.Routing;

namespace MarketingNotifications.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",
                "{controller}/{action}/{id}",
                new { controller = "Notifications", action = "Create", id = UrlParameter.Optional }
            );
        }
    }
}
