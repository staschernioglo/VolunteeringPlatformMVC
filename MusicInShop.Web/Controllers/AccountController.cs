using MusicInShop.BusinessLogic.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MusicInShop.Web.Models;

namespace MusicInShop.Web.Controllers
{
    public class AccountController : BaseController
    {
        public ActionResult RegisterType()
        {
            var model = new LoginModel { User = LoggedUser };
            return View(model);
        }

        public ActionResult Login()
        {
            var model = new LoginModel { User = LoggedUser };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new UserDTO { Email = model.Email, Password = model.Password };
                var result = UserAPI.Login(user);
                if (result.Succeeded)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", result.Message);

            }
            return View(model);
        }

        public ActionResult Register()
        {
            var model = new RegisterModel { User = LoggedUser };
            return View(model);
        }

        public ActionResult RegisterOrganization()
        {
            var model = new RegisterOrganizationModel { User = LoggedUser };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterOrganization(RegisterOrganizationModel model)
        {
            if (ModelState.IsValid)
            {
                var organization = new UserDTO
                {
                    Email = model.Email,
                    Name = model.Name,
                    Password = model.Password,
                    Role = "organization",
                    Description = model.Description,
                    Town = model.Town,
                    Address = model.Address,
                    PhoneNumber = model.PhoneNumber
                };
                var directory = Server.MapPath("~/Content/img/users");
                var imgUrl = @"C:\Users\Admin\Desktop\diplom_img\organizations\" + (model.ImageUrl ?? "default.png");
                var result = UserAPI.Register(organization, imgUrl, directory);
                if (result.Succeeded)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", result.Message);
            }
            return View(model);
        }

        public ActionResult RegisterVolunteer()
        {
            var model = new RegisterVolunteerModel { User = LoggedUser };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterVolunteer(RegisterVolunteerModel model)
        {
            if (ModelState.IsValid)
            {
                var volunteer = new UserDTO
                {
                    Email = model.Email,
                    Name = model.Name,
                    LastName = model.LastName,
                    Password = model.Password,
                    Role = "volunteer",
                    BirthDate = model.BirthDate,
                    Description = model.Description,
                    Town = model.Town,
                    PhoneNumber = model.PhoneNumber
                };
                var directory = Server.MapPath("~/Content/img/users");
                var imgUrl = @"C:\Users\Admin\Desktop\diplom_img\Volunteers\" + (model.ImageUrl ?? "default.png");
                var result = UserAPI.Register(volunteer, imgUrl, directory);
                if (result.Succeeded)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", result.Message);
            }
            return View(model);
        }

        public ActionResult RegisterSimpleUser()
        {
            var model = new RegisterSimpleUserModel { User = LoggedUser };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterSimpleUser(RegisterSimpleUserModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new UserDTO
                {
                    Email = model.Email,
                    Name = model.Name,
                    LastName = model.LastName,
                    Password = model.Password,
                    Role = "user",
                    Town = model.Town,
                    PhoneNumber = model.PhoneNumber
                };
                var directory = Server.MapPath("~/Content/img/users");
                var imgUrl = @"C:\Users\Admin\Desktop\diplom_img\SimpleUsers\" + (model.ImageUrl ?? "default.png");
                var result = UserAPI.Register(user, imgUrl, directory);
                if (result.Succeeded)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", result.Message);
            }
            return View(model);
        }



        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Register(RegisterModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = new UserDTO { Email = model.Email, NickName = model.Nickname, Password = model.Password, Role = "user" };
        //        var result = UserAPI.Register(user);
        //        if (result.Succeeded)
        //        {
        //            FormsAuthentication.SetAuthCookie(model.Email, true);
        //            return RedirectToAction("Index", "Home");
        //        }
        //        ModelState.AddModelError("", result.Message);
        //    }
        //    return View(model);
        //}

        [Authorize]
        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}