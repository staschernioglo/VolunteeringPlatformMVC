using MusicInShop.BusinessLogic.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicInShop.BusinessLogic.Interfaces
{
    public interface IProjectVolunteerAPI
    {
        IEnumerable<ProjectVolunteerDTO> GetAllProjectVolunteers();
        IEnumerable<ProjectVolunteerDTO> GetProjectVolunteersById(int projectId);
        IEnumerable<ProjectVolunteerDTO> GetProjectVolunteersByEmail(string email);
    }
}
