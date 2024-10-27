using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IAuthorR<T>
    {
        public Task<List<T>> GetAllAsync();
        public Task<T> GetByNameAsync(string name);
        public Task<T> GetByIdAsync(int id);
      //  public Task<List<T>> GetAllBooksOfAsync(int id);

    }
}

