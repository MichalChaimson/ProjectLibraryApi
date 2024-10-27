using Common.Model;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponseController : ControllerBase
    {

        private readonly IResponse<ResponseDto> service;
        public ResponseController(IResponse<ResponseDto> service)
        {
            this.service = service;
        }
        // GET: api/<ResponseController>
        [HttpGet]
        public async Task<List<ResponseDto>> Get()
        {
            return await service.GetAllAsync();
        }

        // POST api/<ResponseController>
        [HttpPost]
        public async Task<ResponseDto> Post([FromBody] ResponseDto response)
        {
            return await service.PostAsync(response);
        }

        // PUT api/<ResponseController>/5
        [HttpPut("{id}")]
        public async Task Put([FromBody] ResponseDto response)
        {
            await service.PutAsync(response);
        }
      

        // DELETE api/<ResponseController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await service.DeleteAsync(id);
        }
    }
}
