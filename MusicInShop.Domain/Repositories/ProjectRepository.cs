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
    public class ProjectRepository : IRepository<Project>
    {
        DataContext db;

        public ProjectRepository(DataContext db)
        {
            this.db = db;
        }

        public void Create(Project item)
        {
            db.Projects.Add(item);
        }

        public void Delete(Project item)
        {
            if (item != null)
            {
                //db.CartProducts.RemoveRange(item.CartProducts);
                db.ProjectVolunteers.RemoveRange(item.ProjectVolunteers);
                db.Projects.Remove(item);
            }
        }

        public void DeleteById(int id)
        {
            Delete(Get(id));
        }

        public IEnumerable<Project> Find(Func<Project, bool> predicate)
        {
            return db.Projects.Where(predicate);
        }

        public Project FindFirst(Func<Project, bool> predicate)
        {
            return db.Projects.FirstOrDefault(predicate);
        }

        public Project Get(int id)
        {
            return db.Projects.Find(id);
        }

        public IEnumerable<Project> GetAll()
        {
            return db.Projects.Include("Organization").ToList();
        }

        public void Update(Project item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
