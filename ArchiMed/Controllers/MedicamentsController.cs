using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArchiMed.Models;

// Confirmed By Firas
namespace ArchiMed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicamentsController : ControllerBase
    {
        private readonly PatientDb _context;

        public MedicamentsController(PatientDb context)
        {
            _context = context;
        }

        // GET: api/Medicaments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medicaments>>> GetMedicaments()
        {
          if (_context.Medicaments == null)
          {
              return NotFound();
          }
            return await _context.Medicaments.ToListAsync();
        }

        // GET: api/Medicaments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Medicaments>> GetMedicaments(int id)
        {
          if (_context.Medicaments == null)
          {
              return NotFound();
          }
            var medicaments = await _context.Medicaments.FindAsync(id);

            if (medicaments == null)
            {
                return NotFound();
            }

            return medicaments;
        }

        // PUT: api/Medicaments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicaments(int id, Medicaments medicaments)
        {
            if (id != medicaments.MedicamentsId)
            {
                return BadRequest();
            }

            _context.Entry(medicaments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicamentsExists(id))
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
        
        // POST: api/Medicaments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Medicaments>> PostMedicaments(Medicaments medicaments)
        {
          if (_context.Medicaments == null)
          {
              return Problem("Entity set 'PatientDb.Medicaments'  is null.");
          }
            _context.Medicaments.Add(medicaments);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedicaments", new { id = medicaments.MedicamentsId }, medicaments);
        }

        // DELETE: api/Medicaments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicaments(int id)
        {
            if (_context.Medicaments == null)
            {
                return NotFound();
            }
            var medicaments = await _context.Medicaments.FindAsync(id);
            if (medicaments == null)
            {
                return NotFound();
            }

            _context.Medicaments.Remove(medicaments);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MedicamentsExists(int id)
        {
            return (_context.Medicaments?.Any(e => e.MedicamentsId == id)).GetValueOrDefault();
        }
    }
}
