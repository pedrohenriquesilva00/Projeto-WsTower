using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using XamarinWsTower.Helpers;
using XamarinWsTower.Models;

namespace XamarinWsTower.ViewModels
{
    class MinhaContaViewModel : BaseViewModel
    {
        private Usuario _usuario;
        public Usuario usuario
            {
                get { return _usuario; }
                set {
                        _usuario = value;
                        OnPropertyChanged();
                    }
            }
        public MinhaContaViewModel()
        {
            usuario = new Usuario();
            getUsuario();
        }

        private void getUsuario()
        {
            try
            {
                string token = Preferences.Get("token", String.Empty);

                if (!string.IsNullOrWhiteSpace(token))
                {
                    usuario = Utils.TokenToUser(token);
                }
                else
                {
                    MessagingCenter.Send<string>("Sessão inválida.", "ErroSessao");
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async void updateFoto(Byte[] file)
        {
            try
            {
                usuario.Foto = file;
                HttpClient client = Utils.getClient;

                // Serealiza o objeto para ser enviado o Json
                string objetoSerealizado = JsonConvert.SerializeObject(usuario);

                // Formata o conteúdo para json
                StringContent content = new StringContent(objetoSerealizado, Encoding.UTF8, "application/json");
                // Isso irá enviar o ID também, porém, a API não se importa caso seja enviado.
                // No futuro é necessario permitir que o ID do usuario seja apenas deserializável (GET).
                HttpResponseMessage response = client.PutAsync("Usuarios/" + usuario.Id, content).Result;


                if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    MessagingCenter.Send<string>("Usuário atualizado com sucesso.", "SucessoUpdate");

                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    MessagingCenter.Send<string>("Erro de servidor.", "ErroServidor");
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    MessagingCenter.Send<string>("Usuário não encontrado. Problema de sessão.", "ErroSessao");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
