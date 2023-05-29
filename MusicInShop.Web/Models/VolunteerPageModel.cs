using MusicInShop.BusinessLogic.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicInShop.Web.Models
{
    public class VolunteerPageModel : NavbarModel
    {
        public UserDTO Volunteer { get; set; }
    }
}