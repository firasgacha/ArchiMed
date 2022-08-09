using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArchiMed.Models;

namespace ArchiMed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RadioController : ControllerBase
    {
        private readonly PatientDb _context;

        public RadioController(PatientDb context)
        {
            _context = context;
        }

        // GET: api/Radio
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Radio>>> GetRadio()
        {
          if (_context.Radio == null)
          {
              return NotFound();
          }
            return await _context.Radio.ToListAsync();
        }

        // GET: api/Radio/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Radio>> GetRadio(int id)
        {
          if (_context.Radio == null)
          {
              return NotFound();
          }
            var radio = await _context.Radio.FindAsync(id);

            if (radio == null)
            {
                return NotFound();
            }

            return radio;
        }

        // PUT: api/Radio/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRadio(int id, Radio radio)
        {
            if (id != radio.RadioId)
            {
                return BadRequest();
            }

            _context.Entry(radio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RadioExists(id))
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

        // POST: api/Radio
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Radio>> PostRadio(Radio radio)
        {
          if (_context.Radio == null)
          {
              return Problem("Entity set 'PatientDb.Radio'  is null.");
          }
            _context.Radio.Add(radio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRadio", new { id = radio.RadioId }, radio);
        }

        // DELETE: api/Radio/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRadio(int id)
        {
            if (_context.Radio == null)
            {
                return NotFound();
            }
            var radio = await _context.Radio.FindAsync(id);
            if (radio == null)
            {
                return NotFound();
            }

            _context.Radio.Remove(radio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RadioExists(int id)
        {
            return (_context.Radio?.Any(e => e.RadioId == id)).GetValueOrDefault();
        }
    }
}
