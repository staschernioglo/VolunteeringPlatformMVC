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
    public class GoodDeedAPI : API, IGoodDeedAPI
    {
        public GoodDeedAPI(IUnitOfWork database) : base(database)
        {
        }

        static internal GoodDeedDTO ConvertToDTO(GoodDeed goodDeed)
        {
            if (goodDeed == null)
                return null;
            return new GoodDeedDTO
            {
                Id = goodDeed.Id,
                Name = goodDeed.Name,
                Category = goodDeed.Category,
                Description = goodDeed.Description,
                SimpleUserId = goodDeed.SimpleUserId,
                Date = goodDeed.Date,
                Town = goodDeed.Town,
                Address = goodDeed.Address,
                PhoneNumber = goodDeed.PhoneNumber,
                RequiredNumberOfVolunteers = goodDeed.RequiredNumberOfVolunteers,
                NumberOfParticipatingVolunteers = goodDeed.NumberOfParticipatingVolunteers,
                SimpleUser = goodDeed.SimpleUser
            };
        }

        public IEnumerable<GoodDeedDTO> GetAllGoodDeeds()
        {
            return Database.GoodDeeds.GetAll().ToList().ConvertAll(ConvertToDTO);
        }

        public GoodDeedDTO GetGoodDeed(int goodDeedId)
        {
            return ConvertToDTO(Database.GoodDeeds.Get(goodDeedId));
        }
    }
}
