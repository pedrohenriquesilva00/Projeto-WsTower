using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinWsTower.ViewModels;

namespace XamarinWsTower.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PerfilView : ContentPage
    {
        MinhaContaViewModel vm = new MinhaContaViewModel();
        public PerfilView()
        {
            InitializeComponent();
            this.BindingContext = vm;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if(vm.usuario.Foto != null)
            {
                MinhaImagem.Source = vm.usuario.ImgUsuario;
            }

            MessagingCenter.Subscribe<string>(this, "ErroSessao", (str) =>
            {
                DisplayAlert("Mensagem", str, "Ok");
                App.Current.MainPage = new LoginView();
            });

            MessagingCenter.Subscribe<string>(this, "ErroServidor", (str) =>
            {
                DisplayAlert("Mensagem", str, "Ok");
            });

            MessagingCenter.Subscribe<string>(this, "SucessoUpdate", (str) =>
            {
                DisplayAlert("Mensagem", str, "Ok");
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<string>(this, "SucessoUpdate");
            MessagingCenter.Unsubscribe<string>(this, "ErroServidor");
            MessagingCenter.Unsubscribe<string>(this, "ErroSessao");
        }

        private async void TirarFoto(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsTakePhotoSupported || !CrossMedia.Current.IsCameraAvailable)
            {
                await DisplayAlert("Ops", "Nenhuma câmera detectada.", "OK");

                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(
                new StoreCameraMediaOptions
                {
                    SaveToAlbum = true,
                    Directory = "Pictures",
                    CompressionQuality = 50
                });

            if (file == null)
                return;

            Console.WriteLine(file.GetStream().Length);

            //TODO Otimizar esse código, não é necessário todas essas operações.
            MinhaImagem.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });

            using (var stream = new MemoryStream())
            {
                file.GetStream().CopyTo(stream);
                file.Dispose();
                byte[] fileArray = stream.ToArray();
                vm.updateFoto(fileArray);
            }
        }

        

        private async void EscolherFoto(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Ops", "Galeria de fotos não suportada.", "OK");
                return;
            }   

            var file = await CrossMedia.Current.PickPhotoAsync( new PickMediaOptions
            {
                CompressionQuality = 50
            });


            if (file == null)
                return;

            Console.WriteLine(file.GetStream().Length);

            //TODO Otimizar esse código, não é necessário todas essas operações.
            MinhaImagem.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });

            using (var stream = new MemoryStream())
            {
                file.GetStream().CopyTo(stream);
                file.Dispose();
                byte[] fileArray = stream.ToArray();
                vm.updateFoto(fileArray);
            }
        }
    }
}