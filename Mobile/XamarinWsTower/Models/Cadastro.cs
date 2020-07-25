using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinWsTower.Models
{
   public class Cadastro
    {
        public string nome { get; set; }
        public string email { get; set; }
        public string apelido { get; set; }
        public byte[] foto { get; set; }
        public string senha { get; set; }
        [JsonIgnore]
        public string confirmarSenha { get; set; }
    }
}
