using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BibliotecaGothamAPI.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BibliotecaGothamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        public string baseUrl = "https://bibliotecagotham.azurewebsites.net/";
        // GET: api/<LivroController>
        [HttpPost("listalivros")]
        public async Task<ActionResult<LivroRespostaLista>> PostPaginador(Paginador paginador)
        {
            try
            {

                var request = JsonConvert.SerializeObject(paginador);
                var content = new StringContent(request, Encoding.UTF8, "application/json");

                var client = new HttpClient
                {
                    BaseAddress = new Uri(baseUrl)
                };
                var url = $"Acervo/obterAcervo";

                var response = await client.PostAsync(url, content);
                var result = await response.Content.ReadAsStringAsync();

                LivroRespostaLista livroRespostaLista = JsonConvert.DeserializeObject<LivroRespostaLista>(result);
                return livroRespostaLista;
        }
            catch (Exception)
            {
                return StatusCode(500, "Nenhum livro para retornar!");
            }
        }
       
        // GET api/<LivroController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Livro>> GetLivro(int? id)
        {
            try
            {
                var client = new HttpClient
                {
                    BaseAddress = new Uri(baseUrl)
                };
                var url = $"Acervo/DetalharLivro/{id}";

                var response = await client.GetAsync(url);
                 var result = await response.Content.ReadAsStringAsync();

                Livro livro = JsonConvert.DeserializeObject<Livro>(result);
                return livro;
            }
            catch (Exception)
            {

                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("Emprestimo")]
        public async Task<ActionResult<Boolean>> PostSolicitacaoEmprestimo(SolicitacaoEmprestimo solicitacaoEmprestimo)
        {
            try
            {
                var request = JsonConvert.SerializeObject(solicitacaoEmprestimo);
                var content = new StringContent(request, Encoding.UTF8, "application/json");

                var client = new HttpClient
                {
                    BaseAddress = new Uri(baseUrl)
                };
                var url = $"Acervo/EmprestarLivro";
                var response = await client.PostAsync(url, content);
                var result = await response.Content.ReadAsStringAsync();

                bool resultBoolean = bool.Parse(result);
                return resultBoolean;
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
