using Common.Model;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequest<RequestDto> service;
        public RequestController(IRequest<RequestDto> service)
        {
            this.service = service;
        }

        // POST api/<RequestController>
        [HttpPost]
        public async Task<RequestDto>  Post([FromBody] RequestDto request)
        {
           return await service.AddAsync(request);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await service.DeleteAsync(id);
        }
    }
}
