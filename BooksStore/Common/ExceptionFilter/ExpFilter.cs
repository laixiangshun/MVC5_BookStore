using BooksStore.Common.Log;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooksStore.Common.ExceptionFilter
{
    /// <summary>
    /// 全局错误异常处理类
    /// </summary>
    public class ExpFilter:HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            Exception exp = filterContext.Exception;
            //获取ex的第一级内部异常
            Exception innerExp = exp.InnerException == null ? exp : exp.InnerException;
            //循环获取内部异常直到获取详细异常信息为止
            while (innerExp.InnerException != null)
            {
                innerExp = innerExp.InnerException;
            }
            NLogLogger nlog = new NLogLogger();
            //ajax请求
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                nlog.Error(innerExp.Message);
                JsonConvert.SerializeObject(new { status = 1, msg = "请求发生错误，请联系管理员" });
            }
            else //正常url请求
            {
                nlog.Error("Error",exp);
                ViewResult viewResult = new ViewResult();
                viewResult.ViewName = "/Views/Shared/Error.cshtml";
                filterContext.Result = viewResult;
            }
            //告诉mvc框架异常被处理
            filterContext.ExceptionHandled = true;

            base.OnException(filterContext);
        }
    }
}