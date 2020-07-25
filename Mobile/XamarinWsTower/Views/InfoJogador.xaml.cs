using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinWsTower.Models;

namespace XamarinWsTower.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoJogador : ContentPage
    {
        public InfoJogador(Jogador jogador)
        {
            InitializeComponent();
            this.BindingContext = jogador;
        }
    }
}