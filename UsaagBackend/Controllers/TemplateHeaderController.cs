using UsaagBackend.Data;
using UsaagBackend.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace UsaagBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateHeaderController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TemplateHeaderController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ***** GET ALL Template Headers *****
        // <baseurl/api/templateheader
        [HttpGet("archive/{Status}")]
        public IActionResult Get(bool Status)
        {
            var templateHeaders = _context.TemplateHeader
                .Where(th => th.Archived == Status)
                .ToList();
            if (templateHeaders == null)
            {
                return NotFound();
            }
            return Ok(templateHeaders);
        }

        // ***** GET A Template Header by ID *****
        // <baseurl/api/templateheader
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            var templateHeaders = _context.TemplateHeader
                .Where(th => th.Id == Id)
                .SingleOrDefault();

            return Ok(templateHeaders);
        }

        // ***** GET A Template Header by a specific Version
        // <baseurl>/api/templateHeader/version
        [HttpGet("{Id}/version/{Main}/{Minor}/{Sub}")]
        public IActionResult GetHdrBySpecVers(int Id, int Main, int Minor, int Sub)
        {
            var templateHeader = _context.TemplateHeader
                .Where(th => th.Id == Id && th.VersionMain == Main && th.VersionMinor == Minor && th.VersionSub == Sub)
                .SingleOrDefault();
            return Ok(templateHeader);
        }

        // ***** GET A Template Header by most Recent Version
        // <baseurl>/api/templateHeader/version
        [HttpGet("/version")]
        public IActionResult GetHdrByVers()
        {
            // TODO Refactor to find Latest Version number
            var templateHeader = _context.TemplateHeader
                .Where(th => th.VersionMain <= 99)
                .SingleOrDefault();
            return Ok(templateHeader);
        }

        // ***** GET A Template Header & All Detail by ID *****
        // <baseurl/api/templateheader
        [HttpGet("/full/{Id}")]
        public IActionResult GetHdrDtlId(int Id)
        {
            var templateHeaders = _context.TemplateHeader
                .Where(th => th.Id == Id)
                .SingleOrDefault();

            // TODO Get all Detail records and structure into a JSON Object to return

            return Ok(templateHeaders);
        }

        // ***** ADD A TemplateHeader *****
        // POST /api/templateheader
        [HttpPost]
        public IActionResult Post([FromBody] TemplateHeader value)
        {
            _context.TemplateHeader.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }

        // ***** UPDATE A TemplateHeader *****
        // PUT /api/templateHeader
        [HttpPut("{Id}")]
        public IActionResult Put(int Id, [FromBody] TemplateHeader value)
        {
            var templateHeader = _context.TemplateHeader.Where(th => th.Id == Id).SingleOrDefault();
            if (templateHeader == null)
            {
                return NotFound("Requested record not found.");
            }
            templateHeader.Name = value.Name;
            templateHeader.Goal = value.Goal;
            templateHeader.SpecialNotes = value.SpecialNotes;
            templateHeader.TotalPoints = value.TotalPoints;
            templateHeader.TotalWeightedPoints  = value.TotalWeightedPoints;
            templateHeader.VersionMain = value.VersionMain;
            templateHeader.VersionMinor = value.VersionMinor;
            templateHeader.VersionSub = value.VersionSub;
            templateHeader.NotionScript = value.NotionScript;
            templateHeader.Abbreviation = value.Abbreviation;
            templateHeader.TechnologyStack = value.TechnologyStack;
            templateHeader.Archived = value.Archived;

            _context.TemplateHeader.Update(templateHeader);
            _context.SaveChanges();
            return StatusCode(201, templateHeader);
        }

        // ***** PATCH A TemplateHeader archived status*****
        // PATCH /api/templateHeader
        [HttpPatch("{Id}")]
        public IActionResult Patch(int Id, [FromBody] TemplateHeader value)
        {
            var templateHeader = _context.TemplateHeader.Where(c => c.Id == Id).SingleOrDefault();
            if (templateHeader == null)
            {
                return NotFound("Requested record not found.");
            }

            templateHeader.Archived = value.Archived;

            _context.TemplateHeader.Update(templateHeader);
            _context.SaveChanges();
            return StatusCode(201, templateHeader);
        }

        // ***** DELETE A Template Header *****
        // DELETE /api/templateHeader
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            // Cascade dekete for Template details is on by default
            var templateHeader = _context.TemplateHeader.Where(th => th.Id == Id).SingleOrDefault();
            if (templateHeader == null)
            {
                return NotFound("Requested record not found.");
            }

            _context.TemplateHeader.Remove(templateHeader);
            _context.SaveChanges();
            return StatusCode(204, templateHeader);
        }
    }
}
