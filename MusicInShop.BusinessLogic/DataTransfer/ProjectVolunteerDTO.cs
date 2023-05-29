using MusicInShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicInShop.BusinessLogic.DataTransfer
{
    public class ProjectVolunteerDTO
    {
        public int Id { get; set; }
        public int VolunteerId { get; set; }
        public int ProjectId { get; set; }
        public int Status { get; set; }
        public virtual User Volunteer { get; set; }
        public virtual Project Project { get; set; }
    }
}
