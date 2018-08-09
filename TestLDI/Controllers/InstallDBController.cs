using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestLDI.Services;

namespace TestLDI.Controllers
{
    [Produces("application/json")]
    [Route("api/InstallDB")]
    public class InstallDBController : Controller
    {
        /// <summary>
        /// IDBContextConfiguration: Configuración Inicial para crear la Base de Datos
        /// </summary>
        private readonly IDBContextConfiguration _DBContextConfiguration;

        /// <summary>
        /// InstallDBController: Constructor
        /// </summary>
        /// <param name="dBContextConfiguration"></param>
        public InstallDBController(IDBContextConfiguration dBContextConfiguration)
        {
            _DBContextConfiguration = dBContextConfiguration;
        }

        // GET: api/InstallDB
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            if (_DBContextConfiguration.InstallDBContext())
            {
                return Ok("Installation of the database " + _DBContextConfiguration.DataBaseName + ", and EF Migrations, generated successfully.");
            }
            else
            {
                return BadRequest("An error occurred with the installation of the database and EF Migrations");
            }
        }
    }
}
