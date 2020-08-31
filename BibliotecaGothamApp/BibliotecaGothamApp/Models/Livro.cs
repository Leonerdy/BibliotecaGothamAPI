using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaGothamApp.Models
{
    public class Livro : BindableBase
    {
        public int id { get; set; }

        private string _autor;
        public string Autor
        {
            get { return _autor; }
            set { SetProperty(ref _autor, value); }
        }

        private string _titulo;
        public string Titulo
        {
            get { return _titulo; }
            set { SetProperty(ref _titulo, value); }
        }

        private string _descricao;
        public string Descricao
        {
            get { return _descricao; }
            set { SetProperty(ref _descricao, value); }
        }

        public string imagemCapa { get; set; }

        public bool disponivel { get; set; }
        public InformacoesPublicacao informacoesPublicacao { get; set; }
    }
}
