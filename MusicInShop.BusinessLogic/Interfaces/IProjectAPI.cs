using MusicInShop.BusinessLogic.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicInShop.BusinessLogic.Interfaces
{
    public interface IProjectAPI
    {
        IEnumerable<ProjectDTO> GetAllProjects();
        ProjectDTO GetProject(int projectId);
    }
}
