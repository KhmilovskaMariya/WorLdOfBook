using Core.Models;
using Data;
using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Util
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
        }
    }
}
