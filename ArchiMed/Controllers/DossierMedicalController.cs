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
    public class DossierMedicalController : ControllerBase
    {
        private readonly PatientDb _context;

        public DossierMedicalController(PatientDb context)
        {
            _context = context;
        }

        // GET: api/DossierMedical
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DossierMedical>>> GetDossierMedical()
        {
          if (_context.DossierMedical == null)
          {
              return NotFound();
          }
            return await _context.DossierMedical.ToListAsync();
        }

        // GET: api/DossierMedical/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DossierMedical>> GetDossierMedical(int id)
        {
          if (_context.DossierMedical == null)
          {
              return NotFound();
          }
            var dossierMedical = await _context.DossierMedical.FindAsync(id);

            if (dossierMedical == null)
            {
                return NotFound();
            }

            return dossierMedical;
        }

        // PUT: api/DossierMedical/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDossierMedical(int id, DossierMedical dossierMedical)
        {
            if (id != dossierMedical.NumeroDossier)
            {
                return BadRequest();
            }

            _context.Entry(dossierMedical).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DossierMedicalExists(id))
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

        // POST: api/DossierMedical
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DossierMedical>> PostDossierMedical(DossierMedical dossierMedical)
        {
          if (_context.DossierMedical == null)
          {
              return Problem("Entity set 'PatientDb.DossierMedical'  is null.");
          }
            _context.DossierMedical.Add(dossierMedical);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDossierMedical", new { id = dossierMedical.NumeroDossier }, dossierMedical);
        }

        // DELETE: api/DossierMedical/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDossierMedical(int id)
        {
            if (_context.DossierMedical == null)
            {
                return NotFound();
            }
            var dossierMedical = await _context.DossierMedical.FindAsync(id);
            if (dossierMedical == null)
            {
                return NotFound();
            }

            _context.DossierMedical.Remove(dossierMedical);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DossierMedicalExists(int id)
        {
            return (_context.DossierMedical?.Any(e => e.NumeroDossier == id)).GetValueOrDefault();
        }
    }
}
