using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinWsTower.Helpers;
using XamarinWsTower.Interfaces;

namespace XamarinWsTower.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : MasterDetailPage
    {
        public Menu()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            Detail = new NavigationPage(new MainView());
        }

        protected override void OnAppearing()
        {
            string darkThemeKey = Preferences.Get("darkTheme", "false");
            bool darkThemeToggle = bool.Parse(darkThemeKey);

            switchDarkTheme.IsToggled = darkThemeToggle;
        }


            private void GoMinhaConta(object sender, System.EventArgs e)
		{
            Detail.Navigation.PushAsync(new PerfilView());
            IsPresented = false;
        }
		private void GoSobre(object sender, System.EventArgs e)
		{
            Detail.Navigation.PushAsync(new SobreView());
            IsPresented = false;
        }
        private void GoInicio(object sender, System.EventArgs e)
        {
            Detail = new NavigationPage(new MainView());
        }

        private void GoConfiguracoes(object sender, System.EventArgs e)
        {
        }

        private void Logoff(object sender, System.EventArgs e)
        {
            Preferences.Remove("token");
            Application.Current.MainPage = new NavigationPage(new LoginView());
        }


        private void TemaEscuro_Toggled(object sender, ToggledEventArgs e)
        {
            var statusbar = DependencyService.Get<IStatusBarPlatformSpecific>();
            // Se for verdadeiro o booleano de ativado.
            if (e.Value)
            {
                Settings.SetTheme(Settings.Theme.DarkTheme);
                statusbar.SetStatusBarColor(Color.FromHex("#353535"));
            }
            else
            {
                Settings.SetTheme(Settings.Theme.LightTheme);
                statusbar.SetStatusBarColor(Color.FromHex("#048abf"));
            }

            Preferences.Set("darkTheme", e.Value.ToString());
        }
    }
}