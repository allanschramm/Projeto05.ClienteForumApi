using Microsoft.AspNetCore.Mvc;
using Projeto05.ClienteForumApi.Models;
using System.Net.Http.Headers;

namespace Projeto05.ClienteForumApi.Controllers
{
    public class ApiForumController : Controller
    {
        HttpClient client;

        public ApiForumController(IHttpClientFactory factory)
        {
            client = factory.CreateClient();
        }

        public IActionResult Index()
        {
            return View();
        }

        // Metodo para listar os foruns fornecidos pela API
        public async Task<IActionResult> Listar()
        {
            client.BaseAddress = new Uri("http://localhost:5197");
            client.DefaultRequestHeaders.Accept.Add(new 
                MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                HttpResponseMessage response = client.GetAsync("api/forum").Result;
                if(response.IsSuccessStatusCode)
                {
                    var listaForuns = await response.Content.ReadAsAsync<ForumClient[]>();
                    return View(listaForuns.ToList());
                }
                else
                {
                    throw new Exception("Ocorreu um erro na listagem!");
                }
            }
            catch (Exception ex)
            {
                return View("_Erro", ex);
            }

        }
    }
}
