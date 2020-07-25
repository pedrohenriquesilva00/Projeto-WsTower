using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using XamarinWsTower.Models;
using XamarinWsTower.Helpers;
using System.IO;

namespace XamarinWsTower.ViewModels
{
    class NoticiasViewModel
    {
        private IList<Article> _articles;

        public IList<Article> articles
        {
            get { return _articles; }
            set { _articles = value; }
        }


        //! Usando API
        public NoticiasViewModel()
        {
            articles = new List<Article>();

            getNoticias();
        }

        private void getNoticias()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://newsapi.org/v2/");
                HttpResponseMessage response = client.GetAsync("everything?q=copa+do+mundo&language=pt&apiKey=0034a3122848480498ae4099cd2e13fe").Result;

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    Noticia noticias = JsonConvert.DeserializeObject<Noticia>(json);
                    articles = noticias.articles;

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
