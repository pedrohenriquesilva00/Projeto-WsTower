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
using System.Linq;

namespace XamarinWsTower.ViewModels
{
    class JogosViewModel : BaseViewModel
    {
        // Esse jogosCache serve para manter na memória os dados vindos 
        // da ViewModel sem modificação de busca por data. Útil para evitar
        // várias buscas na API, ao custo de mais memória.
        private List<Jogo> _jogosCache;
        private List<Jogo> _jogos;

        public List<Jogo> jogos
        {
            get { return _jogos; }
            set { 
                _jogos = value;
                OnPropertyChanged();
                }
        }

        //! Usando API
        public JogosViewModel()
        {
            jogos = new List<Jogo>();
            getJogos();
        }

        private void getJogos()
        {
            try
            {
                HttpClient client = Utils.getClient;
                HttpResponseMessage response = client.GetAsync("Jogos").Result;

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    jogos = JsonConvert.DeserializeObject<List<Jogo>>(json);
                    _jogosCache = jogos;

                    // Evitar fazer desse jeito no futuro; é possivel fazer usando get; set;
                    // na propriedade da classe.

                    foreach (Jogo jogo in jogos)
                    {
                        //jogo.SelecaoCasaNavigation.ImgBandeira = Utils.ByteToImage(jogo.SelecaoCasaNavigation.Bandeira);
                        //jogo.SelecaoVisitanteNavigation.ImgBandeira = Utils.ByteToImage(jogo.SelecaoVisitanteNavigation.Bandeira);

                        //foreach (Jogador jogador in jogo.SelecaoCasaNavigation.Jogador)
                        //{
                        //    jogador.Img = Utils.ByteToImage(jogador.Foto);
                        //}
                        //foreach (Jogador jogador in jogo.SelecaoVisitanteNavigation.Jogador)
                        //{
                        //    jogador.Img = Utils.ByteToImage(jogador.Foto);
                        //}
                    }

                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // Esse método pode ser público, pois é usado pela View.
        public void buscaPorData(DateTime date)
        {
            jogos = _jogosCache.Where(j => j.Data == date).ToList();
        }

        public void resetarBusca()
        {
            jogos = _jogosCache;
        }
    }
}
