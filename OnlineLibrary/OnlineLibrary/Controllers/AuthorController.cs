using Microsoft.AspNet.Identity;
using ModelServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineLibrary.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IUserViewModelService _userViewModelService;
        private readonly IBookViewModelService _bookViewModelService;

        public AuthorController(IUserViewModelService userViewModelService, IBookViewModelService bookViewModelService)
        {
            _userViewModelService = userViewModelService;
            _bookViewModelService = bookViewModelService;
        }
        // GET: Author
        public ActionResult Profile()
        {
            return View(_userViewModelService.GetUser(User.Identity.GetUserId()));
        }

        public PartialViewResult AllAuthorsBook(string userId)
        {
            return PartialView(_bookViewModelService.GetAllAuthorsBook(userId));
        }

        public ActionResult GetProfileForModerator(string userId)
        {
            return View(_userViewModelService.GetAuthorForModerator(userId));
        }
    }
}