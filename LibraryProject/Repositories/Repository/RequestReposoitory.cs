using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Repositories.Entity;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Repositories.Repository
{
    public class RequestReposoitory : IRequestR<Requeste>
    {
        private readonly IContext context;
        private readonly IBookR<Book> repositoryBook;

        public RequestReposoitory(IContext contex, IBookR<Book> repositoryBook)
        {
            this.context = contex;
            this.repositoryBook = repositoryBook;
        }
        public async Task<Requeste> AddAsync(Requeste item)
        {
            Requeste request = item;
            await context.requests.AddAsync(item);
            await context.Save();
            return request;
        }

        public async Task DeleteAsync(int id)
        {
            Requeste r = await context.requests.FirstOrDefaultAsync(x => x.Id == id);
            context.requests.Remove(r);
            context.Save();
        }
        public async Task<Requeste> GetOldestRequestAsync(string name)
        {
            var res = context.books.Include(x => x.requests).Where(x => x.BookName == name);
            Requeste r = res.SelectMany(b => b.requests).OrderBy(r => r.Date).FirstOrDefault();
            return r;
        }
        public async Task<Requeste> GetByIdAsync(int id)
        {
            return await context.requests.FirstOrDefaultAsync(r => r.Id == id);
        }
        public async Task<List<Requeste>> getAllAfter3Days()
        {
            return await context.requests.Where(r => EF.Functions.DateDiffDay(r.Date, DateTime.Now) >= 3).ToListAsync();
        }
       

    }
}
