using Microsoft.EntityFrameworkCore;
using Repositories.Entity;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Repositories.Enums;

namespace Repositories.Repository
{
    public class BookRepository : IBookR<Book>
    {
        private readonly IContext context;
        public BookRepository(IContext context)
        {
            this.context = context;
        }
        public async Task<List<Book>> GetAllAsync()
        {
            var res = await context.books.ToListAsync();
            return res;
        }

        public async Task<List<Book>> GetByCategoryAsync(CategoryType category)
        {
            return await context.books.Where(x => x.category == category).ToListAsync();
        }

        public async Task<List<Book>> GetByGenreAsync(GenreType genre)
        {
            return await context.books.Where(x => x.genre == genre).ToListAsync();
        }

        public async Task<Book> GetByNameAsync(string name)
        {
            var res = await context.books.FirstOrDefaultAsync(x => x.BookName.Trim() == name);
            return res;
        }
        public async Task<Book> GetByIdAsync(int id)
        {
            return await context.books.Include(x=>x.responses).FirstOrDefaultAsync(x => x.BookId == id);
        }

        public async Task<List<Book>> GetAllByName(string name)
        {
            return await context.books.Where(b => b.BookName == name).ToListAsync();
        }
    }
}
