using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinWsTower.Helpers;
using XamarinWsTower.Models;

namespace XamarinWsTower.ViewModels
{
   public class CadastroViewModel
    {
        public string nome { get; set; }
        public string email { get; set; }
        public string apelido { get; set; }
        public string senha { get; set; }
        public string confirmarSenha { get; set; }

        public ICommand btnCadastroCommand { get; set; }

        public CadastroViewModel()
        {
            btnCadastroCommand = new Command(cadastro);
        }

        private void cadastro()
        {
            try
            {

                HttpClient client = Utils.getClient;

                // Autorizacao
                // client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token)

                Cadastro cadastro = new Cadastro
                {
                    nome = this.nome,
                    email = this.email,
                    apelido = this.apelido,
                    senha = this.senha,
                    confirmarSenha = this.confirmarSenha
                };

                //Serializar o objeto
                string objetoSerealizado = JsonConvert.SerializeObject(cadastro);

                //Content
                StringContent content = new StringContent(objetoSerealizado, Encoding.UTF8, "application/json");

                //faz a requisão.
                HttpResponseMessage response = client.PostAsync("Usuarios", content).Result;


     
                if(response.StatusCode == HttpStatusCode.NotAcceptable)
                {
                    MessagingCenter.Send<string>("Usuario ja existente", "UsuarioExistente");
                }

                else if (response.StatusCode == HttpStatusCode.Created)
                {
                    //Usuario e senha não encontrado
                    MessagingCenter.Send<string>("Cadastro com sucesso", "SucessoCadastro");
                }
                else
                {
                    //Erro no servidor    
                    MessagingCenter.Send<string>("Erro no servidor", "ErroCadastro");
                }

            }

            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
    }
}
