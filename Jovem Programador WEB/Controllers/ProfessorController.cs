using JovemProgramadorWeb7.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace Jovem_Programador_WEB.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly IConfiguration _configuration;

        public ProfessorController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> BuscarEndereco(string cep)
        {
            Endereco endereco = new Endereco();

            try
            {
                cep = cep.Replace("-", "");

                using var client = new HttpClient();
                var result = await client.GetAsync(_configuration.GetSection("ApiCep")["BaseUrl"] + cep + "/json");

                if (result.IsSuccessStatusCode)
                {
                    endereco = JsonSerializer.Deserialize<Endereco>(await result.Content.ReadAsStringAsync(), new JsonSerializerOptions());
                }
                else
                {
                    ViewData["MsgErro"] = "Erro na busca do endereço!";
                }
            }
            catch (Exception)
            {
                throw;
            }

            return View("Endereco", endereco);
        }
    }
}

