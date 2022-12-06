using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using Links_Clients.Models;

namespace Links_Clients.Helpers
{
    public class ClientsDbContext : DbContext
    {
        public ClientsDbContext(DbContextOptions<ClientsDbContext> options) : base(options) { }

        public DbSet<Client_Raw> Clients { get; set; }
    }
}
