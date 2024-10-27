
using Microsoft.EntityFrameworkCore;
using Repositories.Entity;
using Repositories.Interfaces;

namespace Repositories.Repository
{
    public class BorrowingRepository : IBorrowingR<Borrowing>
    {
        private readonly IContext context;
        public BorrowingRepository(IContext context)
        {
            this.context = context;
        }
        public async Task<List<Borrowing>> GetAllAsync()
        {
            return await context.borrwings.ToListAsync();
        }

        //public async Task<Borrowing> GetAllByDateTakeAsync(DateTime date)
        //{
        //    return await context.borrwings.FirstOrDefaultAsync(x => x.DateTake == date);

        //}
        public async Task<List<Borrowing>> getAllAfterWeek()
        {
            return await context.borrwings.Where(r => EF.Functions.DateDiffDay(r.DateTake, DateTime.Now) >= 7).ToListAsync();

        }
    }
}
