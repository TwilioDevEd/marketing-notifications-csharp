using System;
using System.ComponentModel.DataAnnotations;

namespace MarketingNotifications.Web.ViewModels
{
    public class NotificationViewModel
    {
        [Required]
        public string Message { get; set; }

        public string ImageUrl { get; set; }
    }
}