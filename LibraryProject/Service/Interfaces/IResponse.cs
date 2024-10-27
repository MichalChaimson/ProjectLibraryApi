using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IResponse<T>
    {
        public Task<List<T>> GetAllAsync();
        public Task<T> PostAsync(T item);
        public Task PutAsync(T item);
        public Task DeleteAsync(int id);
    }
}
