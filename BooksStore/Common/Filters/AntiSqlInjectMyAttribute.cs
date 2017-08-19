using BooksStore.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooksStore.Common.Filters
{
    /// <summary>
    /// 自定义防止sql注入辅助类：在action方法之心前执行，对会影响sql的参数做一些处理
    /// </summary>
    public class AntiSqlInjectMyAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var actionparams=filterContext.ActionDescriptor.GetParameters();
            foreach (var p in actionparams)
            {
                //因为sql注入只有参数类型为字符串的时候才有可能所以这里只对Action参数为字符串的参数进行处理。

                if (p.ParameterType == typeof(string))
                {
                    if (filterContext.ActionParameters[p.ParameterName] != null)
                    {
                        filterContext.ActionParameters[p.ParameterName] = StringHelper.FilterSql(filterContext.ActionParameters[p.ParameterName].ToString());
                    }
                }
            }

            //base.OnActionExecuting(filterContext);
        }
    }
}