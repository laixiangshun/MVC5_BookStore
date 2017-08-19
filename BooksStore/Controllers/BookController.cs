using Ninject;
using BooksStore.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BooksStore.Models;
using System.Net.Mime;
using System.Text;
using BooksStore.Utils;

namespace BooksStore.Controllers
{
    public class BookController : BaseController
    {
        //使用构造函数进行注入
        private IBookService bookservice;
       
        public BookController(IBookService _bookservice)
        {
            bookservice = _bookservice;
        }

        //添加注释，依赖注入-此方法只使用与controller调用Service
        //[Ninject.Inject]
       // public IBookService _bookservice;
      
        public ActionResult Index()
        {
            List<Book> books = bookservice.getBooks();
            return View(books);
        }

        public JsonResult GetJson()
        {
            List<Book> list = new List<Book>(){
                new Book{name="C#",zuozhe="lai",createDate=DateTime.Now},
                new Book{name="java",zuozhe="dawei",createDate=DateTime.Parse("2017-04-24 12:25:30")}
            };
            //JsonResult result=new JsonResult();
            //result.ContentType="utf-8";
            return Json(list, null, Encoding.UTF8, JsonRequestBehavior.AllowGet);
        }
	}
}