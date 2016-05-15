using Core.Models;
using Core.ViewModels;
using ModelServices;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineLibrary.Controllers
{
    public class BookController : Controller
    {
        private readonly IUserService _userService;
        private readonly IBookViewModelService _bookViewModelService;

        public BookController(IUserService userService, IBookViewModelService bookViewModelService)
        {
            _userService = userService;
            _bookViewModelService = bookViewModelService;
        }

        // GET: Book
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddBook(string userId)
        {
            var model = new AddBookViewModel { AuthorId = userId };
            return View(model);
        }

        [HttpPost]
        public ActionResult AddBook(AddBookViewModel model, HttpPostedFileBase upload)
        {
            if(ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    var image = new File
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        ContentType = upload.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        image.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    model.Image = image;
                }
                _bookViewModelService.AddBook(model);
                return RedirectToAction("Profile", "Author");
            }
            return View(model);
        }
    }
}