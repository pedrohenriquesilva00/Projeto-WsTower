using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinWsTower.Models;
using XamarinWsTower.ViewModels;
using Xamarin.Essentials;
using XF.Material.Forms.UI;

namespace XamarinWsTower.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoticiasView : ContentPage
    {
        NoticiasViewModel _viewModel = new NoticiasViewModel();
        public IList<Article> noticias { get; private set; }
        public NoticiasView()
        {
            InitializeComponent();
            noticias = _viewModel.articles;
            BindingContext = this;
        }

        private void NewsCard_Clicked(object sender, EventArgs e)
        {
            MaterialCard card = (MaterialCard)sender;
            Article ctxArtigo = (Article)card.BindingContext;
            string newsUrl = ctxArtigo.url;
            Browser.OpenAsync(newsUrl);
        }
    }
}