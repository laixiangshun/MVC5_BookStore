using BooksStore.Common.Filters;
using BooksStore.Infrastructure;
using BooksStore.NinjectFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BooksStore
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //添加全局的action过滤器，也可以在每个action方法前加[MyActionAttribute]
            GlobalFilters.Filters.Add(new MyActionAttribute());

            //注册Ninject容器
            //ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory());

            //在Global.asax文件里注册Dependency Resolver，使用我们自定义的NinjectDependencyResolver来替换mvc5中默认的DependencyResolver，

            //这样就能够让mvc5支持DI，依赖注入
            //设置Ninject DependencyResolver
            //DependencyResolver.SetResolver(new NinjectDependencyResolver());
           
            AutofacReg.RegisterDenpendencies();
        }
    }
}
