using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase;
using Firebase.Auth;
using Firebase.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G_Spot.DataHelpers
{
    public class AppDataContext
    {
       public FirebaseFirestore GetFirestore()
       {
            var app = FirebaseApp.InitializeApp(Application.Context);

            FirebaseFirestore database;
            if(app == null)
            {
                var options =   new FirebaseOptions.Builder()
                    .SetProjectId("g-spot-8155d")
                    .SetApplicationId("1:710300547384:android:63ff00f20f7656a1cee9cd")
                    .SetApiKey("AIzaSyBwYl7xbLje149QNWrTgw2S6bS54BV-xhw")
                    .SetStorageBucket("g-spot-8155d.appspot.com")
                    .Build();

                app = FirebaseApp.InitializeApp(Application.Context, options);
                database = FirebaseFirestore.GetInstance(app);
            }
            else
            {
                database = FirebaseFirestore.GetInstance(app);
            }

            return database;
       }
        public FirebaseAuth GetFirebaseAuth()
        {
            var app = FirebaseApp.InitializeApp(Application.Context);
            FirebaseAuth mAuth;

            if (app == null)
            {
                var options = new FirebaseOptions.Builder()
                   .SetProjectId("g-spot-8155d")
                   .SetApplicationId("1:710300547384:android:63ff00f20f7656a1cee9cd")
                   .SetApiKey("AIzaSyBwYl7xbLje149QNWrTgw2S6bS54BV-xhw")
                   .SetStorageBucket("g-spot-8155d.appspot.com")
                   .Build();

                app = FirebaseApp.InitializeApp(Application.Context, options);
                mAuth = FirebaseAuth.Instance;

            }
            else
            {
                mAuth = FirebaseAuth.Instance;


            }
            return mAuth;
        }
    }
}