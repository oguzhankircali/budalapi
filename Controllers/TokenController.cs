using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Budalapi.Controllers
{
    public class TokenController : Controller
    {
        [AllowAnonymous]
        [HttpPost]
        [Route("token")]
        public IActionResult Post([FromBody]LoginRequest request)
        {
            if (ModelState.IsValid)
            {
                var user = ""; //_userService.Get(request.UserName, request.Password);
                if (user == null)
                {
                    return Unauthorized();
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, request.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var token = new JwtSecurityToken
                (
                    issuer: "", //_configuration["Issuer"], //appsettings.json içerisinde bulunan issuer değeri
                    audience: "", //_configuration["Audience"],//appsettings.json içerisinde bulunan audince değeri
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(30), // 30 gün geçerli olacak
                    notBefore: DateTime.UtcNow,
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("")), //_configuration["SigningKey"])),//appsettings.json içerisinde bulunan signingkey değeri
                            SecurityAlgorithms.HmacSha256)
                );
                
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }
            return BadRequest();
        }

        public class LoginRequest
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }
    }
}