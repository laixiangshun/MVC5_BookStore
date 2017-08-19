using BooksStore.Common.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooksStore.Controllers
{
    public class AntiSqlInjectController : Controller
    {
        //
        // GET: /AntiSqlInject/
       
        public ActionResult Index()
        {
          
            return View();
        }
        [HttpPost]
        [AntiSqlInjectMyAttribute] //自定义的切面：过滤
        public ActionResult Index(string name, string password)
        {
            ViewBag.name = name;
            ViewBag.password = password;
            return View();
        }
	}
}