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
    public class AdminControllerTests
    {
        private AdminController _controller;
        private Mock<IUserService> _userServiceMock;
        private Mock<IAdminUserViewModelService> _adminViewModelServiceMock;

        [TestInitialize]
        public void Initialize()
        {
            _userServiceMock = new Mock<IUserService>();
            _adminViewModelServiceMock = new Mock<IAdminUserViewModelService>();
             _controller = new AdminController(_userServiceMock.Object, _adminViewModelServiceMock.Object);
        }

        [TestMethod]
        public void IndexTest()
        {
            List<AdminUserViewModel> lb = new List<AdminUserViewModel>();
            lb.Add(new AdminUserViewModel { Id = "56", Email="e1", UserName="name1"  });
            lb.Add(new AdminUserViewModel { Id = "6", Email = "e2", UserName = "name2" });
            _adminViewModelServiceMock.Setup(m => m.GetAllAdminUsers()).Returns(lb);

            var result = _controller.Index() as ViewResult;
            Assert.AreEqual(2, (result.Model as List<AdminUserViewModel>).Count);
    
        }
        [TestMethod]
        public void DeleteTest()
        {
            var result = _controller.Delete("2");
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
            RedirectToRouteResult routeResult = result as RedirectToRouteResult;
            Assert.AreEqual(routeResult.RouteValues["action"], "Index");
        }
    }
}
