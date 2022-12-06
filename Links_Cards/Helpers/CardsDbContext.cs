using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using Links_Cards.Models;
using System.Reflection.Metadata;

namespace Links_Cards.Helpers
{
    public class CardsDbContext : DbContext
    {
        public CardsDbContext(DbContextOptions<CardsDbContext> options) : base(options) { }

        public DbSet<Card_Raw> Cards { get; set; }



    }
}
