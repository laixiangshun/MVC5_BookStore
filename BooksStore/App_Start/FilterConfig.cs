using BooksStore.Common.ExceptionFilter;
using System.Web;
using System.Web.Mvc;

namespace BooksStore
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            //将统一的action异常捕获过滤器ExpFilter注册成为全局
            filters.Add(new ExpFilter());
        }
    }
}
