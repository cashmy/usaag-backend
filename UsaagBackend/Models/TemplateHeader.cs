using System.ComponentModel.DataAnnotations;


namespace UsaagBackend.Models
{
    public class TemplateHeader
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [StringLength(6)]
        public string Abbreviation { get; set; }
        public string TechnologyStack { get; set; }
        
        public string Goal { get; set; }

        public string SpecialNotes {get; set;}
        public float TotalPoints { get; set; }
        public float TotalWeightedPoints { get; set; }

        public bool? Archived { get; set; }

        // Version Format 0.0.0 (Main.Minor.Sub)
        public int VersionMain { get; set; }
        public int VersionMinor { get; set; }
        public int VersionSub { get; set; }

        // ** Future use attributes
        public string NotionScript { get; set; } // Script to submit to Notion for Grading Cards
    }
}
