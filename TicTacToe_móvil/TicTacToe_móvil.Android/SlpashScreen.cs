using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTacToe_móvil.Droid
{
    [Activity(Label = "TicTacToe", Icon = "@drawable/IconoL_adaptive_fore", 
        Theme = "@style/TemaN", MainLauncher = true, 
        ConfigurationChanges = ConfigChanges.ScreenSize, ScreenOrientation = ScreenOrientation.Portrait)] 
    public class SlpashScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            StartActivity(new Intent(Application.Context,typeof(MainActivity)));

            // Create your application here
        }
    }
}