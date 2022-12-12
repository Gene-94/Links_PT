using Microsoft.AspNetCore.Mvc;
using Links_Front.Logic;
using Links_Front.Models;

namespace Links_Front.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Dashboard", "Admin");
        }

        public async Task<IActionResult> Dashboard(User user)
        {
            var userList = Users.UserList();
            return View(userList);
        }
    }
}
