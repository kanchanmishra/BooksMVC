using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksMVC;
using BooksMVC.Controllers;
using System.Web.Mvc;
using BooksDA.Interfaces;
using Moq;
using BooksDA.Repo;
using BookBL;
using BooksDA.Models;

namespace BooksMVC.Tests.Controllers
{
    [TestClass]
    public class BookManagementControllerTest
    {
        private Mock<IManageBooksRepository> mockRepo;
        private ManageBooks mangeBooks;

        [TestInitialize]
        public void Setup()
        {
            mockRepo = new Mock<IManageBooksRepository>();            
        }
        [TestMethod]       
        public void AddToListBLTest()
        {
            BookUser bookUser = new BookUser();
            mockRepo.Setup(s => s.AddToList(bookUser)).Verifiable();
            mangeBooks = new ManageBooks(mockRepo.Object);
            bookUser.BookId = "bk109";
            bookUser.UserId = "U02";            
            mangeBooks.AddToList(bookUser);
            Assert.IsNotNull(bookUser.BookId);
            Assert.IsNotNull(bookUser.UserId);
        }

        [TestMethod]
        public void RemovefromToListBLTest()
        {
            BookUser bookUser = new BookUser();
            mockRepo.Setup(s => s.RemoveFromList(bookUser)).Verifiable();
            mangeBooks = new ManageBooks(mockRepo.Object);
            bookUser.BookId = "bk109";
            bookUser.UserId = "U02";
            mangeBooks.RemoveFromList(bookUser);
            Assert.IsNotNull(bookUser.BookId);
            Assert.IsNotNull(bookUser.UserId);
        }

        [TestMethod]
        public void ShowBookControllerTest()
        {
            // Arrange

            BookManagementController controller = new BookManagementController(mockRepo.Object);

            // Action
            ViewResult result = controller.ShowBooks() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void EditCatalogTest()
        {
            // Arrange  
            BookManagementController controller = new BookManagementController(mockRepo.Object);

            // Action
            string id = "bk109";
            ViewResult result = controller.EditCatalog(id) as ViewResult;
            //To do: HttpContext for TempData that uses a custom session object. and test tempdata
            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void SaveCatalogTest()
        {
            // Arrange           
            //mockRepo.Setup(p => p.GetBook(It.IsAny<string>()));
            BookManagementController controller = new BookManagementController(mockRepo.Object);

            // Action
            string id = "bk109";
            ViewResult result = controller.SaveCatalog(id) as ViewResult;
            //To do: HttpContext for TempData that uses a custom session object. and test tempdata

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
