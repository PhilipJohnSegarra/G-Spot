using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Firebase.Auth;
using G_Spot.DataHelpers;
using G_Spot.EventListeners;
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
        EditText emailEditText, passwordEditText;
        Button SignInButton;

        FirebaseAuth mAuth;
        TaskCompletionListener taskCompletionListeners = new TaskCompletionListener();
        AppDataContext appDataHelper = new AppDataContext();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.LogIn);

            SignUp = FindViewById<TextView>(Resource.Id.signInLink);
            emailEditText = FindViewById<EditText>(Resource.Id.emailEditText);
            passwordEditText =  FindViewById<EditText> (Resource.Id.passwordEditText);
            SignInButton = FindViewById<Button>(Resource.Id.SignInButton);

            mAuth = appDataHelper.GetFirebaseAuth();

            SignUp.Click += SignUp_Click;
            SignInButton.Click += SignInButton_Click;
        }

        private void SignInButton_Click(object sender, EventArgs e)
        {
            mAuth.SignInWithEmailAndPassword(emailEditText.Text, passwordEditText.Text).AddOnSuccessListener
           (taskCompletionListeners).AddOnFailureListener(taskCompletionListeners);

            taskCompletionListeners.Success += (success, args) =>
            {

                Toast.MakeText(this, "Welcome To G-Spot", ToastLength.Short).Show();
                Intent intent = new Intent(this, typeof(HomeActivity));
                StartActivity(intent);

            };

            taskCompletionListeners.Failure += (failure, args) =>
            {

                Toast.MakeText(this, "Incorrect, please try again." + args.Cause, ToastLength.Short).Show();
            };
        }

        private void SignUp_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(SignInActivity));

            StartActivity(intent);
        }
    }
}