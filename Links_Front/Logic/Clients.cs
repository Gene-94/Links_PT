using Links_Front.Data;
using Links_Front.Models;

namespace Links_Front.Logic
{
    public class Clients
    {
        public static List<Client>? ClientList()
        {

            List<Client> _clientes= null;

                using (var db = new ProjectDbContext())
                {
                    //_clientes = db.Clients.ToList();

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
