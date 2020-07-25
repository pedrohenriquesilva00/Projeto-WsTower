using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using XamarinWsTower.Interfaces;

namespace XamarinWsTower.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string Email { get; set; }
        public ImageSource FotoPerfil { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public BaseViewModel()
        {
            // Quando qualquer ViewModel que extende de BaseViewModel, será trocado
            // a cor da barra de status para ficar "global".
            //var statusbar = DependencyService.Get<IStatusBarPlatformSpecific>();
            //statusbar.SetStatusBarColor(Color.FromHex("544054"));
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            // "?" verificar se è nulo
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
