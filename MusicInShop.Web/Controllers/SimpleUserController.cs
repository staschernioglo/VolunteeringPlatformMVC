using MusicInShop.BusinessLogic.DataTransfer;
using MusicInShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicInShop.Web.Controllers
{
    public class SimpleUserController : BaseController
    {
        // GET: SimpleUser
        [HttpGet]
        public ActionResult AddGoodDeed()
        {
            var model = new GoodDeedModel { User = LoggedUser };
            return View(model);
        }

        [HttpPost]
        public ActionResult AddGoodDeed(GoodDeedModel model)
        {
            if (ModelState.IsValid)
            {
                var goodDeed = new GoodDeedDTO
                {
                    Name = model.Name,
                    Category = model.Category,
                    Description = model.Description,
                    Date = model.Date,
                    Town = model.Town,
                    Address = model.Address,
                    SimpleUserId = LoggedUser.Id,
                    PhoneNumber = model.PhoneNumber,
                    RequiredNumberOfVolunteers = model.RequiredNumberOfVolunteers,
                    NumberOfParticipatingVolunteers = 0
                };
                var directory = Server.MapPath("~/Content/img/goodDeeds");
                var imgUrl = @"C:\Users\Admin\Desktop\diplom_img\GoodDeeds\" + (model.ImageUrl ?? "default.png");
                UserAPI.AddGoodDeed(goodDeed, imgUrl, directory);
                return RedirectToAction("Index", "GoodDeed");
            }
            return View(model);
        }

        public ActionResult DeleteGoodDeed(int id)
        {
            var directory = Server.MapPath("~/Content/img/goodDeeds");
            UserAPI.DeleteGoodDeed(id, directory);
            return RedirectToAction("Index");
        }
    }
}