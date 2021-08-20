using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
