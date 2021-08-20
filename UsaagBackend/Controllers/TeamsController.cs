using UsaagBackend.Data;
using UsaagBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace UsaagBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TeamsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ***** GET ALL Teams *****
        // <baseurl/api/Teams
        [HttpGet]
        public IActionResult Get()
        {
            var teams = _context.Teams
                .Include(t => t.Cohorts )
                .Include(t => t.TemplateHeader)
                .ToList();
            if (teams == null)
            {
                return NotFound();
            }
            return Ok(teams);
        }


        // ***** GET A Team by ID *****
        // <baseurl/api/teams
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            var team = _context.Teams.Where(t => t.Id == Id).SingleOrDefault();
            return Ok(team);
        }

        // ***** ADD A Team *****
        // POST /api/teams
        [HttpPost]
        public IActionResult Post([FromBody] Teams value)
        {
            _context.Teams.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }


        // ***** UPDATE A Team *****
        // PUT /api/teams
        [HttpPut("{Id}")]
        public IActionResult Put(int Id, [FromBody] Teams value)
        {
            var team = _context.Teams.Where(c => c.Id == Id).SingleOrDefault();
            if (team == null)
            {
                return NotFound("Requested record not found.");
            }
            team.Name = value.Name;
            team.Group = value.Group;
            team.AutoGenName = value.AutoGenName;
            team.GitHubRepository = value.GitHubRepository;
            team.TeamTrelloBoard = value.TeamTrelloBoard;

            // Foreign Key Fields
            team.CohortId = value.CohortId;
            team.HeaderId = value.HeaderId;


            _context.Teams.Update(team);
            _context.SaveChanges();
            return StatusCode(201, team);
        }


        // ***** DELETE A Cohort *****
        // DELETE /api/team
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {

            var team = _context.Teams.Where(c => c.Id == Id).SingleOrDefault();
            if (team == null)
            {
                return NotFound("Requested record not found.");
            }

            _context.Teams.Remove(team);
            _context.SaveChanges();
            return StatusCode(204, team);
        }
    }
}
