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
    public class MedicalOrderController : ControllerBase
    {
        private readonly ArchiMedDB _context;

        public MedicalOrderController(ArchiMedDB context)
        {
            _context = context;
        }

        // GET: api/MedicalOrder
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicalOrder>>> GetMedicalOrder()
        {
          if (_context.MedicalOrder == null)
          {
              return NotFound();
          }
            return await _context.MedicalOrder.ToListAsync();
        }

        // GET: api/MedicalOrder/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MedicalOrder>> GetMedicalOrder(int id)
        {
          if (_context.MedicalOrder == null)
          {
              return NotFound();
          }
            var medicalOrder = await _context.MedicalOrder.FindAsync(id);

            if (medicalOrder == null)
            {
                return NotFound();
            }

            return medicalOrder;
        }

        // PUT: api/MedicalOrder/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicalOrder(int id, MedicalOrder medicalOrder)
        {
            if (id != medicalOrder.MedicalOrderId)
            {
                return BadRequest();
            }

            _context.Entry(medicalOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicalOrderExists(id))
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

        // POST: api/MedicalOrder
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MedicalOrder>> PostMedicalOrder(MedicalOrder medicalOrder)
        {
          if (_context.MedicalOrder == null)
          {
              return Problem("Entity set 'ArchiMedDB.MedicalOrder'  is null.");
          }
          _context.MedicalOrder.Add(medicalOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedicalOrder", new { id = medicalOrder.MedicalOrderId }, medicalOrder);
        }

        // DELETE: api/MedicalOrder/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicalOrder(int id)
        {
            if (_context.MedicalOrder == null)
            {
                return NotFound();
            }
            var medicalOrder = await _context.MedicalOrder.FindAsync(id);
            if (medicalOrder == null)
            {
                return NotFound();
            }

            _context.MedicalOrder.Remove(medicalOrder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MedicalOrderExists(int id)
        {
            return (_context.MedicalOrder?.Any(e => e.MedicalOrderId == id)).GetValueOrDefault();
        }
    }
}
