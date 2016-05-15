using Core.Models;
using Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ModelServices;
using Services;
using System.Web.Mvc;

namespace OnlineLibrary.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        private readonly IAdminUserViewModelService _adminUserViewModelService;

        public AdminController(IUserService userService, IAdminUserViewModelService adminUserViewModelService)
        {
            _userService = userService;
            _adminUserViewModelService = adminUserViewModelService;
        }

        [Authorize(Roles ="Administrator")]
        // GET: Admin
        public ActionResult Index()
        {
            return View(_adminUserViewModelService.GetAllAdminUsers());
        }

        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(string id)
        {
            _userService.DeleteUser(id);
            return RedirectToAction("Index");
        }

        public ActionResult GiveRights(string id, bool isModerator)
        {
            using (var context = new LibraryContext())
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                userManager.RemoveFromRoles(id, "Reader", "Author");
                if (isModerator)
                    userManager.AddToRole(id, "Moderator");
                else
                    userManager.AddToRole(id, "Administrator");
                _userService.ChangeStatus(id);
            }
            return RedirectToAction("Index");
        }

    }
}