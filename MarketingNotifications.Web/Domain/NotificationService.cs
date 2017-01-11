using MarketingNotifications.Web.Domain.Twilio;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio;

namespace MarketingNotifications.Web.Domain
{
    public interface INotificationService
    {
        Task<MessageResource> SendMessageAsync(string to, string body, List<Uri> mediaUrl);
    }

    public class NotificationService : INotificationService
    {
        public NotificationService()
        {
            if (Configuration.Credentials.AccountSID != null && Configuration.Credentials.AuthToken != null)
            {
                TwilioClient.Init(Configuration.Credentials.AccountSID, Configuration.Credentials.AuthToken);
            }
        }

        public async Task<MessageResource> SendMessageAsync(string to, string body, List<Uri> mediaUrl)
        {
            return await MessageResource.CreateAsync(
                from: new PhoneNumber(Configuration.PhoneNumbers.Twilio),
                to: new PhoneNumber(to),
                body: body,
                mediaUrl: mediaUrl);
        }
    }
}
