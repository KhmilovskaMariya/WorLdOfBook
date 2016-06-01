using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineLibrary.Controllers;
using Moq;
using Services;
using ModelServices;
using System.Web.Mvc;
using System.Collections.Generic;
using Core.ViewModels;
using Data;
using Core.Models;

namespace ControllerTests
{
    [TestClass]
    public class HomeControllerTests
    {
        private HomeController _controller;
        private Mock<IUserService> _userServiceMock;
        private Mock<IBookViewModelService> _bookViewModelServiceMock;

        [TestInitialize]
        public void Initialize()
        {
            _userServiceMock = new Mock<IUserService>();
            _bookViewModelServiceMock = new Mock<IBookViewModelService>();

            _bookViewModelServiceMock.Setup(s => s.SearchBook("search")).Returns(new List<SearchBookViewModel>());

            _controller = new HomeController(_userServiceMock.Object, _bookViewModelServiceMock.Object);
        }

        [TestMethod]
        public void SearchBookTest()
        {
            var result = _controller.BookSearch("search") as ViewResult;
            _bookViewModelServiceMock.Verify(s => s.SearchBook("search"), Times.Once);
            Assert.AreEqual("Search", result.ViewName);
        }
        [TestMethod]
        public void HomePageTest()
        {
            var result = _controller.HomePage() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }
        [TestMethod]
        public void AllBookTest()
        {
            List<Book> lb = new List<Book>();
            lb.Add(new Book { Id = 4, Title = "Name1", Language = "L1", YearOfPublication = 123, Description = "d1" });
            lb.Add(new Book { Id = 10, Title = "Name1", Language = "L1", YearOfPublication = 123, Description = "d1" });
            _bookViewModelServiceMock.Setup(m => m.GetAllBooks()).Returns(lb);

            var result = _controller.AllBooks() as ViewResult; 
            Assert.AreEqual(2, (result.Model as List<Book>).Count);
           // Assert.AreEqual("AllBooks", result.ViewName);
        }
        //[TestMethod]
        //public void AboutTest()
        //{
        //    var result = _controller.About() as ViewResult;
        //    Assert.AreEqual("About", result.ViewName);
        //}

        //[TestMethod]
        //public void ContactTest()
        //{
        //    var result = _controller.Contact() as ViewResult;
        //    Assert.AreEqual("Contact", result.ViewName);
        //}
    }
}
