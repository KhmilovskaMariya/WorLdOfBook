using Core.Models;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineLibrary.Controllers
{
    public class FileController : Controller
    {
        private IRepository<File> _fileRepository;

        public FileController(IRepository<File> fileRepository)
        {
            _fileRepository = fileRepository;
        }

        // GET: File
        public ActionResult Index(int id)
        {
            var fileToRetrieve = _fileRepository.GetById(id);
            return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
        }
    }
}