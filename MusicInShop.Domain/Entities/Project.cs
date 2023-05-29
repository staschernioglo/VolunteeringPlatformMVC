using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicInShop.Domain.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int OrganizationId { get; set; }
        public string Date { get; set; }
        public string Town { get; set; }
        public string Address { get; set; }
        public int RequiredNumberOfVolunteers { get; set; }
        public int NumberOfParticipatingVolunteers { get; set; }

        public virtual User Organization { get; set; }
        public virtual ICollection<ProjectVolunteer> ProjectVolunteers { get; set; }
    }
}
