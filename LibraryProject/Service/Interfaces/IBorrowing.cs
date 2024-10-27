using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IBorrowing<T>
    {
        public Task<List<T>> GetAllAsync();
        //   public Task<T> GetByDateTakeAsync(DateTime date);
        public Task SendEmailAfterWeek();

    }
}
