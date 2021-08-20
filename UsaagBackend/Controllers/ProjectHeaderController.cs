using UsaagBackend.Data;
using UsaagBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace UsaagBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectHeaderController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProjectHeaderController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ***** GET ALL Project Headers *****
        // <baseurl/api/projectHeader
        [HttpGet]
        public IActionResult Get()
        {
            var projectHeaders = _context.ProjectHeader.ToList();
            if (projectHeaders == null)
            {
                return NotFound();
            }
            return Ok(projectHeaders);
        }


        // ***** GET A Project Header by ID *****
        // <baseurl/api/projectHeader
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            var projectHeader = _context.ProjectHeader
                .Where(ph => ph.Id == Id)
                .SingleOrDefault();

            return Ok(projectHeader);
        }

        // ***** ADD A ProjectHeader *****
        // POST /api/projectHeader
        [HttpPost]
        public IActionResult Post([FromBody] ProjectHeader value)
        {
            _context.ProjectHeader.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }


        // ***** UPDATE A Project Header *****
        // PUT /api/projectHeader
        [HttpPut("{Id}")]
        public IActionResult Put(int Id, [FromBody] ProjectHeader value)
        {
            var projectHeader = _context.ProjectHeader
                .Where(ph => ph.Id == Id)
                .SingleOrDefault();
            if (projectHeader == null)
            {
                return NotFound("Requested record not found.");
            }

            projectHeader.TotalPoints = value.TotalPoints;
            projectHeader.TotalWeightedPoints = value.TotalWeightedPoints;
            projectHeader.DateAssigned = value.DateAssigned;
            projectHeader.DateDue = value.DateDue;
            projectHeader.Status = value.Status;

            _context.ProjectHeader.Update(projectHeader);
            _context.SaveChanges();
            return StatusCode(201, projectHeader);
        }

        // ***** DELETE A Project Header *****
        // DELETE /api/projectHeader
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            // Cascade dekete for Template details is on by default
            var projectHeader = _context.ProjectHeader
                .Where(ph => ph.Id == Id)
                .SingleOrDefault();
            if (projectHeader == null)
            {
                return NotFound("Requested record not found.");
            }

            _context.ProjectHeader.Remove(projectHeader);
            _context.SaveChanges();
            return StatusCode(204, projectHeader);
        }
    }
}
