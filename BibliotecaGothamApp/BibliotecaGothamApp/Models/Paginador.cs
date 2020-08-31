using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaGothamApp.Models
{
    public class Paginador : BindableBase

    {

        private int _pagina;
        public int Pagina
        {
            get => _pagina;
            set => SetProperty(ref _pagina, value);
        }

        private int _registrosPorPagina;
        public int RegistrosPorPagina
        {
            get => _registrosPorPagina;
            set => SetProperty(ref _registrosPorPagina, value);
        }
       
        public int totalPaginas { get; set; }
       
        public int totalRegistros { get; set; }

        public Paginador()
        {
            this.Pagina = 0;
            this.totalPaginas = 0;
            this.RegistrosPorPagina = 0;
            this.totalRegistros = 0;
        
        }
        
    }
}
