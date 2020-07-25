using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using XamarinWsTower.Models;
using Xamarin.Forms;
using XamarinWsTower.Helpers;

namespace XamarinWsTower.ViewModels
{

    public class SelecaoViewModel : BaseViewModel
    {
        private List<Selecao> _selecao;

        public List<Selecao> selecoes
        {
            get { return _selecao; }
            set { _selecao = value; }
        }

        public SelecaoViewModel()
        {
            selecoes = new List<Selecao>();

            getSelecao();
        }

        private void getSelecao()
        {
            try
            {
                HttpClient client = Utils.getClient;
                HttpResponseMessage response = client.GetAsync("Selecao").Result;

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    selecoes = JsonConvert.DeserializeObject<List<Selecao>>(json);

                    //foreach (Selecao selecao in selecoes)
                    //{
                    //    selecao.ImgBandeira = Utils.ByteToImage(selecao.Bandeira);
                    //    selecao.ImgBandeira = Utils.ByteToImage(selecao.Bandeira);
                    //}
                }

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }
    }

}