using System;
using System.Collections.Generic;
using MBookLibrary.Business;
using MBookLibrary.Models;
using MBookLibrary.Service.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace MBookLibrary.Service.Test
{
    public class BooksControllerUnitTest
    {
        [Fact]
        public void TestFirstBook()
        {
            // Arrange
            var mockRepo = new Mock<IBookService>();
            mockRepo.Setup(repo => repo.GetById(1))
                .Returns(GetFirstBook());
            var controller = new BooksController(mockRepo.Object);

            //Act
            var result = controller.Get(1);

            //Assert
            var viewResult = Assert.IsType<ActionResult<BookModel>>(result);
            var model = Assert.IsAssignableFrom<BookModel>(viewResult);
            Assert.Equal("First Book", model.Title);

        }

        private BookModel GetFirstBook()
        {
            return new BookModel() { Id = 1, Title = "First Book" };
        }
    }
}
