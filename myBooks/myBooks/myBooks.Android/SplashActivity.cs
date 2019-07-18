using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content.PM;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace myBooks.Droid
{
    [Activity(Label = "myBooks",
        MainLauncher = true,
        NoHistory = true,
        Theme = "@style/SplashTheme",
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            System.Threading.Thread.Sleep(150);
            StartActivity(typeof(MainActivity));
        }
    }
}