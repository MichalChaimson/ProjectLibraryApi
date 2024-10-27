using Common.Model;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowingController : ControllerBase
    {

        private readonly IBorrowing<BorrowingDto> service;
        public BorrowingController(IBorrowing<BorrowingDto> service)
        {
            this.service = service;
        }

        // GET: api/<BookController>
        [HttpGet]
        public async Task<List<BorrowingDto>> Get()
        {
            return await service.GetAllAsync();
        }

        //   [HttpGet("{dateTake}")]
        //public async Task<BorrowingDto> GetAllByDateTake(DateTime dateTake)
        //{
        //    return await service.GetByDateTakeAsync(dateTake);
        //}
    }
}
