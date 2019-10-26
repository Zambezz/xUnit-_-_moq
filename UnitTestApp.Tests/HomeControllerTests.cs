using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using UnitTestApp.Controllers;
using UnitTestApp.Models;
using Xunit;

namespace UnitTestApp.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void IndexReturnsAViewResultWithAListOfPhones()
        {
            // Arrange
            var mock = new Mock<IRepository>();
            mock.Setup(repo => repo.GetAll()).Returns(GetTestPhones());
            var controller = new HomeController(mock.Object);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Phone>>(viewResult.Model);
            Assert.Equal(GetTestPhones().Count, model.Count());
        }
        private List<Phone> GetTestPhones()
        {
            var phones = new List<Phone>
            {
                new Phone { Id=1, Name="iPhone 7", Company="Apple", Price=900},
                new Phone { Id=2, Name="Meizu 6 Pro", Company="Meizu", Price=300},
                new Phone { Id=3, Name="Mi 5S", Company="Xiaomi", Price=400},
                new Phone { Id=4, Name="iPhone 7", Company="Apple", Price=900},
            };
            return phones;
        }
    
    //public void IndexViewDataMessage()
    //    {
    //        // Arrange
    //        HomeController controller = new HomeController();

    //        // Act
    //        ViewResult result = controller.Index() as ViewResult;

    //        // Assert
    //        Assert.Equal("Hello world!", result?.ViewData["Message"]);
    //    }

    //    [Fact]
    //    public void IndexViewResultNotNull()
    //    {
    //        // Arrange
    //        HomeController controller = new HomeController();
    //        // Act
    //        ViewResult result = controller.Index() as ViewResult;
    //        // Assert
    //        Assert.NotNull(result);
    //    }

    //    [Fact]
    //    public void IndexViewNameEqualIndex()
    //    {
    //        // Arrange
    //        HomeController controller = new HomeController();
    //        // Act
    //        ViewResult result = controller.Index() as ViewResult;
    //        // Assert
    //        Assert.Equal("Index", result?.ViewName);
    //    }
    }
}
