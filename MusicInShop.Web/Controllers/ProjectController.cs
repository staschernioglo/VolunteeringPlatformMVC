using MusicInShop.BusinessLogic.API;
using MusicInShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicInShop.Web.Controllers
{
    public class ProjectController : BaseController
    {
        public ActionResult Index()
        {
            var model = new ProjectModel { User = LoggedUser, Projects = ProjectAPI.GetAllProjects() };
            return View(model);
        }

        public ActionResult FilteredProject()
        {
            var model = new ProjectModel { User = LoggedUser, Projects = ProjectAPI.GetAllProjects() };
            return View(model);
        }

        public ActionResult Project(int id)
        {
            var model = new ProjectPageModel { User = LoggedUser, Project = ProjectAPI.GetProject(id) };
            return View(model);
        }

        public ActionResult ParticipatingVolunteers(int id)
        {
            var projectVolunteers = ProjectVolunteerAPI.GetProjectVolunteersById(id);
            var model = new ParticipatingVolunteersModel { User = LoggedUser, ProjectVolunteers = projectVolunteers };
            return View(model);
        }

        [Authorize]
        public ActionResult ParticipateInProject(int id)
        {
            UserAPI.ParticipateInProject(User.Identity.Name, id);
            return PartialView("Empty");
        }


    }
}