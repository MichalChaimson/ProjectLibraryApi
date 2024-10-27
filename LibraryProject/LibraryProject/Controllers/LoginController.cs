using Common.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Service.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IUser<UserDto> data;
        private readonly IConfiguration _config;

        public LoginController(IUser<UserDto> data, IConfiguration config)
        {
            this.data = data;
            _config = config;
        }

        // POST api/<LibraryController>
        [HttpPost]
        //[Route("api/login")]
        public async Task<IActionResult> Login(UserLogin userLogin)
        {
            //אימות משתמש
            var user = await Authenticate(userLogin);
            if (user != null)
            {
                //יוצרת טוקן
                var token = Generate(user);
                return Ok(token);

            }
            return BadRequest("user not found");

        }

        private string Generate(UserDto user)
        {
            //מפתח להצפנה
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            //אלגוריתם להצפנה
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.MobilePhone,user.Phone),
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private async Task<UserDto> Authenticate(UserLogin userLogin)
        {
            var CurrentUser = await data.GetAllAsync();
            var CurrentUsers = CurrentUser.FirstOrDefault(x => x.UserName.ToLower() == userLogin.Name.ToLower()
              && x.Password == userLogin.Password);
            return CurrentUsers;
        }
    }
}

