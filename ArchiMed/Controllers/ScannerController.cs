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
    public class ScannerController : ControllerBase
    {
        private readonly ArchiMedDB _context;

        public ScannerController(ArchiMedDB context)
        {
            _context = context;
        }

        // GET: api/Scanner
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Scanner>>> GetScanner()
        {
          if (_context.Scanner == null)
          {
              return NotFound();
          }
            return await _context.Scanner.ToListAsync();
        }

        // GET: api/Scanner/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Scanner>> GetScanner(int id)
        {
          if (_context.Scanner == null)
          {
              return NotFound();
          }
            var scanner = await _context.Scanner.FindAsync(id);

            if (scanner == null)
            {
                return NotFound();
            }

            return scanner;
        }

        // PUT: api/Scanner/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutScanner(int id, Scanner scanner)
        {
            if (id != scanner.ScannerId)
            {
                return BadRequest();
            }

            _context.Entry(scanner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScannerExists(id))
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

        // POST: api/Scanner
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Scanner>> PostScanner(Scanner scanner)
        {
          if (_context.Scanner == null)
          {
              return Problem("Entity set 'ArchiMedDB.Scanner'  is null.");
          }
            _context.Scanner.Add(scanner);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetScanner", new { id = scanner.ScannerId }, scanner);
        }

        // DELETE: api/Scanner/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScanner(int id)
        {
            if (_context.Scanner == null)
            {
                return NotFound();
            }
            var scanner = await _context.Scanner.FindAsync(id);
            if (scanner == null)
            {
                return NotFound();
            }

            _context.Scanner.Remove(scanner);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ScannerExists(int id)
        {
            return (_context.Scanner?.Any(e => e.ScannerId == id)).GetValueOrDefault();
        }
    }
}
