using UsaagBackend.Data;
using UsaagBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace UsaagBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurriculumTemplateListController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CurriculumTemplateListController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ***** GET ALL Templates for a Curriculum Theme (List) *****
        // <baseurl/api/curriculumTemplateList/<themeId>
        [HttpGet("{ThemeId}")]
        public IActionResult Get(int ThemeId)
        {
            var curriculumTemplateList = _context.CurriculumTemplateList
                .Where(ctl => ctl.ThemeId == ThemeId)
                .Include(ctl => ctl.TemplateHeader)
                .ToList();
            if (curriculumTemplateList == null)
            {
                return NotFound();
            }
            return Ok(curriculumTemplateList);
        }

        // ***** GET A Template for a Curriculum Theme (List) *****
        // <baseurl/api/curriculumTemplateList/<themeId>/<headerId>
        [HttpGet("{ThemeId}/{HeaderId}")]
        public IActionResult Get(int ThemeId, int HeaderId)
        {
            
            // TODO: Optionally add a join to the Template Detail from the Template Header and return all detail stories
            var curriculumTemplateList = _context.CurriculumTemplateList
                .Where(ctl => ctl.ThemeId == ThemeId && ctl.HeaderId == HeaderId)
                .Include(ctl => ctl.TemplateHeader)
                .ToList();
            if (curriculumTemplateList == null)
            {
                return NotFound();
            }
            return Ok(curriculumTemplateList);
        }

        // ***** ADD A Template to a Curriculum Theme (List) *****
        // POST <baseurl/api/curriculumTemplateList/<themeId>
        [HttpPost("{ThemeId}")]
        public IActionResult Post( int ThemeId, [FromBody] CurriculumTemplateList value)
        {
            _context.CurriculumTemplateList.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }

        // ***** UPDATE A Template in a Curriculum Them (List) *****
        // PUT <baseurl/api/curriculumTemplateList/<themeId>/<id>
        [HttpPut("{ThemeId}/{HeaderId}")]
        public IActionResult Put(int ThemeId, int HeaderId, [FromBody] CurriculumTemplateList value)
        {
            var curriculumTemplateList = _context.CurriculumTemplateList
                .Where(ctl => ctl.ThemeId == ThemeId && ctl.HeaderId == HeaderId)
                .SingleOrDefault();
            if (curriculumTemplateList == null)
            {
                return NotFound("Requested record not found.");
            }
            curriculumTemplateList.AssignmentSequence = value.AssignmentSequence;
            curriculumTemplateList.DayToAssign = value.DayToAssign;
            curriculumTemplateList.ProjectDays = value.ProjectDays;



            _context.CurriculumTemplateList.Update(curriculumTemplateList);
            _context.SaveChanges();
            return StatusCode(201, curriculumTemplateList);
        }

        // ***** DELETE A Template in a Curriculum Them (List) *****
        // DELETE <baseurl/api/curriculumTemplateList/<themeId>/<id>
        [HttpDelete("{ThemeId}/{HeaderId}")]
        public IActionResult Delete(int ThemeId, int HeaderId)
        {

            var curriculumTemplateList = _context.CurriculumTemplateList
                .Where(td => td.ThemeId == ThemeId && td.HeaderId == HeaderId)
                .SingleOrDefault();
            if (curriculumTemplateList == null)
            {
                return NotFound("Requested record not found.");
            }

            _context.CurriculumTemplateList.Remove(curriculumTemplateList);
            _context.SaveChanges();
            return StatusCode(204, curriculumTemplateList);
        }
    }
}
