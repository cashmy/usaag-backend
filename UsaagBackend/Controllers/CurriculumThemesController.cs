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

        // ***** GET A Cohort by ID *****
        // <baseurl/api/curriculumThemes
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            var curriculumTheme = _context.CurriculumThemes
                .Where(c => c.Id == Id)
                .SingleOrDefault();

            return Ok(curriculumTheme);
        }

        // ***** ADD A Cohort *****
        // POST /api/curriculumThemes
        [HttpPost]
        public IActionResult Post([FromBody] CurriculumThemes value)
        {
            _context.CurriculumThemes.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }

        // ***** UPDATE A Cohort *****
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
