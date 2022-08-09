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
    public class OrdenanceController : ControllerBase
    {
        private readonly PatientDb _context;

        public OrdenanceController(PatientDb context)
        {
            _context = context;
        }

        // GET: api/Ordenance
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ordenance>>> GetOrdenance()
        {
          if (_context.Ordenance == null)
          {
              return NotFound();
          }
            return await _context.Ordenance.ToListAsync();
        }

        // GET: api/Ordenance/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ordenance>> GetOrdenance(int id)
        {
          if (_context.Ordenance == null)
          {
              return NotFound();
          }
            var ordenance = await _context.Ordenance.FindAsync(id);

            if (ordenance == null)
            {
                return NotFound();
            }

            return ordenance;
        }

        // PUT: api/Ordenance/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdenance(int id, Ordenance ordenance)
        {
            if (id != ordenance.OrdenanceId)
            {
                return BadRequest();
            }

            _context.Entry(ordenance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdenanceExists(id))
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

        // POST: api/Ordenance
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ordenance>> PostOrdenance(Ordenance ordenance)
        {
          if (_context.Ordenance == null)
          {
              return Problem("Entity set 'PatientDb.Ordenance'  is null.");
          }
            _context.Ordenance.Add(ordenance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrdenance", new { id = ordenance.OrdenanceId }, ordenance);
        }

        // DELETE: api/Ordenance/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdenance(int id)
        {
            if (_context.Ordenance == null)
            {
                return NotFound();
            }
            var ordenance = await _context.Ordenance.FindAsync(id);
            if (ordenance == null)
            {
                return NotFound();
            }

            _context.Ordenance.Remove(ordenance);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrdenanceExists(int id)
        {
            return (_context.Ordenance?.Any(e => e.OrdenanceId == id)).GetValueOrDefault();
        }
    }
}
