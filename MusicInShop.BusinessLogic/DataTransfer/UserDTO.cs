using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MusicInShop.BusinessLogic.DataTransfer
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Description { get; set; }
        public string Town { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string BirthDate { get; set; }
        public int NumberOfParticipations { get; set; }
        public IDictionary<ProjectDTO, int> ProjectVolunteers { get; set; }

        //public IDictionary<ProductDTO, int> CartProducts { get; set; }
    }
}