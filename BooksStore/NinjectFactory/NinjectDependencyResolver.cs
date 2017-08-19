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

namespace BooksStore.NinjectFactory
{
    //使用Ninject实现依赖注入
    public class NinjectDependencyResolver:IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver()
        {
            kernel = new StandardKernel();
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
            kernel.Bind<IBookService>().To<BookServiceImpl>();
            kernel.Bind<BookDao>().To<BookDaoImpl>();
        }
    }
}