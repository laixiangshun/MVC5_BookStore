using BooksStore.Models;
using BooksStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace BooksStore.Service.ServiceImpl
{
    public class BookServiceImpl:IBookService
    {
        private BookDao _bookDao;
        public BookServiceImpl(BookDao _bookdao)
        {
            _bookDao = _bookdao;
        }
        public List<Book> getBooks()
        {

            return _bookDao.getBooks();
        }
    }
}