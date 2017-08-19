using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksStore.Utils
{
    /// <summary>
    /// 定义防止sql注入的字符串辅助类
    /// </summary>
    public class StringHelper
    {
        public static string FilterSql(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            else
            {
                s = s.Trim().ToLower();
                s = ClearScript(s);
                s=s.Replace("=", "");
                s=s.Replace("'", "");
                s=s.Replace(";", "");
                s=s.Replace("or", "");
                s=s.Replace("select", "");
                s=s.Replace("update", "");
                s=s.Replace("insert", "");
                s=s.Replace("delete", "");
                s=s.Replace("declare", "");
                s=s.Replace("exec", "");
                s=s.Replace("drop", "");
                s=s.Replace("create", "");
                s=s.Replace("%", "");
                s=s.Replace("--", "");
            }
            return s;
        }
        /// <summary>
        /// 防js代码注入
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ClearScript(string s)
        {
            s = s.Replace("&", "&amp");
            s=s.Replace("<", "&lt");
            s=s.Replace(">", "&gt");
            //s.Replace("","&quot");
            return s;
        }
    }
}