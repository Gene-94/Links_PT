using Microsoft.AspNetCore.Mvc;
using Trabalho_Final.Models;
using Trabalho_Final.Logic;

namespace Trabalho_Final.Controllers
{
    public class CollabController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> AdminDashboard(User user)
        {
            var userList = Users.UserList();
            return View(userList);
        }

        public async Task<IActionResult> Dashboard(User user)
        {
            var clientList = Clients.ClientList();

            if (clientList == null)
                return RedirectToAction("Index", "Home");// ToDo: Change this route to error page
            return View(clientList);
        }

        [ActionName("New")]
        public async Task<IActionResult> NewColab()
        {
            return View();
        }



    }
}
