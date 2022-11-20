using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NETCore.MailKit.Core;
using QLKS.CNTT1.nnkhanh.Entities;
using QLKS.CNTT1.nnkhanh.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using QLKS.CNTT1.nnkhanh.Controllers;

namespace QLKS.CNTT1.nnkhanh.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        public static WebApplicationBuilder? builder;

        public static IConfiguration configuration;


        private List<Customer> users = new()
        {
            new Customer("khanh", "khanh"),
        };

        /// <summary>
        /// đăng nhập hệ thống
        /// </summary>
        /// <param name="user">Thông tin đăng nhập</param>
        /// <returns>token </returns>
        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn([FromBody] Customer user)
        {
            var check = users.FirstOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);

            if (check == null)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Đăng nhập thất bại!");
            }
            else
            {
                string stringToken = GenerateToken(user);
                return StatusCode(StatusCodes.Status200OK, stringToken);
            }


        }
        private string GenerateToken(Customer user)
        {
            var key = Encoding.ASCII.GetBytes
            (configuration["Jwt:SecretKey"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim("Id", Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,
                Guid.NewGuid().ToString())
             }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature)
            };


            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }

        /// <summary>
        /// check đăng nhập
        /// </summary>
        /// <returns>Thông báo check thành công</returns>
        [Authorize]
        [HttpGet]
        public IActionResult GetUser()
        {
            return Ok("check thành công!");
        }

        /// <summary>
        /// đăng xuất hệ thống
        /// </summary>
        /// <returns>Thông báo đăng xuất thành công</returns>
        [Authorize]
        [HttpPost("sign-out")]
        public IActionResult SignOutAsync()
        {
            //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return StatusCode(StatusCodes.Status200OK, "đăng xuất thành công!");
        }
    }
}
