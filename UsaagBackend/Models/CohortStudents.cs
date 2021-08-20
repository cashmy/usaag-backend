using System.ComponentModel.DataAnnotations.Schema;

namespace UsaagBackend.Models
{
    public class CohortStudents
    {
        [ForeignKey("Cohorts")]
        public int CohortId { get; set; }
        public Cohorts Cohorts { get; set; }

        [ForeignKey("Students")]
        public int StudentId { get; set; }
        public Students Students { get; set; }
    }
}
