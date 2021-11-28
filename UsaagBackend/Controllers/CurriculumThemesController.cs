using UsaagBackend.Data;
using UsaagBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace UsaagBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurriculumThemesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CurriculumThemesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ***** GET ALL CurriculumThemes *****
        // <baseurl/api/curriculumThemes
        [HttpGet]
        public IActionResult Get()
        {
            var curriculumThemes = _context.CurriculumThemes.ToList();
            if (curriculumThemes == null)
            {
                return NotFound();
            }
            return Ok(curriculumThemes);
        }

        // ***** GET ALL Curriculum Thetmes by Archive Status *****
        // <baseurl/api/curriculumThemes/archive/
        [HttpGet("archive/{Status}")]
        public IActionResult GetStatus(bool Status)
        {
            var curriculumThemes = _context.CurriculumThemes
                .Where(ct => ct.Archived == Status)
                .ToList();
            if (curriculumThemes == null)
            {
                return NotFound();
            }
            return Ok(curriculumThemes);
        }

        // ***** GET A Curriculum Theme by ID *****
        // <baseurl/api/curriculumThemes
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            var curriculumTheme = _context.CurriculumThemes
                .Where(c => c.Id == Id)
                .SingleOrDefault();

            return Ok(curriculumTheme);
        }

        // ***** ADD A Curriculum Theme *****
        // POST /api/curriculumThemes
        [HttpPost]
        public IActionResult Post([FromBody] CurriculumThemes value)
        {
            _context.CurriculumThemes.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }

        // ***** UPDATE A Curriculum Theme *****
        // PUT /api/curriculumThemes
        [HttpPut("{Id}")]
        public IActionResult Put(int Id, [FromBody] CurriculumThemes value)
        {
            var curriculumTheme = _context.CurriculumThemes.Where(c => c.Id == Id).SingleOrDefault();
            if (curriculumTheme == null)
            {
                return NotFound("Requested record not found.");
            }
            curriculumTheme.Name = value.Name;
            curriculumTheme.TechnologyStack = value.TechnologyStack;
            curriculumTheme.NumberOfWeeks = value.NumberOfWeeks;
            curriculumTheme.DayTimeStatus = value.DayTimeStatus;
            curriculumTheme.Level = value.Level;


            _context.CurriculumThemes.Update(curriculumTheme);
            _context.SaveChanges();
            return StatusCode(201, curriculumTheme);
        }

        // ***** PATCH A Curriculum Theme's Archived status*****
        // PATCH /api/curriculumThemes
        [HttpPatch("{Id}")]
        public IActionResult Patch(int Id, [FromBody] CurriculumThemes value)
        {
            var curriculumTheme = _context.CurriculumThemes.Where(c => c.Id == Id).SingleOrDefault();
            if (curriculumTheme == null)
            {
                return NotFound("Requested record not found.");
            }

            curriculumTheme.Archived = value.Archived;

            _context.CurriculumThemes.Update(curriculumTheme);
            _context.SaveChanges();
            return StatusCode(201, curriculumTheme);
        }

        // ***** DELETE A CurriculumThemes *****
        // DELETE /api/curriculumTheme
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {

            var curriculumTheme = _context.CurriculumThemes.Where(c => c.Id == Id).SingleOrDefault();
            if (curriculumTheme == null)
            {
                return NotFound("Requested record not found.");
            }

            _context.CurriculumThemes.Remove(curriculumTheme);
            _context.SaveChanges();
            return StatusCode(204, curriculumTheme);
        }
    }
}
