using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imento.Models
{
    /// <summary>
    /// Class that defines the Databasecontext
    /// </summary>
    class DataBaseContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Photo> Photos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Filename for the database file is set here
            optionsBuilder.UseSqlite("Filename=Imento.db");
        }
    }
}
