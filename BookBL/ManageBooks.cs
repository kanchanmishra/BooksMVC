using BooksDA.Interfaces;
using BooksDA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBL
{
    public class ManageBooks : IManageBooks
    {
        
        private Catalog booksCatalog = new Catalog();        
        private readonly IManageBooksRepository iManageBooksRepository;

        public ManageBooks(IManageBooksRepository iManageBooksRepository)
        {
            this.iManageBooksRepository = iManageBooksRepository;
        }
        public void AddToList(BookUser BookUser) {

            try
            {
                if (BookUser != null && (!string.IsNullOrEmpty(BookUser.BookId) && !string.IsNullOrEmpty(BookUser.UserId)))
                {
                    iManageBooksRepository.AddToList(BookUser);
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Book and User should not be null.");
            }

        }
        public void RemoveFromList(BookUser BookUser) {
            try
            {
                if (BookUser != null && (!string.IsNullOrEmpty(BookUser.BookId) && !string.IsNullOrEmpty(BookUser.UserId)))
                {
                    iManageBooksRepository.RemoveFromList(BookUser);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Book and User should not be null.");
            }
        }
        public Catalog GetAllBooks()
        {
            try
            {
                // check if any book has been borrowed
                int i = 0;
                var booksRepo = iManageBooksRepository.GetBooks().Books;
                if (booksRepo != null && booksRepo.Count > 0)
                {
                    booksCatalog.Books = new List<Book>();
                    foreach (var book in iManageBooksRepository.GetBooks().Books)
                    {
                        Book newbook = new Book();
                        newbook = book;
                        if (IsBookBorrow(book.BookId))
                        {
                            var user = WhoBorrowed(book.BookId);
                            newbook.WhoBorrowed = user;
                        }
                        booksCatalog.Books.Add(newbook);
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("List is not available.");
            }

            return booksCatalog;
        }        

        public bool IsBookBorrow(string BookId)
        {
            bool result = false;
            try
            {
                result = (iManageBooksRepository.BookBorrowedbyUser != null && iManageBooksRepository.BookBorrowedbyUser.Count > 0) ? iManageBooksRepository.BookBorrowedbyUser.Exists(p => p.BookId == BookId) : false;
            }
            catch (Exception ex)
            {
                throw new Exception("List is not available.");
            }

            return result;
        }

        public string WhoBorrowed(string BookId)
        {
            string userName = string.Empty;

            try
            {
                if (iManageBooksRepository.BookBorrowedbyUser != null && iManageBooksRepository.BookBorrowedbyUser.Count > 0)
                {
                    string id = iManageBooksRepository.BookBorrowedbyUser.First(p => p.BookId == BookId).UserId;
                    if (!string.IsNullOrEmpty(id))
                        userName = iManageBooksRepository.GetAllUsers().UserDetails.Find(p => p.Id == id).Name;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Something has gone wrong");
            }
            return userName;
        }

        public Book GetBook(string id)
        {
            Book book = new Book();
            try
            {
                book = GetAllBooks().Books.First(p => p.BookId == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Something has gone wrong");
            }
            return book;
        }

    }
}
