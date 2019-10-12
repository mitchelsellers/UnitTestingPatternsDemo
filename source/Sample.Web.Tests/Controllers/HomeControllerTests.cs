using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Sample.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Sample.Web.Tests.Controllers
{
    public class HomeControllerTests
    {
        private readonly HomeController _controller;
        private readonly Mock<ILogger<HomeController>> _loggerHomeControllerMock;

        public HomeControllerTests()
        {
            _loggerHomeControllerMock = new Mock<ILogger<HomeController>>();
            _controller = new HomeController(_loggerHomeControllerMock.Object);
        }

        [Fact]
        public void Privacy_ReturnsAViewResult_WithNullModel()
        {
            //Arrange

            //Act
            var result = _controller.Privacy();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.Model);
        }

        [Fact]
        public void Index_ReturnsAViewResult_WithNullModel()
        {
            //Arrange

            //Act
            var result = _controller.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);

        }
    }
}