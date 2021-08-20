using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsaagBackend.Models
{
    public class ProjectTeams
    {
        [Key, Column(Order = 1)]
        [ForeignKey("Projects")]
        public int ProjectId { get; set; }
        public Projects Projects { get; set; }

        [Key, Column(Order = 2)]
        [ForeignKey("Teams")]
        public int TeamId { get; set; }
        public Teams Teams { get; set; }

        // ** Future use attributes
        public float TotalPointsScored { get; set; }
        public float TotalWeightedPointsScored { get; set; }
        public bool ProjectSubmitted { get; set; }

    }
}
