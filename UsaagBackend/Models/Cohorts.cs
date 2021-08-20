using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsaagBackend.Models
{
    public class Cohorts
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SlackChannel { get; set; }
        public bool? Archived { get; set; }

    }
}
