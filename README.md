<a href="https://www.twilio.com">
  <img src="https://static0.twilio.com/marketing/bundles/marketing/img/logos/wordmark-red.svg" alt="Twilio" width="250" />
</a>

# SMS Notifications with Twilio and ASP.NET MVC

![](https://github.com/TwilioDevEd/marketing-notifications-csharp/workflows/NetFx/badge.svg)

With the amount of noise in social media and e-mail inboxes, it's hard to make a meaningful connection with your customers or audience. SMS text and/or MMS picture messages, however, are a personal communication channel with an open rate above 95%, which make them a great choice for social communication.

In this tutorial, you will learn how to enable your users to opt-in for an SMS marketing campaign using their mobile phone.

[Read the full tutorial here](https://www.twilio.com/docs/tutorials/walkthrough/marketing-notifications/csharp/mvc)!

## Local Development

1. First clone this repository and `cd` into it.

   ```shell
   git clone git@github.com:TwilioDevEd/marketing-notifications-csharp.git
   cd marketing-notifications-csharp
   ```

1. Rename the file `MarketingNotifications.Web/Local.config.example` to `MarketingNotifications.Web/Local.config`  and update the content.

   You can find your `TWILIO_ACCOUNT_SID` and `TWILIO_AUTH_TOKEN` in your
   [Twilio Account Settings](https://www.twilio.com/user/account/settings).
   You will also need a `TWILIO_NUMBER`, which you may find [here](https://www.twilio.com/user/account/phone-numbers/incoming).

1. Build the solution.

1. Run `Update-Database` at [Package Manager Console](https://docs.nuget.org/consume/package-manager-console) to execute the migrations.

   Be sure to ckeck SQLServer 2019 (with LocalDB support) is up and running and the server name matches the one from the connection string on `MarketingNotifications.web/Web.config`.
1. Run the application.

1. Expose application to the wider internet.
   To start using `ngrok` on our project you'll have to execute the following line in the _command prompt_

   ```shell
   ngrok http 1086 -host-header="localhost:1086"
   ```

   Keep in mind that our endpoint is:

   ```
   http://<your-ngrok-subdomain>.ngrok.io/Subscribers/Register
   ```

1. Configure your Twilio number.

  Go to your dashboard on [Twilio](https://www.twilio.com/user/account/phone-numbers/incoming). Click on Twilio Numbers and choose a number to setup.
  On the phone number page enter the address provided by ngrok into the _Messaging_ Request URL field.

1. Wrap Up!

  By now your application should be up and running at [http://localhost:1086/](http://localhost:1086/). Now your subscribers will be able to text your new Twilio number to subscribe to your Marketing Notifications service.
  
  To subscribe, just send any message to your configured Twilio phone number and it will reply with a text.

## Meta

* No warranty expressed or implied. Software is as is. Diggity.
* [MIT License](http://www.opensource.org/licenses/mit-license.html)
* Lovingly crafted by Twilio Developer Education.
