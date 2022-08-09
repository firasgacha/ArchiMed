using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArchiMed.Models;

namespace ArchiMed.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MedecinController : ControllerBase
{
    private readonly PatientDb _context;

    public MedecinController(PatientDb context)
    {
        _context = context;
    }

    // GET: api/Medecin
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Medecin>>> GetMedecin()
    {
        if (_context.Medecin == null)
        {
            return NotFound();
        }
        return await _context.Medecin.ToListAsync();
    }

    // GET: api/Medecin/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Medecin>> GetMedecin(int id)
    {
        if (_context.Medecin == null)
        {
            return NotFound();
        }
        var medecin = await _context.Medecin.FindAsync(id);

        if (medecin == null)
        {
            return NotFound();
        }

        return medecin;
    }

    // PUT: api/Medecin/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutMedecin(int id, Medecin medecin)
    {
        if (id != medecin.MedecinId)
        {
            return BadRequest();
        }

        _context.Entry(medecin).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MedecinExists(id))
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

    // POST: api/Medecin
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Medecin>> PostMedecin(Medecin medecin)
    {
        if (_context.Medecin == null)
        {
            return Problem("Entity set 'PatientDb.Medecin'  is null.");
        }
        _context.Medecin.Add(medecin);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetMedecin", new { id = medecin.MedecinId }, medecin);
    }

    // DELETE: api/Medecin/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMedecin(int id)
    {
        if (_context.Medecin == null)
        {
            return NotFound();
        }
        var medecin = await _context.Medecin.FindAsync(id);
        if (medecin == null)
        {
            return NotFound();
        }

        _context.Medecin.Remove(medecin);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool MedecinExists(int id)
    {
        return (_context.Medecin?.Any(e => e.MedecinId == id)).GetValueOrDefault();
    }
}