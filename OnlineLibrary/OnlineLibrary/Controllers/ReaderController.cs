using Microsoft.AspNet.Identity;
using ModelServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineLibrary.Controllers
{
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

        public ActionResult GetProfileForModerator()
        {
            return View();
        }

        public ActionResult EditProfile()
        {
            return View(_userViewModelService.GetUser(User.Identity.GetUserId()));
        }

        public ActionResult GetProfileForAdmin(string userId)
        {
            return View(_userViewModelService.GetUserForAdmin(userId));
        }
    }
}