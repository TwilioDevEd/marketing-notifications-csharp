using System.ComponentModel.DataAnnotations;

namespace MarketingNotifications.Web.ViewModels
{
    public class NotificationViewModel
    {
        [Required]
        public string Message { get; set; }

        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }
    }
}