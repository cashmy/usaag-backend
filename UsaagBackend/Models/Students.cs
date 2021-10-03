using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsaagBackend.Models
{
    public class Students
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string InstructorSlackChannel { get; set; }
        public bool? Archived { get; set; }

        [ForeignKey("Cohorts")]
        public int? CohortId { get; set; }
        public Cohorts Cohorts { get; set; }
    }
}
