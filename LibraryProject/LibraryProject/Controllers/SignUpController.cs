using Common.Model;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private readonly IUser<UserDto> users;

        public SignUpController(IUser<UserDto> users)
        {
            this.users = users;
        }

        //// GET: api/<SignController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<SignController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<SignController>
        [HttpPost]
        public async Task<UserDto> Post([FromBody] UserDto newUser)
        {
           return await users.PostAsync(newUser);
        }

        // PUT api/<SignController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<SignController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await users.DeleteAsync(id);
        }
    }
}
