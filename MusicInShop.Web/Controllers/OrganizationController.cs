using MusicInShop.BusinessLogic.DataTransfer;
using MusicInShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicInShop.Web.Controllers
{
    public class OrganizationController : BaseController
    {
        [HttpGet]
        public ActionResult AddProject()
        {
            var model = new ProjectModel { User = LoggedUser };
            return View(model);
        }

        public ActionResult OrganizationPage(string email)
        {
            var model = new OrganizationPageModel { User = LoggedUser, Organization = UserAPI.GetUser(email) };
            return View(model);
        }

        public ActionResult MyProjects()
        {
            var model = new OrganizationProjectModel { User = LoggedUser, Projects = ProjectAPI.GetAllProjects() };
            return View(model);
        }

        [HttpPost]
        public ActionResult AddProject(ProjectModel model)
        {
            if (ModelState.IsValid)
            {
                var project = new ProjectDTO 
                { 
                    Name = model.Name, 
                    Category = model.Category,
                    Description = model.Description,
                    Date = model.Date,
                    Town = model.Town, 
                    Address = model.Address, 
                    OrganizationId = LoggedUser.Id,
                    RequiredNumberOfVolunteers = model.RequiredNumberOfVolunteers, 
                    NumberOfParticipatingVolunteers = 0
                };
                var directory = Server.MapPath("~/Content/img/projects");
                var imgUrl = @"C:\Users\Admin\Desktop\diplom_img\projects\" + (model.ImageUrl ?? "default.png");
                UserAPI.AddProject(project, imgUrl, directory);
                return RedirectToAction("Index", "Project");
            }
            return View(model);
        }

        public ActionResult DeleteProject(int id)
        {
            var directory = Server.MapPath("~/Content/img/projects");
            UserAPI.DeleteProject(id, directory);
            return RedirectToAction("MyProjects");
        }

        public ActionResult ParticipatingVolunteers(int id)
        {
            var projectVolunteers = ProjectVolunteerAPI.GetProjectVolunteersById(id);
            var model = new ParticipatingVolunteersModel { User = LoggedUser, ProjectVolunteers = projectVolunteers };
            return View(model);
        }

        public ActionResult ConfirmParticipant(int id, int projectId)
        {
            UserAPI.ConfirmParticipant(id);
            return RedirectToAction("ParticipatingVolunteers", new { id = projectId });
        }

        public ActionResult DeleteParticipant(int id, int projectId)
        {
            UserAPI.DeleteParticipant(id);
            return RedirectToAction("ParticipatingVolunteers", new { id = projectId });
        }



    }
}