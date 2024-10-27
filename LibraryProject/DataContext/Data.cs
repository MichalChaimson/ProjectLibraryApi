using Microsoft.EntityFrameworkCore;
using Repositories.Entity;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext
{
    public class Data : DbContext, IContext
    {
        public DbSet<Author> authors { get; set; }
        public DbSet<Borrowing> borrwings { get; set; }
        public DbSet<Book> books { get; set; }
        public DbSet<Responsee> responses { get; set; }
        public DbSet<Requeste> requests { get; set; }
        public DbSet<User> users { get; set; }

        public async Task Save()
        {
            await SaveChangesAsync();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=ZIPCOM-95669;database=LibraryProject24;trusted_connection=true;TrustServerCertificate=True;");
        }
    }
}
