using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;

namespace XFFCMPushNotificationsSample.Send
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("private_key.json")
            });
            // This registration token comes from the client FCM SDKs.
            var registrationToken = "dHYeVM50S96TW0lekvgHrR:APA91bGk41px1DFscqw6ve8mhGaEUIKh9pXcvBnF94gLXJVoz818NeB-zCHgNeb" +
                "feLfZlMGJimcZpuMQ_3BECRYFPo4EEH5FjeGPqb-FatkvFTK4dAuadqO4m87oTuLnu-k4t3ycsc-4";
            // See documentation on defining a message payload.
            var message = new Message()
            {
                Data = new Dictionary<string, string>()
                {
                    {"myData","1337"},
                },
                Token = registrationToken,
                //Topic = "all",
                Notification = new Notification()
                {
                    Title = "Test from code",
                    Body = "Here is your test!"
                }
            };

            //Send a message to the device corresponding to the provided registration Token.
            string response = FirebaseMessaging.DefaultInstance.SendAsync(message).Result;
            //Response is a message ID string.
            Console.WriteLine("Successfully sent message:" + response);

        }
    }
}
