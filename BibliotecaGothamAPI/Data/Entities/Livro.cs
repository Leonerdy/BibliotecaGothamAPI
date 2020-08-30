using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaGothamAPI.Data.Entities
{
    public class Livro
    {
        public int id { get; set; }
        public string autor { get; set; }
        public string titulo { get; set; }
        public string descricao { get; set; }
        public string imagemCapa { get; set; }
        public bool disponivel { get; set; }
        public InformacoesPublicacao informacoesPublicacao { get; set; }
    }
        
}
