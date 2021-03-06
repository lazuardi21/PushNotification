using Android.App;
using Android.OS;
using Android.Runtime;
using Plugin.FirebasePushNotification;
using System;

namespace XFFCMPushNotificationsSample.Droid
{
    [Application]
    public class MainApplication : Application
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transer) :
            base(handle, transer)
        {

        }

        public override void OnCreate()
        {
            base.OnCreate();

            if(Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.O)
            {
                FirebasePushNotificationManager.DefaultNotificationChannelId =
                    "FirebasePushNotificationChannel";
                FirebasePushNotificationManager.DefaultNotificationChannelName =
                    "General";
                FirebasePushNotificationManager.DefaultNotificationChannelImportance = NotificationImportance.Max;
            }

            //If debug you sholud reset the token each time
#if DEBUG
            FirebasePushNotificationManager.Initialize(this, true);
#else
        FirebasePushNotificationManager.Initialize(this,false);
#endif
            CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
            {

            };

        }


    }
    
}