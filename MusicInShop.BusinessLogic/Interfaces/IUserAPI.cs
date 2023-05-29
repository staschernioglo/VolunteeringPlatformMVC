using MusicInShop.BusinessLogic.DataTransfer;
using MusicInShop.BusinessLogic.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicInShop.BusinessLogic.Interfaces
{
    public interface IUserAPI
    {
        Result Login(UserDTO userDTO);
        Result Register(UserDTO userDTO, string imageUrl, string directory);
        void AddToCart(string email, int productId, int? quantity = null);
        void RemoveFromCart(string email, int productId);
        void DecrementFromCart(string email, int productId);
        UserDTO GetUser(string email);
        void AddProject(ProjectDTO projectDTO, string imageUrl, string directory);
        void DeleteProject(int projectId, string directory);
        void AddGoodDeed(GoodDeedDTO goodDeedDTO, string imageUrl, string directory);
        void DeleteGoodDeed(int goodDeedId, string directory);
        IEnumerable<UserDTO> GetAllUsers();
        void ParticipateInProject(string email, int projectId, int status = 0);
        void CancelParticipation(int id);
        void ConfirmParticipant(int id);
        void DeleteParticipant(int id);
    }
}