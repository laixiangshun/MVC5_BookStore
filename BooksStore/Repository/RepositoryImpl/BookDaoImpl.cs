using BooksStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BooksStore.Repository.RepositoryImpl
{
    public class BookDaoImpl:BookDao
    {
        public List<Book> getBooks()
        {
            List<Book> books = new List<Book>(){
                new Book{name="C#",zuozhe="aitushen"},
                new Book{name="java",zuozhe="lai"}
            };
            return books;
        }
    }
}