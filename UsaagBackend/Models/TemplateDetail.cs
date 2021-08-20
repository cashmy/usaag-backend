using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsaagBackend.Models
{
    public class TemplateDetail
    {
        // Add foreign Key for Template Header
        [Key, Column(Order = 1)]
        [ForeignKey("TemplateHeader")]
        public int HeaderId { get; set; }
        public TemplateHeader TemplateHeader { get; set; }

        // May need to change this to "Sequence" concept so that autoinc happens only within HeaderId
        [Key, Column(Order = 2)]
        public int Id { get; set; }


        public string Title { get; set; }
        public string Description { get; set; }
        public int PointValue { get; set; }
        public bool BonusStatus { get; set; }
        public bool GreyHighlight { get; set; }
    }
}
