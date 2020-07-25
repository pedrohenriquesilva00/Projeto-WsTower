using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using XamarinWsTower.Helpers;
using XamarinWsTower.Models;

namespace XamarinWsTower.ViewModels
{
    public class JogadoresViewModel : BaseViewModel
    {
        private List<Jogador> _jogadoresCache;
        private List<Jogador> _jogadores;

        public List<Jogador> jogadores
        {
            get { return _jogadores; }
            set { 
                _jogadores = value;
                OnPropertyChanged();
                }
        }

        public JogadoresViewModel()
        {
            jogadores = new List<Jogador>();

            getJogador();
        }

        private void getJogador()
        {
            try
            {
                HttpClient client = Utils.getClient;
                HttpResponseMessage response = client.GetAsync("Jogadores").Result;

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;
                    jogadores = JsonConvert.DeserializeObject<List<Jogador>>(json);
                    _jogadoresCache = jogadores;

                   
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

        public void sortDescJogadores()
        {
            jogadores = jogadores.OrderByDescending(j => j.Qtdegols).ToList();
        }
        public void sortAscJogadores()
        {
            jogadores = jogadores.OrderBy(j => j.Qtdegols).ToList();
        }

        //TODO Arrumar um bug relacionado à busca.
        //TODO Escrever uma palavra e depois apagar para escrever
        //TODO outra não é possível, pois o conteudo anterior é descartado.
        public void searchByName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                jogadores = jogadores.Where(j => j.Nome.ToUpper().Contains(name.ToUpper())).ToList();
            }
            else
            {
                jogadores = _jogadoresCache;
            }
        }
    }
}
