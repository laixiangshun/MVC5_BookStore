using BooksStore.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooksStore.Controllers
{
    public class BaseController:Controller
    {
        protected override JsonResult Json(object data, string contentType, System.Text.Encoding contentEncoding, JsonRequestBehavior behavior)
        {
           // return base.Json(data, contentType, contentEncoding, behavior);
            return new JsonNetResult { Data = data, ContentType = contentType, ContentEncoding = contentEncoding, JsonRequestBehavior = behavior };
        }
    }
}