using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaGothamApp.Models
{
    public class InformacoesPublicacao
    {
        public int ano { get; set; }
        public string isbn { get; set; }
        public string editora { get; set; }
        public int edicao { get; set; }
        public int paginas { get; set; }
    }
}
