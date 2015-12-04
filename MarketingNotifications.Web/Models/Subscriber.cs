using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarketingNotifications.Web.Models
{
    public class Subscriber
    {
        public int Id { get; set; }
        public bool Subscribed { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}