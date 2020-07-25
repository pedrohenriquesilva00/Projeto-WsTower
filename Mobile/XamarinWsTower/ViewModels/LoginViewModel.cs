using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinWsTower.Helpers;
using XamarinWsTower.Models;

namespace XamarinWsTower.ViewModels
{
   public class LoginViewModel
    {
        public string usuario { get; set; }
        public string senha { get; set; }

        public ICommand btnLoginCommand { get; set; }

        public LoginViewModel()
        {
            btnLoginCommand = new Command(login);
        }

        private void login()
        {
            try
            {

                HttpClient client = Utils.getClient;

                // Autorizacao
               // client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", token)

                Login login = new Login
                {
                    usuario = this.usuario,
                    senha = this.senha
                };

                //Serializar o objeto
                string objetoSerealizado = JsonConvert.SerializeObject(login);

                //Content
                StringContent content = new StringContent(objetoSerealizado, Encoding.UTF8, "application/json");



                //faz a requisão.
                HttpResponseMessage response =  client.PostAsync("Login", content).Result;


                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    var token = new JwtSecurityTokenHandler();


                    Token tokenObj = JsonConvert.DeserializeObject<Token>(json);

                    Utils.token = tokenObj.token;

                    MessagingCenter.Send<string>(tokenObj.token, "SucessoLogin");

                }
                else if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    //Usuario e senha não encontrado
                    MessagingCenter.Send<string>("Usuário não encontrado ou senha inválida", "ErroLogin");
                }
                else 
                {
                    //Erro no servidor    
                    MessagingCenter.Send<string>("Erro no servidor", "ErroLogin");
                }

            }

            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        public class Token
        {
            public string token { get; set; }
        }
    }
}
