using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaGothamAPI.Data.Entities
{
    public class Paginador


    {
        public int pagina { get; set; }
        public int totalPaginas { get; set; }
        public int registrosPorPagina { get; set; }
        public int totalRegistros { get; set; }
    }
}
