﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Firebase.Auth;
using Firebase.Firestore;
using Firebase.Firestore.Auth;
using Firebase.Firestore.Ktx;
using Firebase.Firestore.Model;
using G_Spot.DataHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G_Spot
{
    [Activity(Label = "HomeActivity")]
    public class HomeActivity : AppCompatActivity
    {
        TextView user;
        Button logout;
        FirebaseAuth auth;
        FirebaseUser User;
        FirebaseFirestore db;
        AppDataContext appDataContext = new AppDataContext();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Home);

            user = FindViewById<TextView>(Resource.Id.user);
            logout = FindViewById<Button>(Resource.Id.logoutButton);

            auth = appDataContext.GetFirebaseAuth();
            User = auth.CurrentUser;

            string email = User.Email;

            user.Text += email;

            logout.Click += Logout_Click;
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            auth.SignOut();
            StartActivity(typeof(LogInActivity));
        }
    }
}