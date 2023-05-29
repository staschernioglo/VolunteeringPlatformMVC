using MusicInShop.BusinessLogic.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicInShop.Web.Models
{
    public class UserPageModel : NavbarModel
    {
        public IEnumerable<UserDTO> Users { get; set; }
    }
}