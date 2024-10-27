using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IRequest<T>
    {
        public Task<T> AddAsync(T item);
        public Task DeleteAsync(int id);
        public Task RemoveRequestAfter3Days();
    }
}
