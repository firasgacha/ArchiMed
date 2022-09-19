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
    public class MedicalFolderController : ControllerBase
    {
        private readonly ArchiMedDB _context;

        public MedicalFolderController(ArchiMedDB context)
        {
            _context = context;
        }

        // GET: api/MedicalFolder
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicalFolder>>> GetMedicalFolder()
        {
          if (_context.MedicalFolder == null)
          {
              return NotFound();
          }
            return await _context.MedicalFolder.ToListAsync();
        }

        // GET: api/MedicalFolder/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MedicalFolder>> GetMedicalFolder(int id)
        {
          if (_context.MedicalFolder == null)
          {
              return NotFound();
          }
            var medicalFolder = await _context.MedicalFolder.FindAsync(id);

            if (medicalFolder == null)
            {
                return NotFound();
            }

            return medicalFolder;
        }

        // PUT: api/MedicalFolder/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicalFolder(int id, MedicalFolder medicalFolder)
        {
            if (id != medicalFolder.MedicalFolderId)
            {
                return BadRequest();
            }

            _context.Entry(medicalFolder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicalFolderExists(id))
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

        // POST: api/MedicalFolder
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MedicalFolder>> PostMedicalFolder(MedicalFolder medicalFolder)
        {
          if (_context.MedicalFolder == null)
          {
              return Problem("Entity set 'ArchiMedDB.MedicalFolder'  is null.");
          }
            _context.MedicalFolder.Add(medicalFolder);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MedicalFolderExists(medicalFolder.MedicalFolderId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMedicalFolder", new { id = medicalFolder.MedicalFolderId }, medicalFolder);
        }

        // DELETE: api/MedicalFolder/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicalFolder(int id)
        {
            if (_context.MedicalFolder == null)
            {
                return NotFound();
            }
            var medicalFolder = await _context.MedicalFolder.FindAsync(id);
            if (medicalFolder == null)
            {
                return NotFound();
            }

            _context.MedicalFolder.Remove(medicalFolder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MedicalFolderExists(int id)
        {
            return (_context.MedicalFolder?.Any(e => e.MedicalFolderId == id)).GetValueOrDefault();
        }
    }
}
