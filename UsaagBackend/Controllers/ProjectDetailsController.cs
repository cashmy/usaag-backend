using UsaagBackend.Data;
using UsaagBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace UsaagBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectDetailsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProjectDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ***** GET ALL Details for a Project *****
        // <baseurl/api/ProjectDetail/<headerId>
        [HttpGet("{ProjectId}")]
        public IActionResult Get(int ProjectId)
        {
            var projectDetails = _context.ProjectDetails
                .Where(pd => pd.ProjectId == ProjectId)
                .ToList();
            if (projectDetails == null)
            {
                return NotFound();
            }
            return Ok(projectDetails);
        }

        // ***** ADD A Detail for a PRoject *****
        // DOES NOT COPY FROM TEMPLATE DETAIL!
        // POST /api/projectDetails/
        [HttpPost]
        public IActionResult Post([FromBody] ProjectDetails value)
        {
            // TODO: Handle the Id auto increment (by 10) here

            _context.ProjectDetails.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }

        // ***** UPDATE A TemplateDetail *****
        // PUT /api/templateDetail/<headerId>/<id>
        [HttpPut("{ProjectId}/{Id}")]
        public IActionResult Put(int ProjectId, int Id, [FromBody] ProjectDetails value)
        {
            var projectDetail = _context.ProjectDetails
                .Where(td => td.ProjectId == ProjectId && td.Id == Id)
                .SingleOrDefault();
            if (projectDetail == null)
            {
                return NotFound("Requested record not found.");
            }
            projectDetail.Title = value.Title;
            projectDetail.Description = value.Description;
            projectDetail.PointValue = value.PointValue;
            projectDetail.BonusStatus = value.BonusStatus;
            projectDetail.Status = value.Status;
            projectDetail.PercentComplete = value.PercentComplete;
            projectDetail.GradingScript = value.GradingScript;
            projectDetail.PointsScored = value.PointsScored;
            projectDetail.StartedTimeStamp = value.StartedTimeStamp;
            projectDetail.CompletedTimeStamp = value.CompletedTimeStamp;

            // Foreign Key Field(s) - This is optional
            projectDetail.StudentId = value.StudentId;

            _context.ProjectDetails.Update(projectDetail);
            _context.SaveChanges();
            return StatusCode(201, projectDetail);
        }


        // ***** DELETE A Project Detail *****
        // DELETE /api/projectDetail/<projectId>/<id>
        [HttpDelete("{ProjectId}/{Id}")]
        public IActionResult Delete(int ProjectId, int Id)
        {

            var projectDetail = _context.ProjectDetails
                .Where(td => td.ProjectId == ProjectId && td.Id == Id)
                .SingleOrDefault();
            if (projectDetail == null)
            {
                return NotFound("Requested record not found.");
            }

            _context.ProjectDetails.Remove(projectDetail);
            _context.SaveChanges();
            return StatusCode(204, projectDetail);
        }
    }
}
