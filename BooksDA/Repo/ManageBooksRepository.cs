using BooksDA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksDA.Models;
using BooksDA.Helper;

namespace BooksDA.Repo
{
    public class ManageBooksRepository : IManageBooksRepository
    {
        private Catalog booksCatalog = new Catalog();
        private Users users = new Users();
        public List<BookUser> BookBorrowedbyUser { get; set; }       
        public ManageBooksRepository()
        {            
            string path = "C:/Projects/SitecoreMVC/BooksMVC/XMLs/";
            
            // Books
            if (booksCatalog.Books == null)
                booksCatalog = XMLFileToObjectHelper.XMLFileToObject<Catalog>(string.Format("{0}Books.xml",path));
            // Users
            if (users.UserDetails == null)
                users = XMLFileToObjectHelper.XMLFileToObject<Users>(string.Format("{0}Users.xml", path));
        }
        public void AddToList(BookUser BookUser)
        {
            if (BookBorrowedbyUser == null)
                BookBorrowedbyUser = new List<BookUser>();
            BookBorrowedbyUser.Add(BookUser);
        }

        public void RemoveFromList(BookUser BookUser)
        {
            if (BookBorrowedbyUser != null )
                BookBorrowedbyUser.Remove(BookUser);
        }
        public Users GetAllUsers()
        {
            return users;
        }

        public Catalog GetBooks()
        {
            return booksCatalog;
        }

    }
}
