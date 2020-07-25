using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinWsTower.Interfaces;

namespace XamarinWsTower.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashView : ContentPage
    {
        public SplashView()
        {
            InitializeComponent();
            Navegacao();

            var statusbar = DependencyService.Get<IStatusBarPlatformSpecific>();
            statusbar.SetStatusBarColor(Color.FromHex("#048abf"));
        }

        private async void Navegacao()
        {
            await Task.Delay(5000);
            Application.Current.MainPage = new NavigationPage(new LoginView());
        }
    }
}