using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text.Format;
using AndroidX.AppCompat.App;
using System.Threading.Tasks;

namespace G_Spot
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);


            new Handler().PostDelayed(() =>
            {
                Intent intent = new Intent(this, typeof(LogInActivity));
                StartActivity(intent);
                Finish(); // Finish current activity to prevent going back to it on back press
            }, 3000);

        }
    }
}