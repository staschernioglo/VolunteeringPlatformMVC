using MusicInShop.BusinessLogic.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicInShop.Web.Models
{
    public class ParticipatingVolunteersModel : NavbarModel
    {
        public IEnumerable<ProjectVolunteerDTO> ProjectVolunteers { get; set; }
    }
}