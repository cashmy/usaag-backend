using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsaagBackend.Models
{
    public class Projects
    {
        public int Id { get; set; }
        [ForeignKey("Cohorts")]
        public int CohortId { get; set; }
        public Cohorts Cohorts { get; set; }

        public string Name { get; set; }
        public float TotalPoints { get; set; }
        public float TotalWeightedPoints { get; set; }
        public DateTime? DateAssigned { get; set; }
        public DateTime? DateDue { get; set; }
        public char Status { get; set; }
        public string TemplateVersionUsed { get; set; }

    }
}
