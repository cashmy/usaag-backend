using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsaagBackend.Models
{
    public class CurriculumThemes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TechnologyStack { get; set; }
        public int NumberOfWeeks { get; set; }
        public bool DayTimeStatus { get; set; }
    }
}
