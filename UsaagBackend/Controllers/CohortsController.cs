using UsaagBackend.Data;
using UsaagBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;
using System.Linq;

namespace UsaagBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CohortsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        
        public CohortsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ***** GET ALL Cohorts *****
        // <baseurl/api/cohorts
        [HttpGet]
        public IActionResult Get()
        {
            var cohorts = _context.Cohorts.ToList();
            if (cohorts == null)
            {
                return NotFound();
            }
            return Ok(cohorts);
        }

        // ***** GET ALL Cohorts by Archive Status *****
        // <baseurl/api/cohorts/archive/
        [HttpGet("archive/{Status}")]
        public IActionResult GetStatus(bool Status)
        {
            var cohorts = _context.Cohorts
                .Where(c => c.Archived == Status)
                .ToList();
            if (cohorts == null)
            {
                return NotFound();
            }
            return Ok(cohorts);
        }


        // ***** GET A Cohort by ID *****
        // <baseurl/api/cohorts
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            var cohort = _context.Cohorts
                .Where(c => c.Id == Id)
                .SingleOrDefault();

            return Ok(cohort);
        }

        // ***** ADD A Cohort *****
        // POST /api/cohorts
        [HttpPost]
        public IActionResult Post([FromBody]Cohorts value)
        {
            _context.Cohorts.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }

        // ***** UPDATE A Cohort *****
        // PUT /api/cohorts
        [HttpPut("{Id}")]
        public IActionResult Put(int Id, [FromBody] Cohorts value)
        {
            var cohort = _context.Cohorts.Where(c => c.Id == Id).SingleOrDefault();
            if (cohort == null)
            {
                return NotFound("Requested record not found.");
            }
            cohort.Name = value.Name;
            cohort.SlackChannel = value.SlackChannel;
            cohort.Archived = value.Archived;
            cohort.CPKColor = value.CPKColor;
            cohort.TextColor = value.TextColor;
            cohort.Abbreviation = value.Abbreviation;


            _context.Cohorts.Update(cohort);
            _context.SaveChanges();
            return StatusCode(201, cohort);
        }

        // ***** PATCH A Cohort archived status*****
        // PATCH /api/cohorts
        [HttpPatch("{Id}")]
        public IActionResult Patch(int Id, [FromBody] Cohorts value)
        {
            var cohort = _context.Cohorts.Where(c => c.Id == Id).SingleOrDefault();
            if (cohort == null)
            {
                return NotFound("Requested record not found.");
            }

            cohort.Archived = value.Archived;

            _context.Cohorts.Update(cohort);
            _context.SaveChanges();
            return StatusCode(201, cohort);
        }

        // ***** DELETE A Cohort *****
        // DELETE /api/cohort
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {

            var cohort = _context.Cohorts.Where(c => c.Id == Id).SingleOrDefault();
            if (cohort == null)
            {
                return NotFound("Requested record not found.");
            }

            // TODO Verify that a cascade delete occurs in CohortStudents as well.

            _context.Cohorts.Remove(cohort);
            _context.SaveChanges();
            return StatusCode(204, cohort);
        }
    }
}
