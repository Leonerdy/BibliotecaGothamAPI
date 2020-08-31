using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaGothamApp.Models
{
    public class SolicitacaoEmprestimo
    {
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public Lista Livro { get; set; }
    }
}
