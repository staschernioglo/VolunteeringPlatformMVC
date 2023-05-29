using MusicInShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicInShop.BusinessLogic.DataTransfer
{
    public class ProjectDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int OrganizationId { get; set; }
        public virtual User Organization { get; set; }
        public string Date { get; set; }
        public string Town { get; set; }
        public string Address { get; set; }
        public int RequiredNumberOfVolunteers { get; set; }
        public int NumberOfParticipatingVolunteers { get; set; }
    }
}
