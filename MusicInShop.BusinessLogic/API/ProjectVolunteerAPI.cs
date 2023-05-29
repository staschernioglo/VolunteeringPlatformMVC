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
    public class ProjectVolunteerAPI : API, IProjectVolunteerAPI
    {
        public ProjectVolunteerAPI(IUnitOfWork database) : base(database)
        {
        }

        static internal ProjectVolunteerDTO ConvertToDTO(ProjectVolunteer projectVolunteer)
        {
            if (projectVolunteer == null)
                return null;
            return new ProjectVolunteerDTO
            {
                Id = projectVolunteer.Id,
                ProjectId = projectVolunteer.ProjectId,
                VolunteerId = projectVolunteer.VolunteerId,
                Volunteer = projectVolunteer.Volunteer,
                Project = projectVolunteer.Project,
                Status = projectVolunteer.Status
            };
        }

        public IEnumerable<ProjectVolunteerDTO> GetAllProjectVolunteers()
        {
            return Database.ProjectVolunteers.GetAll().ToList().ConvertAll(ConvertToDTO);
        }

        public IEnumerable<ProjectVolunteerDTO> GetProjectVolunteersByEmail(string email)
        {
            return Database.ProjectVolunteers.GetAll().Where(x => x.Volunteer.Email == email).ToList().ConvertAll(ConvertToDTO);
        }

        public IEnumerable<ProjectVolunteerDTO> GetProjectVolunteersById(int projectId)
        {
            return Database.ProjectVolunteers.GetAll().Where(x => x.ProjectId == projectId).ToList().ConvertAll(ConvertToDTO);
        }
    }
}
