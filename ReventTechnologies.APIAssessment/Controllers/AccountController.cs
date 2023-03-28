using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ReventTechnologies.APIAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AccountController(IConfiguration configuration )
        {
            _configuration = configuration;
        }

        public static User _user = new User();
         
        [HttpPost("RegisterUser")]
        public async Task<ActionResult<User>> Register(UserRegister request)
        {
            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            _user.username = request.UserName;
            _user.PassworHash = passwordHash;
            _user.PasswordSalt = passwordSalt;


            return Ok(_user);
        }

        private void CreatePasswordHash( string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var pmesh = new HMACSHA512())
            {
                passwordSalt = pmesh.Key;
                passwordHash = pmesh.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        [HttpPost("UserLogin")]
        public async Task<ActionResult<string>> Login(UserRegister _login)
        {
            if(_user.username != _login.UserName) 
            {
                return BadRequest("User not found");
            }

            if(!VerifiedPasswordHash(_login.Password, _user.PasswordSalt, _user.PassworHash))
            { 
                return BadRequest("You have entered a wrong password!");
            }      
            
            string token = GenerateToken(_user);

            return Ok(token);
        }

        private string GenerateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.username)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims : claims,
                expires : DateTime.Now.AddDays(2),
                signingCredentials: credential);
             
            var jwt =  new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private bool VerifiedPasswordHash(string password, byte[] passwordSalt, byte[] passwordHash)
        {
            using( var pmesh = new HMACSHA512(passwordSalt))
            {
                var computedHash = pmesh.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                return computedHash.SequenceEqual(passwordHash);
            }

        }
    }
}
