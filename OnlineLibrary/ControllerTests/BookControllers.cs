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
    public class BookControllerTests
    {
        private BookController _controller;
        private Mock<IUserService> _userServiceMock;
        private Mock<ICommentViewModelService> _commentServiceMock;
        private Mock<IBookViewModelService> _bookViewModelServiceMock;

        [TestInitialize]
        public void Initialize()
        {
            _userServiceMock = new Mock<IUserService>();
            _commentServiceMock = new Mock<ICommentViewModelService>();
            _bookViewModelServiceMock = new Mock<IBookViewModelService>();
            _controller = new BookController(_userServiceMock.Object,_bookViewModelServiceMock.Object, _commentServiceMock.Object);
        }

        
        [TestMethod]
        public void CommentTest()
        {
            var result = _controller.CommentBook( new CommentViewModel());
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
            RedirectToRouteResult routeResult = result as RedirectToRouteResult;
            Assert.AreEqual(routeResult.RouteValues["action"], "Book");
        }
    }
}
