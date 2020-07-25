using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinWsTower.Models
{
    public class Noticia
    {
        public string status { get; set; }
        public int totalResults { get; set; }
        public IList<Article> articles { get; set; }
    }
}
