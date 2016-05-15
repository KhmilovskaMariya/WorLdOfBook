using Core.Models;
using Data;
using ModelServices;
using Ninject;
using Services;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OnlineLibrary.Util
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        private IUOW unitOfWork;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            unitOfWork = new UnitOfWork();
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IRepository<Comment>>().ToMethod(m => unitOfWork.Repository<Comment>());
            kernel.Bind<IRepository<Book>>().ToMethod(m => unitOfWork.Repository<Book>());
            kernel.Bind<IRepository<ApplicationUser>>().ToMethod(m => unitOfWork.Repository<ApplicationUser>());
            kernel.Bind<IDbContext>().To<LibraryContext>();
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IModeratorViewModelService>().To<ModeratorViewModelService>();
            kernel.Bind<IAdminUserViewModelService>().To<AdminUserViewModelService>();
            kernel.Bind<IRepository<File>>().ToMethod(m => unitOfWork.Repository<File>());
            kernel.Bind<IUserViewModelService>().To<UserViewModelService>();
            kernel.Bind<IBookViewModelService>().To<BookViewModelService>();
        }
    }
}