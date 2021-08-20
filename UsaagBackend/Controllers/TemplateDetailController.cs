using UsaagBackend.Data;
using UsaagBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace UsaagBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateDetailController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TemplateDetailController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ***** GET ALL TemplateDetails for a Header *****
        // <baseurl/api/templateDetail/<headerId>
        [HttpGet("{HeaderId}")]
        public IActionResult Get(int HeaderId)
        {
            var templateDetails = _context.TemplateDetail
                .Where(td => td.HeaderId == HeaderId)
                .ToList();
            if (templateDetails == null)
            {
                return NotFound();
            }
            return Ok(templateDetails);
        }

        // ***** ADD A Template Deatil for a Header *****
        // POST /api/templateDetail/
        [HttpPost]
        public  IActionResult Post([FromBody]TemplateDetail value) 
        {

            // TODO: Handle the Id auto increment (by 10) here

            _context.TemplateDetail.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);

        }

        // ***** UPDATE A TemplateDetail *****
        // PUT /api/templateDetail/<headerId>/<id>
        [HttpPut("{HeaderId}/{Id}")]
        public IActionResult Put(int HeaderId, int Id, [FromBody] TemplateDetail value)
        {
            var templateDetail = _context.TemplateDetail
                .Where(td => td.HeaderId == HeaderId && td.Id == Id)
                .SingleOrDefault();
            if (templateDetail == null)
            {
                return NotFound("Requested record not found.");
            }
            templateDetail.Title = value.Title;
            templateDetail.Description = value.Description;
            templateDetail.PointValue = value.PointValue;
            templateDetail.BonusStatus = value.BonusStatus;
            templateDetail.GreyHighlight = value.GreyHighlight;


            _context.TemplateDetail.Update(templateDetail);
            _context.SaveChanges();
            return StatusCode(201, templateDetail);
        }

        // ***** DELETE A TemplateDetail *****
        // DELETE /api/templateDetail/<headerId>/<id>
        [HttpDelete("{HeaderId}/{Id}")]
        public IActionResult Delete(int HeaderId, int Id)
        {

            var templateDetail = _context.TemplateDetail
                .Where(td => td.HeaderId == HeaderId && td.Id == Id)
                .SingleOrDefault();
            if (templateDetail == null)
            {
                return NotFound("Requested record not found.");
            }

            _context.TemplateDetail.Remove(templateDetail);
            _context.SaveChanges();
            return StatusCode(204, templateDetail);
        }

    }
}
