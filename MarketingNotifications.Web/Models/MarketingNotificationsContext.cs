namespace MarketingNotifications.Web.Models
{
    public class MarketingNotificationsContext : DbContext
    {
        public MarketingNotificationsContext()
            : base("MarketingNotificaitonsConnection") { }

        public DbSet<Subscriber> Subscribers { get; set; }
    }
}