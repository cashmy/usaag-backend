using System.ComponentModel.DataAnnotations.Schema;

namespace UsaagBackend.Models
{
    public class Teams
    {
        public int Id { get; set; }

        [ForeignKey("Cohorts")]
        public int CohortId { get; set; }
        public Cohorts Cohorts { get; set; }

        [ForeignKey("TemplateHeader")]
        public int HeaderId { get; set; }
        public TemplateHeader TemplateHeader { get; set; }

        public string Name { get; set; }
        public bool Group { get; set; }
        public bool AutoGenName { get; set; }
        public string GitHubRepository { get; set; }
        public string TeamTrelloBoard { get; set; }
    }
}
