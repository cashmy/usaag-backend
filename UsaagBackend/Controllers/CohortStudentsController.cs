using UsaagBackend.Data;
using UsaagBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace UsaagBackend.Controllers
{
    public class CohortStudentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CohortStudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ***** GET ALL Students for a Cohort *****
        // <baseurl/api/cohortStudents/<cohortId>
        [HttpGet("{CohortId}")]
        public IActionResult Get(int CohortId)
        {
            var cohortStudents = _context.CohortStudents
                .Where(ctl => ctl.CohortId == CohortId)
                .Include(ctl => ctl.Students)
                .ToList();
            if (cohortStudents == null)
            {
                return NotFound();
            }
            return Ok(cohortStudents);
        }

        // ***** ADD A Student to a Cohort *****
        // <baseurl/api/cohortStudents/<cohortId>
        [HttpPost("{CohortId}")]
        public IActionResult Post(int CohortId, [FromBody] CohortStudents value)
        {
            _context.CohortStudents.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }


        // ***** ADD A Student to a Cohort *****
        // <baseurl/api/cohortStudents/<cohortId>/<studentId>
        [HttpDelete("{CohortId}/{StudentId}")]
        public IActionResult Delete(int CohortId, int StudentId)
        {
            var cohortStudents = _context.CohortStudents
                .Where(cs => cs.CohortId == CohortId && cs.StudentId == StudentId)
                .SingleOrDefault();

            if (cohortStudents == null)
            {
                return NotFound("Requested record not found.");
            }

            _context.CohortStudents.Remove(cohortStudents);
            _context.SaveChanges();
            return StatusCode(204, cohortStudents);
        }
    }
}
