using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PresentationLayer.Data;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private readonly UnitOfWork _unitOfWork;

        public EnrollmentsController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Enrollments
        [HttpGet]
        public ActionResult<IEnumerable<Enrollment>> GetEnrollments()
        {
            return Ok(_unitOfWork.EnrollmentRepository.Get());
        }

        // GET: api/Enrollments/5
        [HttpGet("{id}")]
        public ActionResult<Enrollment> GetEnrollment(int id)
        {
            var enrollment =  _unitOfWork.EnrollmentRepository.GetByID(id);

            if (enrollment == null)
            {
                return NotFound();
            }

            return enrollment;
        }

        // PUT: api/Enrollments/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutEnrollment(int id, Enrollment enrollment)
        //{
        //    if (id != enrollment.EnrollmentID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(enrollment).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!EnrollmentExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Enrollments
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<Enrollment>> PostEnrollment(Enrollment enrollment)
        //{
        //    _context.Enrollments.Add(enrollment);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetEnrollment", new { id = enrollment.EnrollmentID }, enrollment);
        //}

        //// DELETE: api/Enrollments/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Enrollment>> DeleteEnrollment(int id)
        //{
        //    var enrollment = await _context.Enrollments.FindAsync(id);
        //    if (enrollment == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Enrollments.Remove(enrollment);
        //    await _context.SaveChangesAsync();

        //    return enrollment;
        //}

        //private bool EnrollmentExists(int id)
        //{
        //    return _context.Enrollments.Any(e => e.EnrollmentID == id);
        //}
    }
}
