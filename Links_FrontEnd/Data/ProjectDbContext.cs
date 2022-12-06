
using Trabalho_Final.Models;
using Microsoft.EntityFrameworkCore;

namespace Trabalho_Final.Data
{
    public class ProjectDbContext : DbContext 
    {
        const string ConnectionStr = "server=localhost;port=3306;database=LinksPT;user=root;password=Data_Master369";

        public DbSet<Client> Clients { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Colaborator> Colaborators { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(ConnectionStr, new MySqlServerVersion(new Version(12, 1, 0)));
        }

    }
}
