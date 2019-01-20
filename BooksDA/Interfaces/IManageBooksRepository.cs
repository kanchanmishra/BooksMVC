using BooksDA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksDA.Interfaces
{
    public interface IManageBooksRepository
    {      
        void AddToList(BookUser BookUser);
        void RemoveFromList(BookUser BookUser);
        Users GetAllUsers();
        Catalog GetBooks();
        List<BookUser> BookBorrowedbyUser { get; set; }
    }
}
