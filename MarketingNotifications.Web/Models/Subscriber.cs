using System;

namespace MarketingNotifications.Web.Models
{
    public class Subscriber
    {
        public int Id { get; set; }
        public String PhoneNumber { get; set; }
        public bool Subscribed { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
