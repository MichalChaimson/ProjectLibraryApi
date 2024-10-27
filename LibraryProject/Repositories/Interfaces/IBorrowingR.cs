using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IBorrowingR<T>
    {
        public Task<List<T>> GetAllAsync();

        //public Task<T> GetAllByDateTakeAsync(DateTime date);
        public Task<List<T>> getAllAfterWeek();

    }
}
