using MusicInShop.BusinessLogic.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicInShop.Web.Models
{
    public class ProjectPageModel : NavbarModel
    {
        public ProjectDTO Project { get; set; }
    }
}