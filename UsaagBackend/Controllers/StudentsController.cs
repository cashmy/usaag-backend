using UsaagBackend.Data;
using UsaagBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace UsaagBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ***** GET ALL Students *****
        // <baseurl/api/students
        [HttpGet]
        public IActionResult Get()
        {
            var students = _context.Students.ToList();
            if (students == null)
            {
                return NotFound();
            }
            return Ok(students);
        }

        // ***** GET ALL Students by Archive Status *****
        // <baseurl/api/students
        [HttpGet("archive/{Status}")]
        public IActionResult GetStatus(bool Status)
        {
            var students = _context.Students
                .Where(s => s.Archived == Status)
                .ToList();
            if (students == null)
            {
                return NotFound();
            }
            return Ok(students);
        }

        // ***** GET ALL Unassigned Students *****
        // <baseurl/api/students/unassigned
        [HttpGet("unassigned")]
        public IActionResult GetUnassigned()
        {
            var students = _context.Students.ToList()
                .Where(s => s.CohortId == null); 

            if (students == null)
            {
                return NotFound();
            }
            return Ok(students);
        }

            // ***** GET A Student by ID *****
            // <baseurl/api/students
            [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            var student = _context.Students
                .Where(s => s.Id == Id)
                .SingleOrDefault();
            return Ok(student);
        }

        // ***** ADD A Student *****
        // POST /api/students
        [HttpPost]
        public IActionResult Post([FromBody]Students value)
        {
            _context.Students.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }


        // ***** UPDATE A Student *****
        // PUT /api/students
        [HttpPut("{Id}")]
        public IActionResult Put(int Id, [FromBody] Students value)
        {
            var student = _context.Students.Where(s => s.Id == Id).SingleOrDefault();
            if (student == null)
            {
                return NotFound("Requested record not found.");
            }
            // Data fields
            student.FirstName = value.FirstName;
            student.LastName = value.LastName;
            student.InstructorSlackChannel = value.InstructorSlackChannel;
            student.CohortId = value.CohortId;
            student.Archived = value.Archived;

            _context.Students.Update(student);
            _context.SaveChanges();
            return StatusCode(201, student);
        }


        // ***** DELETE A Student *****
        // DELETE /api/students
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {

            var student = _context.Students.Where(s => s.Id == Id).SingleOrDefault();
            if (student == null)
            {
                return NotFound("Requested record not found.");
            }

            _context.Students.Remove(student);
            _context.SaveChanges();
            return StatusCode(204, student);
        }
    }
}
