using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaGothamApp.Models
{
    public class InformacoesPublicacao : BindableBase
    {
        //public int ano { get; set; }
        //public string isbn { get; set; }
        //public string editora { get; set; }
        //public int edicao { get; set; }
        //public int paginas { get; set; }

        private int ano;
        public int Ano
        {
            get { return ano; }
            set { SetProperty(ref ano, value); }
        }

        private string isbn;
        public string Isbn
        {
            get { return isbn; }
            set { SetProperty(ref isbn, value); }
        }

        private string editora;
        public string Editora
        {
            get { return editora; }
            set { SetProperty(ref editora, value); }
        }

        private int edicao;
        public int Edicao
        {
            get { return edicao; }
            set { SetProperty(ref edicao, value); }
        }

        private int paginas;
        public int Paginas
        {
            get { return paginas; }
            set { SetProperty(ref paginas, value); }
        }

    }
}
