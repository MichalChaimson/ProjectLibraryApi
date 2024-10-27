using Common.Model;
using Microsoft.AspNetCore.Mvc;
using Repositories.Entity;
using Repositories.Interfaces;
using Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthor<AuthorDto> service;
        public AuthorController(IAuthor<AuthorDto> service)
        {
            this.service = service;
        }

        // GET: api/<AuthorController>
        [HttpGet]
        public async Task<List<AuthorDto>> Get()
        {
            return await service.GetAllAsync();
        }

        // GET api/<UserController>/5
        [HttpGet("name/{name}")]
        public async Task<AuthorDto> GetByName(string name)
        {
            return await service.GetByNameAsync(name);
        }
        // GET api/<UserController>/5
        [HttpGet("id/{id}")]
        public async Task<AuthorDto> GetById(int id)
        {
            return await service.GetByIdAsync(id);
        }

    }
}
