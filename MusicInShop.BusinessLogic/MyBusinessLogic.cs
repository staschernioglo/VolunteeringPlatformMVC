using MusicInShop.BusinessLogic.API;
using MusicInShop.BusinessLogic.Interfaces;
using MusicInShop.Domain;
using MusicInShop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicInshop.BusinessLogic
{
    public class MyBusinessLogic
    {
        public MyBusinessLogic()
        {
            Database = new UnitOfWork("MusicInShop");
        }

        IUnitOfWork Database { get; }

        IUserAPI userAPI;
        IProductAPI productAPI;
        IAdminAPI adminAPI;
        IProjectAPI projectAPI;
        IGoodDeedAPI goodDeedAPI;
        IProjectVolunteerAPI projectVolunteerAPI;

        public IUserAPI UserAPI
        {
            get
            {
                if (userAPI == null)
                    userAPI = new UserAPI(Database);
                return userAPI;
            }
        }
        public IProductAPI ProductAPI
        {
            get
            {
                if (productAPI == null)
                    productAPI = new ProductAPI(Database);
                return productAPI;
            }
        }

        public IProjectAPI ProjectAPI
        {
            get
            {
                if (projectAPI == null)
                    projectAPI = new ProjectAPI(Database);
                return projectAPI;
            }
        }

        public IGoodDeedAPI GoodDeedAPI
        {
            get
            {
                if (goodDeedAPI == null)
                    goodDeedAPI = new GoodDeedAPI(Database);
                return goodDeedAPI;
            }
        }

        public IProjectVolunteerAPI ProjectVolunteerAPI
        {
            get
            {
                if (projectVolunteerAPI == null)
                    projectVolunteerAPI = new ProjectVolunteerAPI(Database);
                return projectVolunteerAPI;
            }
        }

        public IAdminAPI AdminAPI
        {
            get
            {
                if (adminAPI == null)
                    adminAPI = new AdminAPI(Database);
                return adminAPI;
            }
        }
    }
}