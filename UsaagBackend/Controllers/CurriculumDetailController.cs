using UsaagBackend.Data;
using UsaagBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace UsaagBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurriculumDetailController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CurriculumDetailController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ***** GET ALL Detail for a Curriculum Theme (List) *****
        // <baseurl/api/curriculumDetail/<themeId>
        [HttpGet("{ThemeId}")]
        public IActionResult Get(int ThemeId)
        {
            var curriculumDetail = _context.CurriculumDetail
                .Where(cd => cd.ThemeId == ThemeId)
                .Include(cd => cd.TemplateHeader)
                .ToList();
            if (curriculumDetail == null)
            {
                return NotFound();
            }
            return Ok(curriculumDetail);
        }

        // ***** GET A Detail Record for a Curriculum Theme (List) *****
        // <baseurl/api/curriculumDetail/<themeId>/<headerId>
        [HttpGet("{ThemeId}/{Id}")]
        public IActionResult Get(int ThemeId, int Id)
        {
            
            // TODO: Optionally add a join to the Template Detail from the Template Header and return all detail stories
            var curriculumDetail = _context.CurriculumDetail
                .Where(cd => cd.ThemeId == ThemeId && cd.Id == Id)
                .Include(cd => cd.CurriculumThemes)
                .Include(cd => cd.TemplateHeader)
                .ToList();
            if (curriculumDetail == null)
            {
                return NotFound();
            }
            return Ok(curriculumDetail);
        }

        // ***** ADD A Template to a Curriculum Theme (List) *****
        // POST <baseurl/api/curriculumDetail/<themeId>
        [HttpPost("{ThemeId}")]
        public IActionResult Post( int ThemeId, [FromBody] CurriculumDetail value)
        {
            _context.CurriculumDetail.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }

        // ***** UPDATE A Template in a Curriculum Them (List) *****
        // PUT <baseurl/api/curriculumDetail/<themeId>/<id>
        [HttpPut("{ThemeId}/{Id}")]
        public IActionResult Put(int ThemeId, int Id, [FromBody] CurriculumDetail value)
        {
            var curriculumDetail = _context.CurriculumDetail
                .Where(cd => cd.ThemeId == ThemeId && cd.Id == Id)
                .SingleOrDefault();
            if (curriculumDetail == null)
            {
                return NotFound("Requested record not found.");
            }
            curriculumDetail.AssignmentSequence = value.AssignmentSequence;
            curriculumDetail.DayToAssign = value.DayToAssign;
            curriculumDetail.ProjectDays = value.ProjectDays;
            curriculumDetail.LectureTopics = value.LectureTopics;
            curriculumDetail.Notes = value.Notes;

            _context.CurriculumDetail.Update(curriculumDetail);
            _context.SaveChanges();
            return StatusCode(201, curriculumDetail);
        }

        // ***** DELETE A Detail Rcd in a Curriculum Theme (List) *****
        // DELETE <baseurl/api/curriculumDetail/<themeId>/<id>
        [HttpDelete("{ThemeId}/{Id}")]
        public IActionResult Delete(int ThemeId, int Id)
        {

            var curriculumDetail = _context.CurriculumDetail
                .Where(cd => cd.ThemeId == ThemeId && cd.Id == Id)
                .SingleOrDefault();
            if (curriculumDetail == null)
            {
                return NotFound("Requested record not found.");
            }

            _context.CurriculumDetail.Remove(curriculumDetail);
            _context.SaveChanges();
            return StatusCode(204, curriculumDetail);
        }
    }
}
