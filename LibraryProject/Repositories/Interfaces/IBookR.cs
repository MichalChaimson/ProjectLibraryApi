using Repositories.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Repositories.Enums;

namespace Repositories.Interfaces
{
    public interface IBookR<T>
    {
        public Task<List<T>> GetAllAsync();
        public Task<T> GetByNameAsync(string name);
        public Task<T> GetByIdAsync(int id);
        public Task<List<T>> GetByGenreAsync(GenreType genre);
        public Task<List<T>> GetByCategoryAsync(CategoryType category);
        public Task<List<T>> GetAllByName(string name);

    }
}
