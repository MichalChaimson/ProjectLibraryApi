
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
    public class ResponseRepository : IResponseR<Responsee>
    {
        private readonly IContext context;
       

        public ResponseRepository(IContext context)
        {
            this.context = context;
        }

        public async Task DeleteAsync(int id)
        {
            Responsee r = await context.responses.FirstOrDefaultAsync(x => x.Id == id);
            context.responses.Remove(r);
            context.Save();
        }

        public async Task<List<Responsee>> GetAllAsync()
        {
            return await context.responses.ToListAsync();
        }

        public async Task<Responsee> PostAsync(Responsee item)
        {
            Responsee response = item;
            await context.responses.AddAsync(response);
            await context.Save();
            return response;
        }

        public async Task PutAsync(Responsee item)
        {
            context.responses.Update(item);
            await context.Save();
        }
        public async Task<Responsee> GetByIdAsync(int id)
        {
            return await context.responses.FirstOrDefaultAsync(x => x.BookId == id);

        }


    }
}
