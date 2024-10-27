using Common.Model;
using Microsoft.AspNetCore.Mvc;
using Repositories.Interfaces;
using Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser<UserDto> service;
        public UserController(IUser<UserDto> service)
        {
            this.service = service;
        }


        // GET api/<UserController>/5
        [HttpGet("getByName/{name}")]
        public async Task<UserDto> GetByName(string name)
        {
            return await service.GetByNameAsync(name);
        }

        [HttpGet("getByEmail/{email}")]
        public async Task<UserDto> GetByEmail(string email)
        {
            return await service.GetByEmailAsync(email);
        }
        [HttpGet("getById/{id}")]

        public async Task<UserDto> GetById(int id)
        {
            return await service.GetByIdAsync(id);
        }

        [HttpGet("getByPhone/{phone}")]
        public async Task<UserDto> GetByPhone(string phone)
        {
            return await service.GetByPhoneAsync(phone);
        }

        [HttpGet("{name}/{password}")]
        public async Task<UserDto> GetByNamAndPassword(string name,string password)
        {
            return await service.GetByNamAndPasswordAsync(name,password);
        }


        // POST api/<UserController>
        [HttpPost]
        public async Task<UserDto> Post([FromBody] UserDto value)
        {
           return await service.PostAsync(value);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task Put([FromBody] UserDto value)
        {
            await service.PutAsync(value);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await service.DeleteAsync(id);
        }
    }
}
