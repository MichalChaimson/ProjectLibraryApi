using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Repositories.Entity;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class UserRepository : IUserR<User>
    {
        private readonly IContext context;
        public UserRepository(IContext contex)
        {
            this.context = contex;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await context.users.FirstOrDefaultAsync(x=>x.Email==email);
        }
        public async Task<User> GetByIdAsync(int id)
        {
            User u = await context.users.Include(x=>x.borrowings).FirstOrDefaultAsync(x => x.UserId == id);
            return u;

           // return await context.users.FirstOrDefaultAsync(x => x.UserId == id);
        }

        public async Task<User> GetByNameAsync(string name)
        {
            return await context.users.FirstOrDefaultAsync(x => x.UserName == name);
        }

        public async Task<User> GetByPhoneAsync(string phone)
        {
            return await context.users.FirstOrDefaultAsync(x => x.Phone == phone);
        }
        public async Task<User> PostAsync(User item)
        {
            User user = item;
            await context.users.AddAsync(user);
            await context.Save();
            return user;
        }
        public async Task PutAsync(User item)
        {
            context.users.Update(item);
            await context.Save();
        }

        public async Task DeleteAsync(int id)
        {
            User u = await context.users.FirstOrDefaultAsync(x => x.UserId == id);
            context.users.Remove(u);
            context.Save();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await context.users.ToListAsync();
        }
        public async Task<User> GetByNamAndPasswordAsync(string name,string password)
        {
            return await context.users.Include(u => u.borrowings).FirstOrDefaultAsync(x => x.UserName == name && x.Password == password);
        }
    }
}
