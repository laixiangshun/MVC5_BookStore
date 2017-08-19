using BooksStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksStore.Service
{
   public interface IBookService
    {
        List<Book> getBooks();
    }
}
