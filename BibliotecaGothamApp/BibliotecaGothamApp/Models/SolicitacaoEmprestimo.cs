using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaGothamApp.Models
{
    public class SolicitacaoEmprestimo
    {
        public string nome { get; set; }
        public string telefone { get; set; }
        public Livro livro { get; set; }
    }
}
