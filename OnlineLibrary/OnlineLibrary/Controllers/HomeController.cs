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
            var a = _userService.GetAllUsers();
            var b = a;

            var c = User.Identity.Name;
            var d = c;

            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new LibraryContext()));
            var inrole = um.IsInRole(User.Identity.GetUserId(), "Administrator");
            var r = inrole;


            if (User.IsInRole("Administrator"))
                RedirectToAction("Index", "Admin");
            if (User.IsInRole("1"))
                RedirectToAction("Index", "Admin");
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