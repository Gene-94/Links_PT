using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using Links_Messages.Models;
using System.Reflection.Metadata;

namespace Links_Messages.Helpers
{
    public class MessagesDbContext : DbContext
    {
        public MessagesDbContext(DbContextOptions<MessagesDbContext> options) : base(options) { }

        public DbSet<Message> Messages { get; set; }



    }
}
