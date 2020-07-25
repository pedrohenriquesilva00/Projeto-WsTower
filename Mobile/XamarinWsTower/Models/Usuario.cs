using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XamarinWsTower.Helpers;

namespace XamarinWsTower.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Apelido { get; set; }
        public byte[] Foto { get; set; }
        [JsonIgnore]
        public ImageSource ImgUsuario { get => Utils.ByteToImage(Foto); }
        public string Senha { get; set; }
    }
}
