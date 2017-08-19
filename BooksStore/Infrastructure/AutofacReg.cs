
using Autofac;
using Autofac.Integration.Mvc;
using BooksStore.Repository;
using BooksStore.Repository.RepositoryImpl;
using BooksStore.Service;
using BooksStore.Service.ServiceImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using System.Web.Mvc;

namespace BooksStore.Infrastructure
{
    //新建一个注册Autofac的IOC的类
    public class AutofacReg
    {
        //针对接口编程,不针对实现编程";创建实例不是使用New关键字创建,而是创建实例的工作交给了IoC容器,这就实现了关系解耦,可以在IoC容器中随便的替换具体的实现类了
        public static void RegisterDenpendencies()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(System.Reflection.Assembly.GetExecutingAssembly());//注册mvc容器的实现  
            //Type baseType=typeof(IDpendency);


            //用GetReferencedAssemblies方法获取当前应用程序下所有的程序集  
            //var assemblys = BuildManager.GetReferencedAssemblies().Cast<Assembly>().ToList();

            //build.RegisterAssemblyTypes(assemblys.ToArray())//查找程序集中以Repository结尾的类型  
            //.Where(t => t.Name.EndsWith("Dao"))//查找所有程序集下面以Bll结尾的类  
            //.AsImplementedInterfaces(); //将找到的类和对应的接口放入IOC容器(放到IOC容器中有什么用处？：)  

            //build.RegisterAssemblyTypes(assemblys.ToArray())//查找程序集中以Dal结尾的类型  
            //.Where(t => t.Name.EndsWith("Service"))
            //.AsImplementedInterfaces();//表示注册的类型，以接口的方式注册

            builder.RegisterType<BookServiceImpl>().As<IBookService>().InstancePerDependency();
            builder.RegisterType<BookDaoImpl>().As<BookDao>().InstancePerDependency();

           // 获取所有相关类库的程序集
           //build.RegisterAssemblyTypes(assemblys.ToArray())
            //    .Where(type => baseType.IsAssignableFrom(type) && !type.IsAbstract)
            //    .AsImplementedInterfaces().InstancePerLifetimeScope();//InstancePerLifetimeScope 保证对象生命周期基于请求

            IContainer container = builder.Build();//Build()方法是表示：创建一个容器
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));//注册MVC容器  
           // var lifetimescope = container.BeginLifetimeScope();
        }
    }
}