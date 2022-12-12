using Microsoft.AspNetCore.Mvc;
using Links_Front.Models;

namespace Links_Front.Controllers
{
    public class ClientsController : Controller
    {
        public async Task<IActionResult> Index(User user)
        {
            return RedirectToAction("Dashboard", user);
        }

        public async Task<IActionResult> NewCard()
        {
            return RedirectToAction("NewClient");
        }

        public async Task<IActionResult> NewCard(Client client)
        {
            ViewBag.ClientID = client.Id;

            return View();
        }

        public async Task<IActionResult> NewClient()
        {
            return View();
        }

        public async Task<IActionResult> Dashboard(User user)
        {
            return View();
        }
    }
}
