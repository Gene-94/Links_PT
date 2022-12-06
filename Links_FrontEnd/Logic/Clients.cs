using Trabalho_Final.Data;
using Trabalho_Final.Models;

namespace Trabalho_Final.Logic
{
    public class Clients
    {
        public static List<Client>? ClientList()
        {

            List<Client> _clientes;

                using (var db = new ProjectDbContext())
                {
                    _clientes = db.Clients.ToList();

                }
                return _clientes;
            try
            {
            }
            catch
            {
                return null;
            }
        }
    }
}
