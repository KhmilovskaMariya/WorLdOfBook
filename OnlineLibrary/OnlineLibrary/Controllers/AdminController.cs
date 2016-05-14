using Services;
using System.Web.Mvc;

namespace OnlineLibrary.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUserService _userService;

        public AdminController(IUserService userService)
        {
            _userService = userService;          
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View(_userService.GetAllUsers());
        }
    }
}