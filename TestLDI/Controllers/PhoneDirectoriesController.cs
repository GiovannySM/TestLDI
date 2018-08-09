using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestLDI.Entities;

namespace TestLDI.Controllers
{
    [Produces("application/json")]
    [Route("api/PhoneDirectories")]
    [Authorize]
    [ProducesResponseType(typeof(PhoneDirectory), 200)]
    [ProducesResponseType(typeof(IDictionary<string, string>), 401)]
    [ProducesResponseType(typeof(IDictionary<string, string>), 403)]
    [ProducesResponseType(500)]
    public class PhoneDirectoriesController : Controller
    {
        private readonly TestLDI_Context _context;

        /// <summary>
        /// PhoneDirectoriesController: Constructor
        /// </summary>
        /// <param name="context"></param>
        public PhoneDirectoriesController(TestLDI_Context context)
        {
            _context = context;
        }

        // GET: api/PhoneDirectories
        [HttpGet]
        public IEnumerable<PhoneDirectory> GetphoneDirectories()
        {
            return _context.phoneDirectories;
        }

        // GET: api/PhoneDirectories/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPhoneDirectory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var phoneDirectory = await _context.phoneDirectories.SingleOrDefaultAsync(m => m.Id == id);

            if (phoneDirectory == null)
            {
                return NotFound();
            }

            return Ok(phoneDirectory);
        }

        // PUT: api/PhoneDirectories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhoneDirectory([FromRoute] int id, [FromBody] PhoneDirectory phoneDirectory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != phoneDirectory.Id)
            {
                return BadRequest();
            }

            _context.Entry(phoneDirectory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhoneDirectoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PhoneDirectories
        [HttpPost]
        public async Task<IActionResult> PostPhoneDirectory([FromBody] PhoneDirectory phoneDirectory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.phoneDirectories.Add(phoneDirectory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhoneDirectory", new { id = phoneDirectory.Id }, phoneDirectory);
        }

        // DELETE: api/PhoneDirectories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhoneDirectory([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var phoneDirectory = await _context.phoneDirectories.SingleOrDefaultAsync(m => m.Id == id);
            if (phoneDirectory == null)
            {
                return NotFound();
            }

            _context.phoneDirectories.Remove(phoneDirectory);
            await _context.SaveChangesAsync();

            return Ok(phoneDirectory);
        }

        private bool PhoneDirectoryExists(int id)
        {
            return _context.phoneDirectories.Any(e => e.Id == id);
        }
    }
}