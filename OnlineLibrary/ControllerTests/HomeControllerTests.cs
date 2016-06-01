using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineLibrary.Controllers;
using Moq;
using Services;
using ModelServices;
using System.Web.Mvc;
using System.Collections.Generic;
using Core.ViewModels;

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
    }
}
