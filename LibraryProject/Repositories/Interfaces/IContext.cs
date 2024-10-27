using Microsoft.EntityFrameworkCore;
using Repositories.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IContext
    {
        public DbSet<Author> authors { get; set; }
        public DbSet<Borrowing> borrwings { get; set; }
        public DbSet<Book> books { get; set; }
        public DbSet<Responsee> responses { get; set; }
        public DbSet<Requeste> requests { get; set; }
        public DbSet<User> users { get; set; }
        public Task Save();
        
    }
}
