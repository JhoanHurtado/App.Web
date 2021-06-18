using App.Web.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace App.Web.Controllers
{
    public class ClienteController : Controller
    {
        private string _URL = "https://localhost:44398/api/";
        private HttpClient _httpClient = new HttpClient();

        // GET: Cliente
        public async Task<ActionResult> Index()
        {
            var jsonClientes = await _httpClient.GetStringAsync($"{_URL}cliente");
            var clientes = JsonConvert.DeserializeObject<List<Cliente>>(jsonClientes);
            ViewBag.Clientes = clientes;
            return View();
        }

        public async Task<string> GetClients()
        {
            var jsonClientes = await _httpClient.GetStringAsync($"{_URL}cliente");
            var clientes = JsonConvert.DeserializeObject<List<Cliente>>(jsonClientes);
            return jsonClientes;
        }

        // POST: Cliente/Create
        [HttpPost]
        public async Task<string> Create([Bind(Include = "Identificador,NombreCompleto")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(cliente), Encoding.UTF8);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var jsonClientes = await _httpClient.PostAsync($"{_URL}cliente", httpContent);
                return await GetClients();
            }
            return await GetClients();
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public async Task<string> Edit([Bind(Include = "Identificador,NombreCompleto")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(cliente), Encoding.UTF8);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var jsonClientes = await _httpClient.PutAsync($"{_URL}cliente", httpContent);
                return await GetClients();
            }
                return await GetClients();
        }

        // GET: Cliente/Delete/5
        public async Task<string> Delete(string id)
        {
            if (id == null)
            {
                return await GetClients();
            }
            var jsonClientes = await _httpClient.DeleteAsync($"{_URL}cliente/{id}");
            return await GetClients();

        }

    }
}
