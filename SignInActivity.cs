using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Firebase.Auth;
using Firebase.Firestore;
using G_Spot.DataHelpers;
using G_Spot.EventListeners;
using Java.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace G_Spot
{
    [Activity(Label = "SignInActivity")]
    public class SignInActivity : AppCompatActivity
    {
        TextView SignIn;
        EditText emailEditText, usernameEditText, PassEditText, ConPassEditText;
        Button SignUp;

        FirebaseFirestore database;
        FirebaseAuth mAuth;
        TaskCompletionListener taskCompletionListeners = new TaskCompletionListener();
        AppDataContext appDataHelper = new AppDataContext();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.SignIn);

            SignIn = FindViewById<TextView>(Resource.Id.signInLink);
            emailEditText = FindViewById<EditText>(Resource.Id.emailEditText);
            usernameEditText = FindViewById<EditText>(Resource.Id.usernameEditText);
            PassEditText = FindViewById<EditText>(Resource.Id.passwordEditText);
            ConPassEditText = FindViewById<EditText>(Resource.Id.confirmpasswordEditText);
            SignUp = FindViewById<Button>(Resource.Id.SignUpButton);

            SignIn.Click += SignIn_Click;
            SignUp.Click += SignUp_Click;

            database = appDataHelper.GetFirestore();
            mAuth = FirebaseAuth.Instance;
        }

        private void SignUp_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(emailEditText.Text) ||
               string.IsNullOrEmpty(usernameEditText.Text) ||
               string.IsNullOrEmpty(PassEditText.Text) ||
               string.IsNullOrEmpty(ConPassEditText.Text))
            {
                Toast.MakeText(this, "Please Fill All Fields!", ToastLength.Short).Show();
                return;
            }

            if(PassEditText.Text.Length < 8 || PassEditText.Text.Length > 16)
            {
                Toast.MakeText(this, "Password should be 8 to 16 characters long!", ToastLength.Short).Show();
                return;
            }

            if(PassEditText.Text != ConPassEditText.Text)
            {
                Toast.MakeText(this, "Passwords should match!", ToastLength.Short).Show();
                return;
            }

            mAuth.CreateUserWithEmailAndPassword(emailEditText.Text, PassEditText.Text).AddOnSuccessListener(this,
                     taskCompletionListeners).AddOnFailureListener(this,
                   taskCompletionListeners);

            taskCompletionListeners.Success += (success, args) =>
            {
                HashMap userMap = new HashMap();
                userMap.Put("username", usernameEditText.Text);
                userMap.Put("email", emailEditText.Text);
                DocumentReference userReference = database.Collection("UserDetails").Document(mAuth.CurrentUser.Uid);
                userReference.Set(userMap);
                //progress.ProgressHide();
                Toast.MakeText(this, "Registered Successfully", ToastLength.Short).Show();
                Intent intent = new Intent(this, typeof(LogInActivity));
                StartActivity(intent);

            };
            taskCompletionListeners.Failure += (failure, args) =>
            {

                Toast.MakeText(this, "Sign Up Failed." + args.Cause, ToastLength.Short).Show();
            };
        }

        private void SignIn_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(LogInActivity));

            StartActivity(intent);
        }
    }
}