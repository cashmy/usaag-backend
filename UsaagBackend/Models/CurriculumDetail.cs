using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsaagBackend.Models
{
    public class CurriculumDetail
    {
        [ForeignKey("CurriculumThemes")]
        public int ThemeId { get; set; }
        public CurriculumThemes CurriculumThemes{ get; set; }

        public int Id { get; set; }

        [ForeignKey("TemplateHeader")]
        public int? HeaderId { get; set; }
        public TemplateHeader TemplateHeader { get; set; }

        public int AssignmentSequence { get; set; }
        public int DayToAssign { get; set; }
        public int ProjectDays { get; set; }

        public string LectureTopics { get; set; }
        public string Notes { get; set; }

        [ForeignKey("CurriculumType")]
        public int CurrTypeId { get; set; }
        public CurriculumType CurriculumType { get; set; }

    }
}
