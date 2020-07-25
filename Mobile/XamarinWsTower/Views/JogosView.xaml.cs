using XamarinWsTower.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinWsTower.ViewModels;
using Xamarin.Forms.Xaml;
using Plugin.MaterialDesignControls;
using XF.Material.Forms.UI;

namespace XamarinWsTower.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JogosView : ContentPage
    {
        JogosViewModel _viewModel = new JogosViewModel();

        public JogosView()
        {
            InitializeComponent();
            this.BindingContext = _viewModel;
        }

        
        //! Eventos relacionados ao filtro
        // Provavelmente não é uma boa ideia fazer os métodos aqui.
        // Talvez uma boa prática seria usar de Command para um método no ViewModel.
        private async void Buscar_Clicked(object sender, EventArgs e)
        {
            // Referencia o ícone clicado para mudar
            // a opacidade e dar um efeito de clique.
            ImageButton icone = (ImageButton)sender;
            var opacity = icone.Opacity;
            icone.Opacity = 1;
            await Task.Delay(100);
            icone.Opacity = opacity;

            // Usa desse verificador booleano para saber se tem conteúdo.
            if (DateEntry.Date != null)
            {
                // Usa casting para AFIRMAR que a data de entrada não é nula.
                DateTime dataBuscada = (DateTime)DateEntry.Date;
                _viewModel.buscaPorData(dataBuscada);
            }
        }

        private  void DateEntry_DateSelected(object sender, DateChangedEventArgs e)
        {
            // Usa desse verificador booleano para saber se tem conteúdo.
            if (DateEntry.Date != null)
            {
                // Usa casting para AFIRMAR que a data de entrada não é nula.
                DateTime dataBuscada = (DateTime)DateEntry.Date;
                _viewModel.buscaPorData(dataBuscada);
            }
        }

        private async void ResetarBusca_Clicked(object sender, EventArgs e)
        {
            // Referencia o ícone clicado para mudar
            // a opacidade e dar um efeito de clique.
            ImageButton icone = (ImageButton)sender;
            var opacity = icone.Opacity;
            icone.Opacity = 1;
            await Task.Delay(100);
            icone.Opacity = opacity;

            _viewModel.resetarBusca();
        }

        private void JogoCard_Clicked(object sender, EventArgs e)
        {
            MaterialCard card = (MaterialCard)sender;
            Jogo ctxJogo = (Jogo)card.BindingContext;
            Navigation.PushAsync(new JogoView(ctxJogo));
        }
    }
}
