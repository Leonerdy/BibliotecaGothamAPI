using Prism.Mvvm;
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
    public class Lista : BindableBase
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

        private bool _disponivel;
        public bool Disponivel 
        { 
            get => _disponivel;
            set => SetProperty(ref _disponivel, value);
        }
        
        private InformacoesPublicacao _informacoesPublicacao;
        public InformacoesPublicacao informacoesPublicacao
        {
            get { return _informacoesPublicacao; }
            set { SetProperty(ref _informacoesPublicacao, value); }
        }
    }
        
}

