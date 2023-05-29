using MusicInShop.Domain.Contexts;
using MusicInShop.Domain.Entities;
using MusicInShop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicInShop.Domain.Repositories
{
    class ProjectVolunteerRepository : IRepository<ProjectVolunteer>
    {
        DataContext db;

        public ProjectVolunteerRepository(DataContext db)
        {
            this.db = db;
        }

        public void Create(ProjectVolunteer item)
        {
            db.ProjectVolunteers.Add(item);
        }

        public void Delete(ProjectVolunteer item)
        {
            if (item != null)
                db.ProjectVolunteers.Remove(item);
        }

        public void DeleteById(int id)
        {
            Delete(Get(id));
        }

        public IEnumerable<ProjectVolunteer> Find(Func<ProjectVolunteer, bool> predicate)
        {
            return db.ProjectVolunteers.Where(predicate);
        }

        public ProjectVolunteer FindFirst(Func<ProjectVolunteer, bool> predicate)
        {
            return db.ProjectVolunteers.FirstOrDefault(predicate);
        }

        public ProjectVolunteer Get(int id)
        {
            return db.ProjectVolunteers.Find(id);
        }

        public IEnumerable<ProjectVolunteer> GetAll()
        {
            return db.ProjectVolunteers.Include("Volunteer").Include("Project").ToList();
        }

        public void Update(ProjectVolunteer item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
