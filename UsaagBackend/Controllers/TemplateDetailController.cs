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

        // ***** GET ALL TemplateDetails for a Header by Bonus *****
        // <baseurl/api/templateDetail/<headerId>/<status>
        [HttpGet("{HeaderId}/{Status}")]
        public IActionResult GetByBonus(int HeaderId, bool Status)
        {
            var templateDetails = _context.TemplateDetail
                .Where(td => td.HeaderId == HeaderId && td.BonusStatus == Status)
                .ToList();
            if (templateDetails == null)
            {
                return NotFound();
            }
            return Ok(templateDetails);
        }

        // ***** ADD A Template Detail for a Header *****
        // POST /api/templateDetail/
        [HttpPost]
        public  IActionResult Post([FromBody]TemplateDetail value) 
        {
            var templateDetails = _context.TemplateDetail
                .Where(td => td.HeaderId == value.HeaderId)
                .ToList();

            if (templateDetails.Count == 0)
            {
                value.Id = 1;
            } 
            else
            {
            // TODO: Handle the Id auto increment here
                var lastTmpDtlRcd = _context.TemplateDetail
                    .Where(td => td.HeaderId == value.HeaderId)
                    .OrderBy(td => td.Id)
                    .Last();

                value.Id = lastTmpDtlRcd.Id + 1;
            }
 
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

        // ***** RESEQUENCE TemplateDetail for a Header *****
        // POST /api/templateDetail/<headerId>
        [HttpPost("{HeaderId}")]
        public IActionResult Post(int HeaderId, [FromBody] TemplateDetail[] tmpDtls)
        {

            // First remove all details records
            var templateDetails = _context.TemplateDetail
                .Where(td => td.HeaderId == HeaderId)
                .ToList();
            if (templateDetails == null)
            {
                return NotFound();
            }

            foreach (var templateDetail in templateDetails)
            {
                _context.TemplateDetail.Remove(templateDetail);
                _context.SaveChanges();
            }

           // Now add detail records in the order given
           TemplateDetail newTemplateDetail = new TemplateDetail();
           int Id = 1;

            foreach (TemplateDetail value in tmpDtls)
            {
                newTemplateDetail.HeaderId = HeaderId;
                newTemplateDetail.Id = Id++;
                newTemplateDetail.Title = value.Title;
                newTemplateDetail.Description = value.Description;
                newTemplateDetail.PointValue = value.PointValue;
                newTemplateDetail.BonusStatus = value.BonusStatus;
                newTemplateDetail.GreyHighlight = value.GreyHighlight;

                _context.TemplateDetail.Add(newTemplateDetail);
                _context.SaveChanges();
            }

            // Return status update
            return StatusCode(207, "Resequenced " + tmpDtls.Count().ToString() + " records" );
        }
    }
}
