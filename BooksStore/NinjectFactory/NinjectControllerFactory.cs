using BooksStore.Repository;
using BooksStore.Repository.RepositoryImpl;
using BooksStore.Service;
using BooksStore.Service.ServiceImpl;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BooksStore.NinjectFactory
{
    public class NinjectControllerFactory:DefaultControllerFactory
    {
        private readonly IKernel _kernel;
        public NinjectControllerFactory()
        {
            _kernel = new StandardKernel();
            AddBindings();
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)_kernel.Get(controllerType);
        }
        //绑定接口和实现类
        private void AddBindings()
        {
            _kernel.Bind<IBookService>().To<BookServiceImpl>();
            _kernel.Bind<BookDao>().To<BookDaoImpl>();
        }
    }
}