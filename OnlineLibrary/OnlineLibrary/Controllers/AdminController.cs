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

        // GET: Admin
        public ActionResult Index()
        {
            return View(_userService.GetAllUsers());
        }
    }
}