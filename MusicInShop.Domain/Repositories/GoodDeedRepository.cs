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
    public class GoodDeedRepository : IRepository<GoodDeed>
    {
        DataContext db;

        public GoodDeedRepository(DataContext db)
        {
            this.db = db;
        }

        public void Create(GoodDeed item)
        {
            db.GoodDeeds.Add(item);
        }

        public void Delete(GoodDeed item)
        {
            if (item != null)
            {
                //db.CartProducts.RemoveRange(item.CartProducts);
                db.GoodDeeds.Remove(item);
            }
        }

        public void DeleteById(int id)
        {
            Delete(Get(id));
        }

        public IEnumerable<GoodDeed> Find(Func<GoodDeed, bool> predicate)
        {
            return db.GoodDeeds.Where(predicate);
        }

        public GoodDeed FindFirst(Func<GoodDeed, bool> predicate)
        {
            return db.GoodDeeds.FirstOrDefault(predicate);
        }

        public GoodDeed Get(int id)
        {
            return db.GoodDeeds.Find(id);
        }

        public IEnumerable<GoodDeed> GetAll()
        {
            return db.GoodDeeds.Include("SimpleUser").ToList();
        }

        public void Update(GoodDeed item)
        {
            db.Entry(item).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
