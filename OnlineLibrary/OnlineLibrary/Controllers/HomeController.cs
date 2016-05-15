using Core.Common;
using Core.Models;
using Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Services;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineLibrary.Controllers
{
    [InitializeSimpleMembershipAttribute]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
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
    }
}