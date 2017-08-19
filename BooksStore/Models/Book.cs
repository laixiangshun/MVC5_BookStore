using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksStore.Models
{
    public class Book
    {
        public int id { get; set; }
        public string name { get; set; }
        public string zuozhe { get; set; }

        public DateTime createDate { get; set; }
    }
}