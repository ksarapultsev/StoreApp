using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StoreApp.Models
{
    public class StoreContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {           
            optionsBuilder.UseSqlite("Filename=StoreDb.sqlite");
        }
    }
}
