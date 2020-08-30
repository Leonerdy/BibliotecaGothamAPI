using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaGothamApp.Models
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
