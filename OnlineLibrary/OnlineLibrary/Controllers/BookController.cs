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
        private readonly ICommentViewModelService _commentViewModelService;
        public int PageSize = 4;

        public BookController(IUserService userService, IBookViewModelService bookViewModelService,
            ICommentViewModelService commentViewModelService)
        {
            _userService = userService;
            _bookViewModelService = bookViewModelService;
            _commentViewModelService = commentViewModelService;
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


        //public PartialViewResult MostPopularBooks()
        //{
        //    return PartialView(_bookViewModelService.GetMostPopularBooks(3));
        //}

        public ActionResult Book(int id)
        {
            return View(_bookViewModelService.GetBook(id));
        }

        [HttpGet]
        public ActionResult RateBook(int id)
        {
            return View(new RateViewModel { Id = id });
        }

        [HttpPost]
        public ActionResult RateBook(RateViewModel model)
        {
            _bookViewModelService.RateBook(model.Id, model.RateMark);
            return RedirectToAction("Book", new { id = model.Id });
        }

        [HttpGet]
        public ActionResult CommentBook(int bookId, string userId)
        {
            return View(new CommentViewModel { UserId = userId, BookId = bookId });
        }

        [HttpPost]
        public ActionResult CommentBook(CommentViewModel model)
        {
            _commentViewModelService.CommentBook(model);
            return RedirectToAction("Book", new { id = model.BookId });
        }

        public ActionResult GetBookForModerator(int id)
        {
            return View(_bookViewModelService.GetBookForModerator(id));
        }
        public ViewResult List(int page = 1)
        {
            return View(_bookViewModelService.Pagination());
            
        }
    }
}