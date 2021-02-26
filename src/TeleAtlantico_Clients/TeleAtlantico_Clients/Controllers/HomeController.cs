using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using TeleAtlantico_Clients.Models;
using TeleAtlantico_Clients.Models.Domain;

namespace TeleAtlantico_Clients.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        public HomeController(ILogger<HomeController> logger, IConfiguration _config )
        {
            _logger = logger;
            _configuration = _config;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public int Insert([FromBody] Client client)
        {
            int response = 0;
            using (var httpclient = new HttpClient())
            {
                httpclient.BaseAddress = new Uri("https://localhost:44365/api/client/PostSP");
                var postTask = httpclient.PostAsJsonAsync<Client>("", client);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    response = 1;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact a administrator");
                }
            }
            return response;
        }

        public IActionResult Validate([FromBody] Client clientLog)
        {
            int response = 0;

            IEnumerable<Client> clients = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44365/api/client/GetClients");
                var responseTask = client.GetAsync(""); // para indicar una función en específico
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<Client>>();
                    readTask.Wait();
                    //lee los clientes provenientes de la API
                    clients = readTask.Result;

                }
                else
                {
                    clients = Enumerable.Empty<Client>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact a administrator");
                }
            }

            foreach (Client i in clients)
            {
                if (i.Email == clientLog.Email && i.Password == clientLog.Password)
                {
                    response = 1;

                }
            }

            return Ok(response);
        }

    }
}
