using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Plugin.CurrentActivity;
using Lottie.Forms;
using Lottie.Forms.Droid;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace XamarinWsTower.Droid
{
    //! Para deixar a orientação de tela de pé, adicionar o ScreenOrientation.Portrait
    [Activity(Label = "Campeonato FIFA", Icon = "@drawable/app_icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static MainActivity Instance;
        protected override void OnCreate(Bundle savedInstanceState)
        {

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            // Bibliotecas
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            XF.Material.Droid.Material.Init(this, savedInstanceState);

            AnimationViewRenderer.Init();

            // Inicializa a atividade atual para ser usável 
            // depois pelo CrossCurrentActivity.
            CrossCurrentActivity.Current.Init(this, savedInstanceState);

            LoadApplication(new App());
            Instance = this;

            //! Ativa o scroll da tela quando for digitar.
            Window.SetSoftInputMode(Android.Views.SoftInput.AdjustResize);

            //Xamarin.Forms.Application.Current.On<Xamarin.Forms.PlatformConfiguration.Android>().UseWindowSoftInputModeAdjust(WindowSoftInputModeAdjust.Resize);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}