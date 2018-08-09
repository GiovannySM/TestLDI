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
    public class CreateTokensController : Controller
    {
        /// <summary>
        /// Configuration: Instancia la interfaz de configuraciones
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// CreateTokensController: Constructor
        /// </summary>
        /// <param name="configuration"></param>
        public CreateTokensController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get(string ApiKey)
        {
            return new ObjectResult(GenerateToken(ApiKey));
        }

        private object GenerateToken(string Signature)
        {
            //Obtiene el ApiKey desde el appsettings.json
            string KeyConfig = Configuration["Jwt:Key"];

            //Compara las ApiKeys para proceder a generar el token.
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
                return BadRequest("ApiKey Invalid");
            }
        }
    }
}