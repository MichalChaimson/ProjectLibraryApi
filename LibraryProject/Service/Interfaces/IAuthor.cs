using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IAuthor<T>
    {
        public Task<List<T>> GetAllAsync();
        public Task<T> GetByNameAsync(string name);
        public Task<T> GetByIdAsync(int id);
       
    }
}

