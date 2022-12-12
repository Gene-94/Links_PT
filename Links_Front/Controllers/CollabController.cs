using Microsoft.AspNetCore.Mvc;
using Links_Front.Models;
using Links_Front.Logic;

namespace Links_Front.Controllers
{
    public class CollabController : Controller
    {
        User authUser = null;
        public async Task<IActionResult> Index()
        {
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Dashboard(User user)
        {
            authUser = user;
            List<Client>? clientList = null;
            using(HttpClient hc = new())
            {
                var response = await hc.GetAsync("https://localhost:7195/Clients/Public/all");
                if (response != null && response.IsSuccessStatusCode)
                {
                    clientList = await response.Content.ReadAsAsync<List<Client>>(); 
                }
            }

            if (clientList == null)
                return RedirectToAction("Error", "Home");
            return View(clientList);
        }

        [Route("[controller]/Details/{id}")]
        public async Task<IActionResult> Details([FromRoute] int id)
        {
            Client? client = null;
            using (HttpClient hc = new())
            {
                var response = await hc.GetAsync($"https://localhost:7195/Clients/Public/{id}");
                if (response != null && response.IsSuccessStatusCode)
                {
                    client = await response.Content.ReadAsAsync<Client>();
                }
            }

            if (client == null)
                return RedirectToAction("Error", "Home");
            return View("ClientDetails", client);
        }
        [HttpGet]
        [Route("[controller]/EditClient/{id}")]
        public async Task<IActionResult> EditClient([FromRoute] int id)
        {
            Client? client = null;
            using (HttpClient hc = new())
            {
                var response = await hc.GetAsync($"https://localhost:7195/Clients/Public/{id}");
                if (response != null && response.IsSuccessStatusCode)
                {
                    client = await response.Content.ReadAsAsync<Client>();
                }
            }
            ViewBag.post = false;
            if (client == null)
                return RedirectToAction("Error", "Home");
            return View(client);
        }

        [HttpPost]
        [Route("[controller]/EditClient/{id}")]
        public async Task<IActionResult> EditClient([FromBody]Client editedClient, [FromRoute] int id)
        {
            ViewBag.post = true;
            using (HttpClient hc = new())
            {
                var response = await hc.PostAsJsonAsync($"https://localhost:7195/Clients/Public/update/{id}", editedClient);
                if (response != null && response.IsSuccessStatusCode)
                {
                    editedClient = await response.Content.ReadAsAsync<Client>();
                    ViewBag.sucess = true;
                }
                else
                    ViewBag.sucess = false;
            }

            return View("EditClient", editedClient);
        }

        [Route("[controller]/Delete/{id}")]
        public async Task<IActionResult> DeleteClient([FromRoute] int id)
        {
            Client? client = null;
            using (HttpClient hc = new())
            {
                var response = await hc.GetAsync($"https://localhost:7195/Clients/Public/{id}");
                if (response != null && response.IsSuccessStatusCode)
                {
                    client = await response.Content.ReadAsAsync<Client>();
                }
            }
            if (client == null)
                return RedirectToAction("Error", "Home");
            return View(client);
        }

        [HttpPost, ActionName("DeleteClient")]
        public async Task<IActionResult> DeleteConfirmed([FromRoute] int id)
        {
            Client? client = null;
            using (HttpClient hc = new())
            {
                var response = await hc.PostAsJsonAsync($"https://localhost:7195/Clients/Public/delete/{id}", client);
                if (response != null && response.IsSuccessStatusCode)
                {
                    client = await response.Content.ReadAsAsync<Client>();
                }
                else
                    ViewBag.sucess = false;
            }
            return RedirectToAction("Dashboard");
        }


    }
}
