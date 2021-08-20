using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UsaagBackend.Models
{
    public class Teams
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Group { get; set; }
        public bool AutoGenName { get; set; }
        public string GitHubRepository { get; set; }
        public string TeamTrelloBoard { get; set; }
    }
}
