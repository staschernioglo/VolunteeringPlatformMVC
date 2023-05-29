using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MusicInShop.Web.Models
{
    public class RegisterVolunteerModel : NavbarModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }

        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        
        [DataType(DataType.Date)]
        public string BirthDate { get; set; }

        public string Description { get; set; }

        public string Town { get; set; }

        public string PhoneNumber { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }
    }
}