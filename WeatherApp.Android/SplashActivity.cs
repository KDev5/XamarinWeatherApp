using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace WeatherApp.Droid
{
    /// <summary>
    /// Splash screen created as mentioned in the Xamarin Documentation
    /// https://docs.microsoft.com/en-us/xamarin/android/user-interface/splash-screen
    /// </summary>
    /// 
    [Activity(Label = "Happy Weather", MainLauncher = true, Theme ="@style/MyTheme.Splash", NoHistory = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            // Create your application here
        }

        protected override async void OnResume()
        {
            base.OnResume();
            await SimulateStartUp();
        }

        async Task SimulateStartUp()
        {
            var statusRequest = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            if(status == PermissionStatus.Granted)
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
                StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            }
            
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}