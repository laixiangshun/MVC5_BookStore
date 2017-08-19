using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooksStore.Common.Filters
{
    /// <summary>
    /// 直接继承ActionFilterAttribute重写OnActionExecuting方法 （actionFilterAttribut继承了IActionFilter与IResultFilter）
    /// </summary>
    public class MyActionAttribute:ActionFilterAttribute
    {
        /// <summary>
        /// 在action方法前执行
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
        /// <summary>
        /// 在action执行后执行
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }


    }
}