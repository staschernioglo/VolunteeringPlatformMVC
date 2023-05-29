using MusicInShop.BusinessLogic.API;
using MusicInShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicInShop.Web.Controllers
{
    public class VolunteerController : BaseController
    {
        // GET: Volunteer
        public ActionResult MyParticipations()
        {
            var projectVolunteers = ProjectVolunteerAPI.GetAllProjectVolunteers();
            var model = new ParticipatingVolunteersModel { User = LoggedUser, ProjectVolunteers = projectVolunteers };
            return View(model);
        }

        public ActionResult CancelParticipation(int id)
        {
            UserAPI.CancelParticipation(id);
            return RedirectToAction("MyParticipations");
        }
    }
}