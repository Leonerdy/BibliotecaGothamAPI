using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaGothamApp.Models
{
    public class LivroRespostaLista
    {
        public Lista[] lista { get; set; }
        public Paginador paginador { get; set; }
    }

    public class Lista
    {
        public int id { get; set; }
        public string autor { get; set; }
        public string titulo { get; set; }
        public string descricao { get; set; }
        public object imagemCapa { get; set; }
        public bool disponivel { get; set; }
        public InformacoesPublicacao informacoesPublicacao { get; set; }
    }
}
