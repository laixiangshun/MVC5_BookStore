using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BooksStore.Utils
{
    //序列号帮助类
    public class SerializeHelper
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static byte[] Serialize(object item)
        {
            var jsonstring = JsonConvert.SerializeObject(item);
            return Encoding.UTF8.GetBytes(jsonstring);
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TEntity Deserialize<TEntity>(byte[] value)
        {
            if (value == null)
            {
                return default(TEntity);
            }
            var jsonstring = Encoding.UTF8.GetString(value);
            return JsonConvert.DeserializeObject<TEntity>(jsonstring);
        }
    }
}