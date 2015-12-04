using System.Data.Entity;
using MarketingNotifications.Web.Models;

namespace MarketingNotifications.Web
{
    public class MarketingNotificationsContext : DbContext
    {
        public MarketingNotificationsContext()
            : base("MarketingNotificaitonsConnection") { }

        public DbSet<Subscriber> Subscribers { get; set; }
    }
}