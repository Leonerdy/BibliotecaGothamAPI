using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaGothamApp.Models
{
    public class Paginador

    {
        public int pagina { get; set; }
        public int totalPaginas { get; set; }
        public int registrosPorPagina { get; set; }
        public int totalRegistros { get; set; }
    }
}
