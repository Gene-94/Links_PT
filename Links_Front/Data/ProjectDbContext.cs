
using Links_Front.Models;
using Microsoft.EntityFrameworkCore;

namespace Links_Front.Data
{
    public class ProjectDbContext : DbContext 
    {
        const string ConnectionStr = "server=localhost;port=3306;database=LinksPT;user=root;password=Data_Master369";
        public DbSet<User> Users { get; set; }
        public DbSet<Colaborator> Colaborators { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(ConnectionStr, new MySqlServerVersion(new Version(12, 1, 0)));
        }

        public DbSet<Links_Front.Models.Client> Client { get; set; }

    }
}
