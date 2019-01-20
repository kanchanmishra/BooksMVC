using BooksDA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksDA.Interfaces
{
    public interface IManageBooks
    {         
        Catalog GetAllBooks();        
        string WhoBorrowed(string BookId);
        Book GetBook(string id);
        void AddToList(BookUser BookUser);
        void RemoveFromList(BookUser BookUser);
    }
}
