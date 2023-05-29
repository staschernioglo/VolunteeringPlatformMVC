using MusicInShop.BusinessLogic.API;
using MusicInShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicInShop.Web.Controllers
{
    public class GoodDeedController : BaseController
    {
        // GET: GoodDeed
        public ActionResult Index()
        {
            var model = new GoodDeedModel { User = LoggedUser, GoodDeeds = GoodDeedAPI.GetAllGoodDeeds() };
            return View(model);
        }

        public ActionResult GoodDeed(int id)
        {
            var model = new GoodDeedPageModel { User = LoggedUser, GoodDeed = GoodDeedAPI.GetGoodDeed(id) };
            return View(model);
        }
    }
}