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
    public class ConsultationController : ControllerBase
    {
        private readonly PatientDb _context;

        public ConsultationController(PatientDb context)
        {
            _context = context;
        }

        // GET: api/Consultation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Consultation>>> GetConsultation()
        {
          if (_context.Consultation == null)
          {
              return NotFound();
          }
            return await _context.Consultation.ToListAsync();
        }

        // GET: api/Consultation/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Consultation>> GetConsultation(int id)
        {
          if (_context.Consultation == null)
          {
              return NotFound();
          }
            var consultation = await _context.Consultation.FindAsync(id);

            if (consultation == null)
            {
                return NotFound();
            }

            return consultation;
        }

        // PUT: api/Consultation/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConsultation(int id, Consultation consultation)
        {
            if (id != consultation.ConsultationId)
            {
                return BadRequest();
            }

            _context.Entry(consultation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConsultationExists(id))
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

        // POST: api/Consultation
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Consultation>> PostConsultation(Consultation consultation)
        {
          if (_context.Consultation == null)
          {
              return Problem("Entity set 'PatientDb.Consultation'  is null.");
          }
            _context.Consultation.Add(consultation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConsultation", new { id = consultation.ConsultationId }, consultation);
        }

        // DELETE: api/Consultation/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConsultation(int id)
        {
            if (_context.Consultation == null)
            {
                return NotFound();
            }
            var consultation = await _context.Consultation.FindAsync(id);
            if (consultation == null)
            {
                return NotFound();
            }

            _context.Consultation.Remove(consultation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ConsultationExists(int id)
        {
            return (_context.Consultation?.Any(e => e.ConsultationId == id)).GetValueOrDefault();
        }
    }
}
