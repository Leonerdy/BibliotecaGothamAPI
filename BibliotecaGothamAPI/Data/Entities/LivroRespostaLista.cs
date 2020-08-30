using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaGothamAPI.Data.Entities
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
