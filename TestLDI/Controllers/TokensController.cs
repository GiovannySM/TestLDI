using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace TestLDI.Controllers
{
    [Produces("application/json")]
    [Route("api/Tokens")]
    public class TokensController : Controller
    {
        public IConfiguration Configuration { get; }
        public TokensController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get(string Signature)
        {
            return new ObjectResult(GenerateToken(Signature));
        }

        private object GenerateToken(string Signature)
        {
            string KeyConfig = Configuration["Jwt:Key"];

            if (KeyConfig == Signature)
            {
                var IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KeyConfig));

                var token = new JwtSecurityToken(
                 notBefore: new DateTimeOffset(DateTime.Now).DateTime,
                 expires: new DateTimeOffset(DateTime.Now.AddMinutes(60)).DateTime,
                 signingCredentials: new SigningCredentials(IssuerSigningKey,
                                                     SecurityAlgorithms.HmacSha256)
                 );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
            else
            {
                return BadRequest("Signature Invalid");
            }
        }
    }
}