using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinWsTower.Models;
using XamarinWsTower.ViewModels;

namespace XamarinWsTower.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelecoesView : ContentPage
    {
        SelecaoViewModel _viewModel = new SelecaoViewModel();
        public IList<Selecao> Selecoes { get; private set; }

        public SelecoesView()
        {
            InitializeComponent();

            Selecoes = _viewModel.selecoes;

            BindingContext = this;
        }
        void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Selecao selectedItem = e.SelectedItem as Selecao;
        }

        void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            Selecao tappedItem = e.Item as Selecao;
        }
    }
}