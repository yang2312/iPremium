using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using HockeyApp.iOS;
using Newtonsoft.Json.Linq;

namespace iPremium.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            // Register for push notifications.
            var settings = UIUserNotificationSettings.GetSettingsForTypes(
                UIUserNotificationType.Alert
                | UIUserNotificationType.Badge
                | UIUserNotificationType.Sound,
                new NSSet());

            UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);
            UIApplication.SharedApplication.RegisterForRemoteNotifications();

            PrepareHockeyKey();

            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
        /// <summary>
        /// enabling hockeyKey app to collect app stats. errors, performance etc...
        /// </summary>
        void PrepareHockeyKey()
        {
            // link to app at hockeyKey
            // https://rink.hockeyapp.net/manage/apps/458150 
            // the ipremium app id from the link above
            var appID = "ad79ac054b04425db6e54a80bd42d5a6";
            var manager = BITHockeyManager.SharedHockeyManager;
            manager.Configure(appID);
            manager.StartManager();
            manager.Authenticator.AuthenticateInstallation();
        }
        public override void RegisteredForRemoteNotifications(UIApplication application,NSData deviceToken)
        {
            // Get current device token
            var DeviceToken = deviceToken.Description;
            if (!string.IsNullOrWhiteSpace(DeviceToken))
            {
                DeviceToken = DeviceToken.Trim('<').Trim('>');
            }

            // Get previous device token
            var oldDeviceToken = NSUserDefaults.StandardUserDefaults.StringForKey("PushDeviceToken");

            // Has the token changed?
            if (string.IsNullOrEmpty(oldDeviceToken) || !oldDeviceToken.Equals(DeviceToken))
            {
                //TODO: Put your own logic here to notify your server that the device token has changed/been created!
            }

            // Save new device token
            NSUserDefaults.StandardUserDefaults.SetString(DeviceToken, "PushDeviceToken");
        }
        public override void DidReceiveRemoteNotification(UIApplication application,NSDictionary userInfo, Action<UIBackgroundFetchResult> completionHandler)
        {
            NSDictionary aps = userInfo.ObjectForKey(new NSString("aps")) as NSDictionary;

            string alert = string.Empty;
            if (aps.ContainsKey(new NSString("alert")))
                alert = (aps[new NSString("alert")] as NSString).ToString();

            //show alert
            if (!string.IsNullOrEmpty(alert))
            {
                UIAlertView avAlert = new UIAlertView("Notification", alert, null, "OK", null);
                avAlert.Show();
            }
        }
    }

}
