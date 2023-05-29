using MusicInShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicInShop.Web.Controllers
{
    public class UserController : BaseController
    {
        // GET: User
        public ActionResult OrganizationPage()
        {
            var model = new UserPageModel { User = LoggedUser, Users = UserAPI.GetAllUsers() };
            return View(model);
        }

        public ActionResult VolunteerPage()
        {
            var model = new UserPageModel { User = LoggedUser, Users = UserAPI.GetAllUsers() };
            return View(model);
        }
    }
}