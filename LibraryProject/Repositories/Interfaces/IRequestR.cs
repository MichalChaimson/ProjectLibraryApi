using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IRequestR<T>
    {
        public Task<T> AddAsync(T item);
        public Task<T> GetByIdAsync(int id);
        public Task<T> GetOldestRequestAsync(string name);
        public Task DeleteAsync(int id);
        public Task<List<T>> getAllAfter3Days();
    }
}
