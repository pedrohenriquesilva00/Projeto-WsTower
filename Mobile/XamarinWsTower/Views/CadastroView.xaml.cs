using Plugin.MaterialDesignControls;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinWsTower.Models;
using XamarinWsTower.ViewModels;
using XF.Material.Forms.UI;

namespace XamarinWsTower.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroView : ContentPage
    {
        CadastroViewModel vm = new CadastroViewModel();
        public CadastroView()
        {
            InitializeComponent();
            this.BindingContext = vm;      
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            btnCadastrar.IsEnabled = false;            

            MessagingCenter.Subscribe<string>(this, "UsuarioExistente", (str) =>
            {
                DisplayAlert("Erro", str, "Cancelar");
            });

            MessagingCenter.Subscribe<string>(this, "ErroCadastro", (str) =>
            {
                DisplayAlert("Erro", str, "Cancelar");
            });

            MessagingCenter.Subscribe<string>(this, "SucessoCadastro", (str) =>
            {
                App.Current.MainPage = new LoginView();
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<string>(this, "UsuarioExistente");
            MessagingCenter.Unsubscribe<string>(this, "ErroCadastro");
            MessagingCenter.Unsubscribe<string>(this, "SucessoCadastro");
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new NavigationPage(new LoginView());
        }

        private void ComeçouPreencher(object sender, EventArgs e)
        {

            // Remove a App Bar enquanto o usuário estiver digitando.
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void ParouPreencher(object sender, EventArgs e)
        {

            // Reaparece a App Bar quando o usuário parar de digitar.
            NavigationPage.SetHasNavigationBar(this, true);

            bool temErro = false;

            if (EntryName.HasError || string.IsNullOrWhiteSpace(EntryName.Text))
            {
                temErro = true;
            }

            if (EntryApelido.HasError || string.IsNullOrWhiteSpace(EntryApelido.Text))
            {
                temErro = true;
            }

            if (EntryEmail.HasError || string.IsNullOrWhiteSpace(EntryEmail.Text))
            {
                temErro = true;
            }

            if (EntrySenha.HasError || string.IsNullOrWhiteSpace(EntrySenha.Text))
            {
                temErro = true;
            }

            if (EntryConfirmSenha.HasError || string.IsNullOrWhiteSpace(EntryConfirmSenha.Text))
            {
                temErro = true;
            }

            if (temErro)
            {
                btnCadastrar.IsEnabled = false;
            }

            else
            {
                btnCadastrar.IsEnabled = true;
            }

        }

        private void EntryEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            MaterialTextField entryEmail = (MaterialTextField)sender;
            if (!string.IsNullOrWhiteSpace(entryEmail.Text))
            {
                var emailValidator = new EmailAddressAttribute();
                if (emailValidator.IsValid(entryEmail.Text))
                {
                    entryEmail.HasError = false;
                }
                else
                {
                    entryEmail.HasError = true;
                }
            }
            else
            {
                entryEmail.HasError = true;
            }
        }

        private void EntryApelido_TextChanged(object sender, TextChangedEventArgs e)
        {
            MaterialTextField entryApelido = (MaterialTextField)sender;
            if (!string.IsNullOrWhiteSpace(entryApelido.Text))
            {
                bool isDigitPresent = entryApelido.Text.Any(c => char.IsDigit(c));
                if (isDigitPresent)
                {
                    entryApelido.HasError = true;
                }
                else
                {
                    entryApelido.HasError = false;
                }
            }
            else
            {
                entryApelido.HasError = true;
            }

    }

        private void EntryName_TextChanged(object sender, TextChangedEventArgs e)
        {
            MaterialTextField entryName = (MaterialTextField)sender;
            if(!string.IsNullOrEmpty(entryName.Text))
            {
                bool isDigitPresent = entryName.Text.Any(c => char.IsDigit(c));
                if (isDigitPresent)
                {
                    entryName.HasError = true;
                }
                else
                {
                    entryName.HasError = false;
                }
            }
            else
            {
                entryName.HasError = true;
            }
        }

        
        private void EntrySenha_TextChanged(object sender, TextChangedEventArgs e)
        {
            MaterialTextField entryPassword = (MaterialTextField)sender;
            
            string password = entryPassword.Text;

            bool isValidSenha;

            if (password.Length > 0)
            {
                string pattern = "(?=^.{8,}$)(?=.*\\d)(?=.*[!@#$%^&*]+)(?![.\\n])(?=.*[A-Z])(?=.*[a-z]).*$";
                isValidSenha = Regex.IsMatch(entryPassword.Text, pattern);

                if(isValidSenha)
                {
                    entryPassword.HasError = false;
                }
                else
                {
                    entryPassword.HasError = true;
                }

            }

            else
            {
                entryPassword.HasError = true;
            }
            
        }

        private void EntryConfirmarSenha_TextChanged(object sender, TextChangedEventArgs e)
        {
            MaterialTextField entryConfirmPassword = (MaterialTextField)sender;

            string Password = EntrySenha.Text;
            string confirmPassword = entryConfirmPassword.Text;
            if (!string.IsNullOrEmpty(Password) && Password.Equals(confirmPassword))
            {
                entryConfirmPassword.HasError = false;
            }
            else
            {
                entryConfirmPassword.HasError = true;
            }
        }
    }
}