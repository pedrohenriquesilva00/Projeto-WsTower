using Android.OS;
using Android.Preferences;
using Plugin.Media;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using XamarinWsTower.Interfaces;
using XF.Material.Forms.Resources;

namespace XamarinWsTower
{
    public partial class App : Application
    {
        public App()
        {

            InitializeComponent();
            MainPage = new Views.SplashView();
            
            XF.Material.Forms.Material.Init(this);
            Application.Current.Resources.MergedDictionaries.Add(new Themes.LightTheme());
            CrossMedia.Current.Initialize();
        }
        protected override void OnStart()
        {


        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}