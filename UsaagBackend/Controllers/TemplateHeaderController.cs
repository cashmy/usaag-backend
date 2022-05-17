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
                .OrderBy(th => th.Name)
                .ThenByDescending(th => th.VersionMain.ToString() + th.VersionMinor.ToString() + th.VersionSub.ToString())
                .ToList();
            if (templateHeaders.Count <= 0)
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

        // ***** GET Latest Recent Version by Name & Abbrev
        // <baseurl>/api/templateHeader/version
        [HttpGet("version/{Name}/{Abbreviation}")]
        public IActionResult GetHdrByName(string Name, string Abbreviation)
        {
            // TODO Refactor to find Latest Version number
            var templateHeader = _context.TemplateHeader
                .Where(th => th.Name == Name && th.Abbreviation == Abbreviation)
                .OrderByDescending(th => th.VersionMain.ToString() + th.VersionMinor.ToString() + th.VersionSub.ToString() )
                .FirstOrDefault();
            return Ok(templateHeader);
        }

        // ***** GET A Template Header & All Detail by ID *****
        // <baseurl/api/templateheader
        [HttpGet("full/{Id}")]
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

        // ***** COPY A Template: Header & Detail *****
        // PATCH /api/templateheader/copy
        [HttpPatch("copy/{Id}/{Archive}")]
        public IActionResult Patch(int Id, bool Archive, [FromBody] TemplateHeader versionInfo)
        {
            // Get existing header to copy
            var templateHeader = _context.TemplateHeader.Where(th => th.Id == Id).SingleOrDefault();
            if (templateHeader == null)
            {
                return NotFound("Requested record not found.");
            }
            // Archive current record is requested
            if (Archive)
            {
                templateHeader.Archived = true;
                // templateHeader.NewVersion = true;
                _context.Update(templateHeader);
                _context.SaveChanges();
            }
            // Setup new record with incoming version info
            var newTemplateHeader = templateHeader;
            newTemplateHeader.Id = 0;
            newTemplateHeader.VersionMain = versionInfo.VersionMain;
            newTemplateHeader.VersionMinor = versionInfo.VersionMinor;
            newTemplateHeader.VersionSub = versionInfo.VersionSub;
            newTemplateHeader.Archived = false;
            // netTemplateHeader.NewVersion = false;
            

            // Add new record
            _context.TemplateHeader.Add(newTemplateHeader);
            _context.SaveChanges();

            // Save New ID for Details
            var newHeaderId = newTemplateHeader.Id;

            // Retrieve all Details for old record and copy to new Header record.
            var templateDetail = _context.TemplateDetail
                .Where(cd => cd.HeaderId == Id)
                .ToList();
            if (templateDetail.Count <= 0)
            {
                return StatusCode(207, "Header Copied - No details found");
            }

            foreach (var td in templateDetail)
            {
                td.HeaderId = newHeaderId;
                _context.TemplateDetail.Add(td);
                _context.SaveChanges(true);
            }

            return StatusCode(207, "Template Header & All Details copies");
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
