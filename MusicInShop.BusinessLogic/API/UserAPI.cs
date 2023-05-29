using MusicInShop.BusinessLogic.DataTransfer;
using MusicInShop.BusinessLogic.Infrastructure;
using MusicInShop.BusinessLogic.Interfaces;
using MusicInShop.Domain.Entities;
using MusicInShop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MusicInShop.BusinessLogic.API
{
    public class UserAPI : API, IUserAPI
    {
        public UserAPI(IUnitOfWork database) : base(database)
        {
        }
        public Result Login(UserDTO userDTO)
        {
            var user = Database.Users.FindFirst(u => u.Email == userDTO.Email && u.Password == userDTO.Password);
            if (user == null)
            {
                return new Result { Succeeded = false, Message = "Неправильные данные для входа" };
            }
            return new Result { Succeeded = true };
        }

        public Result Register(UserDTO userDTO, string imageUrl, string directory)
        {
            var user = Database.Users.FindFirst(u => u.Email == userDTO.Email);
            if (user != null)
            {
                return new Result { Succeeded = false, Message = "Почта уже занята" };
            }
            user = new User
            {
                Name = userDTO.Name,
                LastName = userDTO.LastName,
                Email = userDTO.Email,
                Password = userDTO.Password,
                Role = userDTO.Role,
                Description = userDTO.Description,
                Town = userDTO.Town,
                Address = userDTO.Address,
                PhoneNumber = userDTO.PhoneNumber,
                BirthDate = userDTO.BirthDate,
                NumberOfParticipations = userDTO.NumberOfParticipations
            };
            Database.Users.Create(user);
            Database.Save();

            using (WebClient client = new WebClient())
            {
                client.DownloadFile(new Uri(imageUrl), directory + "/" + user.Id + ".jpg");
            }

            return new Result { Succeeded = true };
        }

        public void ParticipateInProject(string email, int projectId, int status = 0)
        {
            var user = Database.Users.FindFirst(u => u.Email == email);
            var project = Database.Projects.Get(projectId);
            if (user == null || project == null)
                return;
            var projectVolunteer = user.ProjectVolunteers.FirstOrDefault(p => p.Project.Id == projectId && p.VolunteerId == user.Id);
            if (projectVolunteer == null)
            {
                project.NumberOfParticipatingVolunteers++;
                projectVolunteer = new ProjectVolunteer { Project = project, Status = status };
                user.ProjectVolunteers.Add(projectVolunteer);
            }
            Database.Save();
        }

        public void AddToCart(string email, int productId, int? quantity = null)
        {
            //var user = Database.Users.FindFirst(u => u.Email == email);
            //var product = Database.Products.Get(productId);
            //if (user == null || product == null)
            //    return;
            //var cartProduct = user.CartProducts.FirstOrDefault(p => p.Product.Id == productId);
            //if (cartProduct == null)
            //{
            //    cartProduct = new CartProduct { Product = product, Quantity = quantity ?? 1 };
            //    user.CartProducts.Add(cartProduct);
            //}
            //else
            //{
            //    cartProduct.Quantity += quantity ?? 1;
            //}
            //Database.Save();
        }
        public void RemoveFromCart(string email, int productId)
        {
            //var user = Database.Users.FindFirst(u => u.Email == email);
            //var product = Database.Products.Get(productId);
            //if (user == null || product == null)
            //    return;
            //var cartProduct = user.CartProducts.FirstOrDefault(p => p.Product.Id == productId);
            //if (cartProduct != null)
            //{
            //    user.CartProducts.Remove(cartProduct);
            //    Database.Save();
            //}
        }
        public void DecrementFromCart(string email, int productId)
        {
            //var user = Database.Users.FindFirst(u => u.Email == email);
            //var product = Database.Products.Get(productId);
            //if (user == null || product == null)
            //    return;
            //var cartProduct = user.CartProducts.FirstOrDefault(p => p.Product.Id == productId);
            //if (cartProduct != null)
            //{
            //    if (--cartProduct.Quantity == 0)
            //    {
            //        product.CartProducts.Remove(cartProduct);
            //        user.CartProducts.Remove(cartProduct);
            //        Database.CartProducts.Delete(cartProduct);
            //    }
            //    Database.Save();
            //}
        }

        private UserDTO ConvertToDTO(User user)
        {
            if (user == null)
                return null;
            var userDTO = new UserDTO
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                Password = user.Password,
                Role = user.Role,
                LastName = user.LastName,
                Description = user.Description,
                Town = user.Town,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber,
                BirthDate = user.BirthDate,
                NumberOfParticipations = user.NumberOfParticipations,
                ProjectVolunteers = new Dictionary<ProjectDTO, int>()

                //CartProducts = new Dictionary<ProductDTO, int>()
            };

            foreach (var projectVolunteer in user.ProjectVolunteers)
            {
                userDTO.ProjectVolunteers.Add(ProjectAPI.ConvertToDTO(projectVolunteer.Project), projectVolunteer.Status);
            }

            //foreach (var cartProduct in user.CartProducts)
            //{
            //    userDTO.CartProducts.Add(ProductAPI.ConvertToDTO(cartProduct.Product), cartProduct.Quantity);
            //}
            return userDTO;
        }

        public UserDTO GetUser(string email)
        {
            var user = Database.Users.FindFirst(u => u.Email == email);
            return ConvertToDTO(user);
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            return Database.Users.GetAll().ToList().ConvertAll(ConvertToDTO);
        }

        public void AddProject(ProjectDTO projectDTO, string imageUrl, string directory)
        {
            var project = new Project { Name = projectDTO.Name, Category = projectDTO.Category,
                Description = projectDTO.Description, OrganizationId = projectDTO.OrganizationId, Date = projectDTO.Date,
                Town = projectDTO.Town, Address = projectDTO.Address, RequiredNumberOfVolunteers = projectDTO.RequiredNumberOfVolunteers,
                NumberOfParticipatingVolunteers = projectDTO.NumberOfParticipatingVolunteers  };
            Database.Projects.Create(project);
            Database.Save();
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(new Uri(imageUrl), directory + "/" + project.Id + ".jpg");
            }
        }
        public void DeleteProject(int projectId, string directory)
        {
            var project = Database.Projects.Get(projectId);
            var path = directory + "/" + project.Id + ".jpg";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            Database.Projects.Delete(project);
            Database.Save();
        }

        public void ConfirmParticipant(int id)
        {
            var participation = Database.ProjectVolunteers.Get(id);
            if(participation != null)
            {
                participation.Status = 1;
                var volunteer = Database.Users.Get(participation.VolunteerId);
                if(volunteer != null)
                {
                    volunteer.NumberOfParticipations++;
                }
                Database.Save();
            }
        }

        public void DeleteParticipant(int id)
        {
            var participation = Database.ProjectVolunteers.Get(id);
            if (participation != null)
            {
                if(participation.Status == 1)
                {
                    var volunteer = Database.Users.Get(participation.VolunteerId);
                    if(volunteer != null)
                    {
                        volunteer.NumberOfParticipations--;
                    }
                }
                var project = Database.Projects.Get(participation.ProjectId);
                if (project != null)
                {
                    project.NumberOfParticipatingVolunteers--;
                }
                Database.ProjectVolunteers.Delete(participation);
                Database.Save();
            }
        }


        public void CancelParticipation(int id)
        {
            var projectVolunteer = Database.ProjectVolunteers.Get(id);
            var project = Database.Projects.Get(projectVolunteer.ProjectId);
            project.NumberOfParticipatingVolunteers--;
            Database.ProjectVolunteers.Delete(projectVolunteer);
            Database.Save();
        }

        public void AddGoodDeed(GoodDeedDTO goodDeedDTO, string imageUrl, string directory)
        {
            var goodDeed = new GoodDeed
            {
                Name = goodDeedDTO.Name,
                Category = goodDeedDTO.Category,
                Description = goodDeedDTO.Description,
                SimpleUserId = goodDeedDTO.SimpleUserId,
                Date = goodDeedDTO.Date,
                Town = goodDeedDTO.Town,
                Address = goodDeedDTO.Address,
                PhoneNumber = goodDeedDTO.PhoneNumber,
                RequiredNumberOfVolunteers = goodDeedDTO.RequiredNumberOfVolunteers,
                NumberOfParticipatingVolunteers = goodDeedDTO.NumberOfParticipatingVolunteers
            };
            Database.GoodDeeds.Create(goodDeed);
            Database.Save();
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(new Uri(imageUrl), directory + "/" + goodDeed.Id + ".jpg");
            }
        }
        public void DeleteGoodDeed(int goodDeedId, string directory)
        {
            var goodDeed = Database.GoodDeeds.Get(goodDeedId);
            var path = directory + "/" + goodDeed.Id + ".jpg";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            Database.GoodDeeds.Delete(goodDeed);
            Database.Save();
        }
    }
}