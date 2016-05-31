using Core.Models;
using Core.ViewModels;
using Microsoft.AspNet.Identity;
using ModelServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineLibrary.Controllers
{
    [InitializeSimpleMembershipAttribute.Deny(Roles = "BannedUser", ErrorViewName = "Banned")]
    public class ReaderController : Controller
    {
        private readonly IUserViewModelService _userViewModelService;

        public ReaderController(IUserViewModelService userViewModelService)
        {
            _userViewModelService = userViewModelService;
        }

        // GET: User
        public ActionResult Profile()
        {
            return View(_userViewModelService.GetUser(User.Identity.GetUserId()));
        }

        public ActionResult EditProfile()
        {
            return View(_userViewModelService.GetUser(User.Identity.GetUserId()));
        }

        public ActionResult GetProfileForAdmin(string userId)
        {
            return View(_userViewModelService.GetUserForAdmin(userId));
        }

        public ActionResult GetProfileForModerator(string id)
        {
            return View(_userViewModelService.GetReaderForModerator(id));
        }

        [HttpPost]
        public ActionResult Edit(UserProfileViewModel model, HttpPostedFileBase upload)
        {
            if (upload != null && upload.ContentLength > 0)
            {
                var avatar = new File
                {
                    FileName = System.IO.Path.GetFileName(upload.FileName),
                    ContentType = upload.ContentType
                };
                using (var reader = new System.IO.BinaryReader(upload.InputStream))
                {
                    avatar.Content = reader.ReadBytes(upload.ContentLength);
                }
                model.Avatar = avatar;
            }
            _userViewModelService.EditAuthorProfile(model);
            return RedirectToAction("Profile");
        }
    }
}