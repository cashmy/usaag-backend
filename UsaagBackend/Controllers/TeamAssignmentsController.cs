//using UsaagBackend.Data;
//using UsaagBackend.Models;
//using Microsoft.AspNetCore.Mvc;
//using System.Linq;

//namespace UsaagBackend.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class TeamAssignmentsController : ControllerBase
//    {
//        private readonly ApplicationDbContext _context;

//        public TeamAssignmentsController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//         ***** GET ALL TeamAssignments *****
//         <baseurl/api/teamAssignments
//        [HttpGet]
//        public IActionResult Get()
//        {
//            var teamAssignments = _context.TeamAssignments.ToList();
//            if (teamAssignments == null)
//            {
//                return NotFound();
//            }
//            return Ok(teamAssignments);
//        }

//         ***** GET All Students by TeamID *****
//         <baseurl/api/teamAssignments
//        [HttpGet("{TeamId}")]
//        public IActionResult GetStudentsByTeamId(int TeamId)
//        {
//            var teamAssignment = _context.TeamAssignments.Where(ta => ta.TeamId == TeamId).SingleOrDefault();
//            return Ok(teamAssignment);
//        }


//         ***** GET All Teams by StudentID *****
//         <baseurl/api/teamAssignments
//         TODO * Modify Endpoint Access URL
//        [HttpGet("{StudentId}")]
//        public IActionResult GetTeamsByStudentId(int StudentId)
//        {
//            var teamAssignment = _context.TeamAssignments.Where(ta => ta.StudentId == StudentId).SingleOrDefault();
//            return Ok(teamAssignment);
//        }

//         ***** ADD A TeamAssignment *****
//         POST /api/teamAssignments
//        [HttpPost]
//        public IActionResult Post([FromBody] TeamAssignments value)
//        {
//            _context.TeamAssignments.Add(value);
//            _context.SaveChanges();
//            return StatusCode(201, value);
//        }

//         ***** DELETE ALL Students for a TeamAssignment *****
//         DELETE /api/teamAssignment
//        [HttpDelete("{TeamId}")]
//        public IActionResult Delete(int TeamId)
//        {

//            var teamAssignments = _context.TeamAssignments.Where(ta => ta.TeamId == TeamId).SingleOrDefault();
//            if (teamAssignments == null)
//            {
//                return NotFound("Requested record not found.");
//            }

//            _context.TeamAssignments.Remove(teamAssignments);
//            _context.SaveChanges();
//            return StatusCode(204, teamAssignments);
//        }

//         TODO: Add a DELETE A Student for a TeamAssignment
//    }
//}
