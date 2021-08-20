using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace UsaagBackend.Models
{
    public class ProjectHeader
    {
        public int Id { get; set; }

        [ForeignKey("TemplateHeader")]
        public int HeaderId { get; set; }
        public TemplateHeader TemplateHeader { get; set; }

        [ForeignKey("Cohorts")]
        public int CohortId { get; set; }
        public Cohorts Cohorts { get; set; }

        public float TotalPoints { get; set; }
        public float TotalWeightedPoints { get; set; }
        public DateTime DateAssigned { get; set; }
        public DateTime DateDue { get; set; }
        public char Status { get; set; }
    }
}
