using BibliotecaGothamApp.Models;
using Newtonsoft.Json.Linq;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaGothamApp.Services
{
    public interface IRestAPI
    {

        [Post("/Acervo/obterAcervo")]
        Task<LivroRespostaLista> ObterAcervoLivros([Body] Paginador paginador);

        [Post("/api/livro/emprestimo")]
        Task<Boolean> EmprestarLivro([Body] SolicitacaoEmprestimo solicitacaoEmprestimo);

        [Get("/api/livro/[id]")]
        Task<Livro> GetLivro([AliasAs("id")] int id);
    }
}
