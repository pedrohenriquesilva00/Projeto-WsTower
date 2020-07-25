using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinWsTower.Helpers;
using XamarinWsTower.Models;
using XamarinWsTower.ViewModels;

namespace XamarinWsTower.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {

        LoginViewModel vm = new LoginViewModel();
        public LoginView()
        {
            InitializeComponent();
            this.BindingContext = vm;

            // Remove App Bar
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            btnLogin.IsEnabled = false;

            string authToken = Preferences.Get("token", String.Empty);

            if (!string.IsNullOrEmpty(authToken))
            {
                Usuario user = Utils.TokenToUser(authToken);
                App.Current.MainPage = new Menu();
            }

            MessagingCenter.Subscribe<string>(this, "ErroLogin", (str) =>
            {
                DisplayAlert("Mensagem", str, "Cancelar");
            });

            MessagingCenter.Subscribe<string>(this, "SucessoLogin", (token) =>
            {
                Preferences.Set("token", token);
                App.Current.MainPage = new Menu();
                
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<string>(this, "ErroLogin");
            MessagingCenter.Unsubscribe<string>(this, "SucessoLogin");
        }

        private void ComeçouPreencher(object sender, EventArgs e)
        {
            //Logo.IsVisible = false;
        }

        private void ParouPreencher(object sender, EventArgs e)
        {
            //Logo.IsVisible = true;

            bool temErro = false;
            if (string.IsNullOrEmpty(EntryUsuario.Text))
            {
                temErro = true;
            }

            if (string.IsNullOrEmpty(EntrySenha.Text))
            {
                temErro = true;
            }

            if (temErro)
            {
                btnLogin.IsEnabled = false;
            }

            else
            {
                btnLogin.IsEnabled = true;
            }
        }

        private void CadastrarButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CadastroView());
        }
    }
}

    