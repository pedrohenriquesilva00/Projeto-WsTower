using Plugin.MaterialDesignControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinWsTower.Models;
using XamarinWsTower.ViewModels;
using XF.Material.Forms.UI;

namespace XamarinWsTower.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JogadoresView : ContentPage
    {
        JogadoresViewModel _viewModel = new JogadoresViewModel();

        // Inicialize o indicador de status do ícone com valor default.
        string IconStatus = "SortIcon";

        public JogadoresView()
        {
            InitializeComponent();
            this.BindingContext = _viewModel;
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            // Referencia o ícone clicado para mudar
            // a opacidade e dar um efeito de clique.
            ImageButton icone = (ImageButton)sender;
            var opacity = icone.Opacity;
            icone.Opacity = 1;
            await Task.Delay(100);
            icone.Opacity = opacity;

            // Cria um sistema simples de máquina de estado finito (FSM)
            if (IconStatus == "SortIcon")
            {
                icone.SetDynamicResource(VisualElement.StyleProperty, "AscIcon");
                IconStatus = "AscIcon";
                _viewModel.sortDescJogadores();
            }
            else if (IconStatus == "AscIcon")
            {
                icone.SetDynamicResource(VisualElement.StyleProperty, "DescIcon");
                IconStatus = "DescIcon";
                _viewModel.sortAscJogadores();
            }
            else if (IconStatus == "DescIcon")
            {
                icone.SetDynamicResource(VisualElement.StyleProperty, "AscIcon");
                IconStatus = "AscIcon";
                _viewModel.sortDescJogadores();
            }
        }

        private void Searchbar_TextChanged(object sender, EventArgs e)
        {
            MaterialEntry searchbar = (MaterialEntry)sender;

            _viewModel.searchByName(searchbar.Text);
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

            Searchbar.Text = "";
            _viewModel.searchByName(Searchbar.Text);
        }

        private async void Buscar_Clicked(object sender, EventArgs e)
        {
            // Referencia o ícone clicado para mudar
            // a opacidade e dar um efeito de clique.
            ImageButton icone = (ImageButton)sender;
            var opacity = icone.Opacity;
            icone.Opacity = 1;
            await Task.Delay(100);
            icone.Opacity = opacity;

            _viewModel.searchByName(Searchbar.Text);
        }

        private void Jogador_Clicked(object sender, EventArgs e)
        {
            MaterialCard card = (MaterialCard)sender;
            Jogador ctxJogador = (Jogador)card.BindingContext;
            Navigation.PushAsync(new InfoJogador(ctxJogador));
        }
    }
}