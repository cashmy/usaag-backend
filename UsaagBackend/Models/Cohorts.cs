
using System.ComponentModel.DataAnnotations;

namespace UsaagBackend.Models
{
    public class Cohorts
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string SlackChannel { get; set; }
        public bool? Archived { get; set; }
        public string CPKColor { get; set; }
        public string TextColor { get; set; }

        [StringLength(3)]
        public string Abbreviation { get; set; }
    }
}
