using MusicInShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicInShop.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<Product> Products { get; }
        IRepository<Project> Projects { get; }
        IRepository<GoodDeed> GoodDeeds { get; }
        IRepository<CartProduct> CartProducts { get; }
        IRepository<ProjectVolunteer> ProjectVolunteers { get; }
        void Save();
    }
}
