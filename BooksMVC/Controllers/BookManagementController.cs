using BookBL;
using BooksDA.Interfaces;
using BooksDA.Models;
using BooksMVC.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooksMVC.Controllers
{
    public class BookManagementController :  Controller
    {
        private readonly IManageBooksRepository bookRepository;
        private  ManageBooks bookManagement;
              
        public BookManagementController(IManageBooksRepository bookRepository)
        {           
                this.bookRepository = bookRepository;               
        }
        public ActionResult ShowBooks()
        {

            bookManagement = ReturnSessionData();

            return View(bookManagement);
        }
        [HttpGet]
        public ActionResult EditCatalog(string Id)
        {
            bookManagement = ReturnSessionData();
            if (string.IsNullOrEmpty(Id))
                return RedirectToAction("ShowBooks");
            var  book = bookManagement.GetBook(Id);
            var users = HelperClass.UserListItems(bookRepository.GetAllUsers().UserDetails);
            ViewData["Users"] = users;            
            return View(book);
        }

        [HttpPost]
        [ActionName("EditCatalog")]
        public ActionResult SaveCatalog(string id)
        {
            bookManagement = ReturnSessionData();
            if (ModelState.IsValid)
            {
                string userId = Request.Form["ddlUserList"].ToString();
                BookUser bookUser = new BookUser();
                bookUser.BookId = id;
                bookUser.UserId = userId;
                // get it from Session
                var updatedRepo = bookRepository;
                if (this.Session != null && this.Session["BookRepositorySession"] != null)
                {
                    updatedRepo = HttpContext.Session["BookRepositorySession"] as IManageBooksRepository;
                }
                updatedRepo.AddToList(bookUser);
                bookManagement.GetAllBooks();
                Session["BookRepositorySession"] = updatedRepo;
                return RedirectToAction("ShowBooks");
            }
            return View();
        }
        private ManageBooks ReturnSessionData()
        {

            if (this.Session != null && this.Session["BookRepositorySession"] != null)
            {
                var repo = HttpContext.Session["BookRepositorySession"] as IManageBooksRepository;
                bookManagement = new ManageBooks(repo);
            }
            else
                bookManagement = new ManageBooks(bookRepository);

            return bookManagement;
        }
    }
}