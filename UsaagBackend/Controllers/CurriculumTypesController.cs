using UsaagBackend.Data;
using UsaagBackend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace UsaagBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurriculumTypesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CurriculumTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ***** GET ALL CurriculumTypes *****
        // <baseurl/api/curriculumTypes
        [HttpGet]
        public IActionResult Get()
        {
            var curriculumTypes = _context.CurriculumTypes.ToList();
            if (curriculumTypes == null)
            {
                return NotFound();
            }
            return Ok(curriculumTypes);
        }

        // ***** GET ALL Curriculum Types by Archive Status *****
        // <baseurl/api/curriculumTypes/archive/
        [HttpGet("archive/{Status}")]
        public IActionResult GetStatus(bool Status)
        {
            var curriculumTypes = _context.CurriculumTypes
                .Where(c => c.Archived == Status)
                .ToList();
            if (curriculumTypes == null)
            {
                return NotFound();
            }
            return Ok(curriculumTypes);
        }


        // ***** GET A Curriculum Type by ID *****
        // <baseurl/api/curriculumTypes
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            var curriculumType = _context.CurriculumTypes
                .Where(c => c.Id == Id)
                .SingleOrDefault();

            return Ok(curriculumType);

        }

        // ***** ADD A Curriculum Type *****
        // POST /api/curriculumTypes
        [HttpPost]
        public IActionResult Post([FromBody] CurriculumType value)
        {
            _context.CurriculumTypes.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }

        // ***** UPDATE A Curriculum Type *****
        // PUT /api/curriculumTypes
        [HttpPut("{Id}")]
        public IActionResult Put(int Id, [FromBody] CurriculumType value)
        {
            var curriculumType = _context.CurriculumTypes.Where(c => c.Id == Id).SingleOrDefault();
            if (curriculumType == null)
            {
                return NotFound("Requested record not found.");
            }
            curriculumType.Name = value.Name;
            curriculumType.Abbreviation = value.Abbreviation;
            curriculumType.ChipColor = value.ChipColor;
            curriculumType.TextColor = value.TextColor;
    
            _context.CurriculumTypes.Update(curriculumType);
            _context.SaveChanges();
            return StatusCode(201, curriculumType);
        }

        // ***** PATCH A Curriculum Type's Archived status*****
        // PATCH /api/curriculumTypes
        [HttpPatch("{Id}")]
        public IActionResult Patch(int Id, [FromBody] CurriculumType value)
        {
            var curriculumType = _context.CurriculumTypes.Where(c => c.Id == Id).SingleOrDefault();
            if (curriculumType == null)
            {
                return NotFound("Requested record not found.");
            }

            curriculumType.Archived = value.Archived;

            _context.CurriculumTypes.Update(curriculumType);
            _context.SaveChanges();
            return StatusCode(201, curriculumType);
        }

        // ***** DELETE A Curriculum Type *****
        // **** NOT TO BE USED IN GENERAL SETTING 
        // DELETE /api/curriculumType
        [HttpDelete("{Id}"), Authorize]
        public IActionResult Delete(int Id)
        {

            var curriculumType = _context.CurriculumTypes.Where(c => c.Id == Id).SingleOrDefault();
            if (curriculumType == null)
            {
                return NotFound("Requested record not found.");
            }

            _context.CurriculumTypes.Remove(curriculumType);
            _context.SaveChanges();
            return StatusCode(204, curriculumType);
        }
    }
}

