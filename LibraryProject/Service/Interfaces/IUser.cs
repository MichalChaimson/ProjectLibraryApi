using Common.Model;
using Repositories.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IUser<T>
    {
        public Task<List<T>> GetAllAsync();
        public Task<UserDto> GetByNameAsync(string name);
        public Task<T> GetByEmailAsync(string email);
        public Task<T> GetByIdAsync(int id);
        public Task<T> GetByPhoneAsync(string phone);
        public Task<T> GetByNamAndPasswordAsync(string name, string password);
        public Task<T> PostAsync(T item);
        public Task PutAsync(T item);
        public Task DeleteAsync(int id);
    }
}
