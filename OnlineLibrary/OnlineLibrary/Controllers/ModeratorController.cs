using ModelServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult Index()
        {
            var a = _moderatorViewModelService.GetAllReaders();
            var b = a;
            return View();
        }
    }
}