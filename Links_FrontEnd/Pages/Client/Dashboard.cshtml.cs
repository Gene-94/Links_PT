using Microsoft.AspNetCore.Mvc;
using Links_FrontEnd.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Net.WebRequestMethods;

namespace Links_FrontEnd.Pages.Client
{
    public class DashboardModel : PageModel
    {
        public void OnGet()
        {
        }

        IEnumerable<Models.Client>? clients;

        protected async override Task OnInitAsync()
        {
            clients = await Http.GetJsonAsync<IEnumerable<Client>>("/api/clients");
        }
    }
}
