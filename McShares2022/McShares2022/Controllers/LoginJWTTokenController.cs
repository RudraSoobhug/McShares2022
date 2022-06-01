using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using McShares2022.Models;
using McShares2022.Interfaces;
namespace McShares2022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginJWTTokenController : Controller
    {
        private IConfiguration _config;
        private readonly ILoggingError _ilogError;
        public LoginJWTTokenController(IConfiguration config, ILoggingError ilogError)
        {
            _config = config;
            _ilogError = ilogError;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserModel login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            return response;
            
        }

        private string GenerateJSONWebToken(UserModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserModel AuthenticateUser(UserModel login)
        {
            UserModel user = null;

            //Validate the User Credentials    
            //Demo Purpose, I have Passed HardCoded User Information    
            if (login.Username == "admin")
            {
                user = new UserModel { Username = "admin", EmailAddress = "admin@gmail.com" };
            }
            else
            {
                _ilogError.loggingError(DateTime.Now, "Authentication for token failed!");
            }
            return user;
        }
    }

    public class UserModel
    {
        public string Username { get; set; }
        public string EmailAddress { get; set; }
    }
}
