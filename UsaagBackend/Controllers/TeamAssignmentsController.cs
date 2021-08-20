using UsaagBackend.Data;
using UsaagBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace UsaagBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamAssignmentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TeamAssignmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ***** GET ALL Students for a Team *****
        // <baseurl/api/projectTeams/<teamId>
        [HttpGet]
        public IActionResult Get(int TeamId)
        {
            var studentList = _context.ProjectTeams
                .Where(pt => pt.TeamId == TeamId)
                .Include(pt => pt.Students)
                .ToList();
            if (studentList == null)
            {
                return NotFound();
            }
            return Ok(studentList);
        }

        // ***** GET A Student for a Project Team *****
        // <baseurl/api/projectTeams/<teamId>/<studentId>
        [HttpGet("{TeamId}/{StudentId}")]
        public IActionResult Get(int TeamId, int StudentId)
        {

            var studentProjectInfo = _context.ProjectTeams
                .Where(pt => pt.TeamId == TeamId && pt.StudentId == StudentId)
                .Include(pt => pt.Students)
                .ToList();
            if (studentProjectInfo == null)
            {
                return NotFound();
            }
            return Ok(studentProjectInfo);
        }


        // ***** ADD A Student to a Project Team *****
        // POST <baseurl/api/projectTeams/<teamId>/
        [HttpPost("{TeamId}")]
        public IActionResult Post(int TeamId, [FromBody] TeamAssignments value)
        {
            _context.ProjectTeams.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }

        // ***** UPDATE Student Project Info in a Project Team *****
        // UPDATE <baseurl/api/projectTeams/<teamId>/<studentId>
        [HttpPut("{TeamId}/{StudentId}")]
        public IActionResult Put(int TeamId, int StudentId, [FromBody] TeamAssignments value)
        {
            var studentProjectInfo = _context.ProjectTeams
                .Where(pt => pt.TeamId == TeamId && pt.StudentId == StudentId)
                .SingleOrDefault();
            if (studentProjectInfo == null)
            {
                return NotFound("Requested record not found.");
            }
            studentProjectInfo.TotalPointsScored = value.TotalPointsScored;
            studentProjectInfo.TotalWeightedPointsScored = value.TotalWeightedPointsScored;
            studentProjectInfo.ProjectSubmitted = value.ProjectSubmitted;
            studentProjectInfo.ReflectionResponse = value.ReflectionResponse;

            _context.ProjectTeams.Update(studentProjectInfo);
            _context.SaveChanges();
            return StatusCode(201, studentProjectInfo);
        }

        // ***** DELETE A Student from a Project Team) *****
        // DELETE <baseurl/api/projectTeams/<teamId>/<studentId>
        [HttpDelete("{TeamId}/{StudentId}")]
        public IActionResult Delete(int TeamId, int StudentId)
        {

            var studentProjectInfo = _context.ProjectTeams
                 .Where(pt => pt.TeamId == TeamId && pt.StudentId == StudentId)
                .SingleOrDefault();
            if (studentProjectInfo == null)
            {
                return NotFound("Requested record not found.");
            }

            _context.ProjectTeams.Remove(studentProjectInfo);
            _context.SaveChanges();
            return StatusCode(204, studentProjectInfo);
        }
    }
}
