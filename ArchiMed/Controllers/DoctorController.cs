using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArchiMed.Models;
using Microsoft.AspNetCore.Cors;

namespace ArchiMed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("dev")]
    public class DoctorController : ControllerBase
    {
        private readonly ArchiMedDB _context;

        public DoctorController(ArchiMedDB context)
        {
            _context = context;
        }

        // GET: api/Doctor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctors()
        {
          if (_context.Doctors == null)
          {
              return NotFound();
          }
            return await _context.Doctors.ToListAsync();
        }

        // GET: api/Doctor/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> GetDoctor(int id)
        {
          if (_context.Doctors == null)
          {
              return NotFound();
          }
            var doctor = await _context.Doctors.FindAsync(id);

            if (doctor == null)
            {
                return NotFound();
            }

            return doctor;
        }
        
       
        [HttpGet("GetDoctorByDepartement/{id}")]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetDoctorByDepartement(int id)
        {
          if (_context.Doctors == null)
          {
              return NotFound();
          }
            var doctor = await _context.Doctors
                .Where(d => d.DepartmentFk == id).ToListAsync();

            if (doctor == null)
            {
                return NotFound();
            }

            return doctor;
        }
        
        // PUT: api/Doctor/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctor(int id, Doctor doctor)
        {
            if (id != doctor.DoctorId)
            {
                return BadRequest();
            }

            _context.Entry(doctor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorExists(id))
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

        // POST: api/Doctor
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Doctor>> PostDoctor(Doctor doctor)
        {
          if (_context.Doctors == null)
          {
              return Problem("Entity set 'ArchiMedDB.Doctors'  is null.");
          }

          
          var dep = _context.Departments
              .Where(d => d.DepartmentId == doctor.DepartmentFk);
          
          //
          // // var dep = _context.Departments.FindAsync(doctor.DepartmentFk);
          if(dep == null)
          {
            return Problem("Department not found.");
          }
          var Newdoc = new Doctor
          {
              DoctorId = doctor.DoctorId,
              fisrtName = doctor.fisrtName,
              lastName = doctor.lastName,
              gender = doctor.gender,
              birthday = doctor.birthday,
              cin = doctor.cin,
              adress = doctor.adress,
              city = doctor.city,
              country = doctor.country,
              email = doctor.email,
              postalCode = doctor.postalCode,
              specialty = doctor.specialty,
              phone = doctor.phone,
              headofDepartment = doctor.headofDepartment,
              ImageUrl = doctor.ImageUrl,
              DepartmentFk = doctor.DepartmentFk,
              Department = dep.FirstOrDefault(),
          };
            _context.Doctors.Add(Newdoc);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoctor", new { id = doctor.DoctorId }, doctor);
        }

        // DELETE: api/Doctor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            if (_context.Doctors == null)
            {
                return NotFound();
            }
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }

            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DoctorExists(int id)
        {
            return (_context.Doctors?.Any(e => e.DoctorId == id)).GetValueOrDefault();
        }
    }
}
