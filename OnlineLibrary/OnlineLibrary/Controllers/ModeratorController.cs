using ModelServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineLibrary.Controllers
{
    public class ModeratorController : Controller
    {
        private readonly IModeratorViewModelService _moderatorViewModelService;

        public ModeratorController(IModeratorViewModelService moderatorViewModelService)
        {
            _moderatorViewModelService = moderatorViewModelService;
        }

        // GET: Moderator
        [Authorize(Roles = "Moderator")]
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Readers()
        {
            return PartialView(_moderatorViewModelService.GetAllReaders());
        }

        public PartialViewResult Authors()
        {
            return PartialView(_moderatorViewModelService.GetAllAuthors());
        }


        [Authorize(Roles = "Moderator")]
        public ActionResult Ban(string id)
        {

            Roles.AddUserToRole(id, "BannedUser");
            return View("Index");
        }

        [Authorize(Roles = "Moderator")]
        public ActionResult Unban(string id)
        {
            Roles.RemoveUserFromRole(id, "BannedUser");
            return View("Index");
        }
    }
}