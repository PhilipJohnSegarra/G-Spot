using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G_Spot
{
    [Activity(Label = "LogInActivity")]
    public class LogInActivity : AppCompatActivity
    {
        TextView SignUp;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.LogIn);

            SignUp = FindViewById<TextView>(Resource.Id.signInLink);

            SignUp.Click += SignUp_Click;
        }

        private void SignUp_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(SignInActivity));

            StartActivity(intent);
        }
    }
}