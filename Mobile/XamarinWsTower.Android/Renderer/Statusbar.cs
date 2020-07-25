using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamarinWsTower.Interfaces;
using Android.OS;
using Plugin.CurrentActivity;
using Xamarin.Forms.Platform.Android;

[assembly: Dependency(typeof(MyDemo.Droid.CustomRenderers.Statusbar))]
namespace MyDemo.Droid.CustomRenderers
{
    public class Statusbar : IStatusBarPlatformSpecific
    {
        public Statusbar()
        {
        }

        public void SetStatusBarColor(Color color)
        {
            // The SetStatusBarcolor is new since API 21
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                var androidColor = color.AddLuminosity(-0.1).ToAndroid();
                //Use the plugin
                CrossCurrentActivity.Current.Activity.Window.SetStatusBarColor(androidColor);
            }
            else
            {
                // Here you will just have to set your color in styles.xml file as above.
            }
        }
    }
}