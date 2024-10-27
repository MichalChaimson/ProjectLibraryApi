using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repositories.Entity;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class AuthorRepository : IAuthorR<Author>
    {
        private readonly IContext context;
        public AuthorRepository(IContext contex)
        {
            this.context = contex;
        }
        public async Task<List<Author>> GetAllAsync()
        {
            return await context.authors.ToListAsync();
        }
        public async Task<Author> GetByNameAsync(string name)
        {
            return await context.authors.FirstOrDefaultAsync(x => x.AuthorName == name);
        }
        public async Task<Author> GetByIdAsync(int id)
        {
            return await context.authors.FirstOrDefaultAsync(x => x.AuthorId == id);
        }
        //public async Task<List<Book>> GetAllBooksOfAsync(int id)
        //{
        //    return await context.authors.FirstOrDefaultAsync(a => a.AuthorId == id).Result.books.ToString();
        //}

    }
}
