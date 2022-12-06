using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Trabalho_Final.Models;
using Trabalho_Final.Logic;

namespace Trabalho_Final.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.BtnMessage = Standart.Messagescs.CallToAction();
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            return View();
        }

        public async Task<IActionResult> LogIn()
        {
            ViewBag.SignUp = Standart.Messagescs.SignUp();
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> LogIn(User user)
        {

            var validated = Logic.Users.Validate(user);

            if (validated is null)
            {
                ViewBag.Invalid = Standart.Messagescs.FailedAuth();
            }
            else if (!validated.Active)
            {
                ViewBag.Invalid = Standart.Messagescs.UserInactive();
            }
            else if (validated.Role == 'M')
            {
                return RedirectToAction("Dashboard", "Collab", user);
            }
            else if (validated.Role == 'A')
            {
                return RedirectToAction("AdminDashboard", "Collab", user);
            }
            else if (validated.Role == 'C')
            {
                return RedirectToAction("Dashboard", "Client", user);
            }

            ViewBag.SignUp = Standart.Messagescs.SignUp();
            return View();
        }

        public async Task<IActionResult> New_User()
        {
            /*
            switch (ViewData["UserType"])
            {
                case 'A':
                    ViewBag.ControllerName = "Collab";
                    ViewBag.UserDashboard = "AdminDashboard";
                    break;
                case 'C':
                    ViewBag.ControllerName = "Clients";
                    ViewBag.UserDashboard = "Dashboard";
                    break;
                case 'M':
                    ViewBag.ControllerName = "Collab";
                    ViewBag.UserDashboard = "Dashboard";
                    break;
            }
            No ideia of how to pass around data 
            */
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> New_User(User _user) 
        {
            // Check if user already exists
            //If not exists create new user 

            if(Users.Exists(_user))
            {
                ViewBag.UserExists = "A user with this email is already registered";
            }
            else
            {
                if (Users.AddUser(_user))
                    ViewBag.Added = "Added Successfully";
            }

            return View(_user);
        }

        [ActionName("changepass")]
        public async Task<IActionResult> Reset_User_Pass()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}