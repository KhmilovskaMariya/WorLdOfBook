using Core.Models;
using Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ModelServices;
using Services;
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
        private readonly IBookViewModelService _bookViewModelService;
        private readonly ICommentViewModelService _commentViewModelService;
        private readonly ICommentService _commentService;
        private readonly IUserService _userService;

        public ModeratorController(IModeratorViewModelService moderatorViewModelService, 
            IBookViewModelService bookViewModelService, ICommentViewModelService commentViewModelService,
            ICommentService commentService, IUserService userService)
        {
            _moderatorViewModelService = moderatorViewModelService;
            _bookViewModelService = bookViewModelService;
            _commentViewModelService = commentViewModelService;
            _commentService = commentService;
            _userService = userService;
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

        public PartialViewResult Books()
        {
            return PartialView(_bookViewModelService.GetAllBooksForModerators());
        }

        public PartialViewResult Comments()
        {
            return PartialView(_commentViewModelService.GetAllCommentsSortedByDateForLastWeek());
        }

        [Authorize(Roles = "Moderator")]
        public ActionResult Ban(string id)
        {
            using (var context = new LibraryContext())
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                userManager.AddToRole(id, "BannedUser");
            }
            return View("Index");
        }

        [Authorize(Roles = "Moderator")]
        public ActionResult Unban(string id)
        {
            using (var context = new LibraryContext())
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                userManager.RemoveFromRole(id, "BannedUser");
            }
            return View("Index");
        }

        [Authorize(Roles = "Moderator")]
        public ActionResult AcceptDeclineBook(int id, bool isAccepted)
        {
            _bookViewModelService.AcceptDeclineBook(id, isAccepted);
            return View("Index");
        }

        [Authorize(Roles = "Moderator")]
        public ActionResult DeleteComment(int id)
        {
            _commentService.DeleteComment(id);
            return View("Index");
        }
    }
}