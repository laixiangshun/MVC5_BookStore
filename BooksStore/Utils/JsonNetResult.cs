using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooksStore.Utils
{
    public class JsonNetResult:JsonResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentException(context.GetType().FullName);
            }
            var response = context.HttpContext.Response;
            response.ContentType = !string.IsNullOrEmpty(ContentType) ? ContentType : "application/json";
            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }
            var jsonSerializerSetting = new JsonSerializerSettings();
            //首字母小写
            jsonSerializerSetting.ContractResolver = new CamelCasePropertyNamesContractResolver();
            //日期格式化
            jsonSerializerSetting.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            var json = JsonConvert.SerializeObject(Data, Formatting.None, jsonSerializerSetting);
            response.Write(json);
            //base.ExecuteResult(context);
        }
    }
}