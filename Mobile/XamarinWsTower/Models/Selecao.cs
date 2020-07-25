using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XamarinWsTower.Helpers;
using XamarinWsTower.Models;

namespace XamarinWsTower.Models
{
    public partial class Selecao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public byte[] Bandeira { get; set; }
        public byte[] Uniforme { get; set; }
        public ImageSource ImgBandeira 
        {
            get => Utils.ByteToImage(Bandeira); 
        }
        public string Escalacao { get; set; }
        public int TotalPontos { get; set; }

        public virtual ICollection<Jogador> Jogador { get; set; }
    }
}
