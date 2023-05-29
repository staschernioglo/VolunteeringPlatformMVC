using MusicInShop.BusinessLogic.DataTransfer;
using MusicInShop.BusinessLogic.Interfaces;
using MusicInShop.Domain.Entities;
using MusicInShop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicInShop.BusinessLogic.API
{
    public class ProjectAPI : API, IProjectAPI
    {
        public ProjectAPI(IUnitOfWork database) : base(database)
        {
        }

        static internal ProjectDTO ConvertToDTO(Project project)
        {
            if (project == null)
                return null;
            return new ProjectDTO
            {
                Id = project.Id,
                Name = project.Name,
                Category = project.Category,
                Description = project.Description,
                OrganizationId = project.OrganizationId,
                Date = project.Date,
                Town = project.Town,
                Address = project.Address,
                RequiredNumberOfVolunteers = project.RequiredNumberOfVolunteers,
                NumberOfParticipatingVolunteers = project.NumberOfParticipatingVolunteers,
                Organization = project.Organization
            };
        }

        public IEnumerable<ProjectDTO> GetAllProjects()
        {
            return Database.Projects.GetAll().ToList().ConvertAll(ConvertToDTO);
        }

        public ProjectDTO GetProject(int projectId)
        {
            return ConvertToDTO(Database.Projects.Get(projectId));
        }
    }
}
