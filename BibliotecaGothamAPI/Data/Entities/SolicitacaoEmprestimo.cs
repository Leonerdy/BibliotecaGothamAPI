
namespace BibliotecaGothamAPI.Data.Entities
{
    public class SolicitacaoEmprestimo
    {
        public string nome { get; set; }
        public string telefone { get; set; }
        public Livro livro { get; set; }
    }

    
}
