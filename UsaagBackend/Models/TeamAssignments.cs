using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsaagBackend.Models
{
    public class TeamAssignments
    {
        [ForeignKey("Teams")]
        public int TeamId { get; set; }
        public Teams Teams { get; set; }

        [ForeignKey("Students")]
        public int StudentId { get; set; }
        public Students Students { get; set; }

    }
}
