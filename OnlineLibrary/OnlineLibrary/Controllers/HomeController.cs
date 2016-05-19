using Core.Common;
using Core.Models;
using Core.ViewModels;
using Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ModelServices;
using Services;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineLibrary.Controllers
{
    [InitializeSimpleMembershipAttribute]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private readonly IBookViewModelService _bookViewModelService;

        public HomeController(IUserService userService, IBookViewModelService bookViewModelService)
        {
            _userService = userService;
            _bookViewModelService = bookViewModelService;
        }

        public ActionResult Index()
        {
            if (User.IsInRole("Moderator"))
            {
                return RedirectToAction("Index", "Moderator");
            }
            if (User.IsInRole("Administrator"))
            {
                return RedirectToAction("Index", "Admin");
            }
            if (_userService.GetUser(User.Identity.GetUserId())?.Status == UserStatus.Reader)
            {
                return RedirectToAction("Profile", "Reader");
            }
            if(_userService.GetUser(User.Identity.GetUserId())?.Status == UserStatus.Author)
            {
                return RedirectToAction("Profile", "Author");
            }
            return View();
        }

        public ActionResult HomePage()
        {
            return View("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Search()
        {
            ViewBag.Flag = "True";
            return View(new List<SearchBookViewModel>());
        }

        [HttpPost]
        public ActionResult BookSearch(string query = "")
        {
            ViewBag.Flag = query == "" ? "True" : "False";
            return View("Search", _bookViewModelService.SearchBook(query));
        }
    }
}