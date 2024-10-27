using Common.Model;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using static Repositories.Enums;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBook<BookDto> service;
        public BookController(IBook<BookDto> service)
        {
            this.service = service;
        }

        // GET: api/<BookController>
        [HttpGet]
        public async Task<List<BookDto>> Get()
        {
            return await service.GetAllAsync();
        }

        // GET api/<UserController>/5
        [HttpGet("name/{name}")]
        public async Task<BookDto> GetByName(string name)
        {
            return await service.GetByNameAsync(name);
        }
        // GET api/<UserController>/5
        [HttpGet("id/{id}")]
        public async Task<BookDto> GetById(int id)
        {
            return await service.GetByIdAsync(id);
        }


        // GET api/<UserController>/5
        [HttpGet("genre/{type}")]
        public async Task<List<BookDto>> GetByGenre(GenreType type)
        {
            return await service.GetByGenreAsync(type);
        }

        // GET api/<UserController>/5
        [HttpGet("category/{type}")]
        public async Task<List<BookDto>> GetByCategory(CategoryType type)
        {
            return await service.GetByCategoryAsync(type);
        }
    }
}
