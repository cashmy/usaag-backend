using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsaagBackend.Models
{
    public class ProjectDetails
    {
        [Key, Column(Order = 1)]
        [ForeignKey("Projects")]
        public int ProjectId { get; set; }
        public ProjectHeader ProjectHeader { get; set; }

        [Key, Column(Order = 2)]
        public int Id { get; set; }


        public string Title { get; set; }
        [StringLength(256)]
        public string Description { get; set; }
        public int PointValue { get; set; }
        public bool BonusStatus { get; set; }

        public char Status { get; set; }    // Color status for R,O,Y,Lg,G
        public int PercentComplete { get; set; } // Four options only: 0, 25 50 75, 100


        // ** Future use attributes
        public string GradingScript { get; set; }
        public float PointsScored { get; set; }
        
        // Optional FK for Divide and Conquer team work methodology
        [ForeignKey("Students")]
        public int? StudentId { get; set; }
        public Students Students { get; set; }

        public DateTime StartedTimeStamp { get; set; }
        public DateTime CompletedTimeStamp { get; set; }

    }
}
