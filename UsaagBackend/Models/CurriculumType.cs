using System.ComponentModel.DataAnnotations;

namespace UsaagBackend.Models
{
    public class CurriculumType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [StringLength(4)]
        public string Abbreviation { get; set; }
        public bool? Archived { get; set; }
        public string ChipColor { get; set; }
        public string TextColor { get; set; }

    }
}

