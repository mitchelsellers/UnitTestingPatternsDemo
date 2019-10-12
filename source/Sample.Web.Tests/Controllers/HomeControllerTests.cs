using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Sample.Web.Controllers;
using Sample.Web.Models;
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
        private readonly Mock<IHttpContextAccessor> _httpContextAccessorMock;
        private readonly Mock<IActivityAccessor> _activityAccessorMock;

        public HomeControllerTests()
        {
            _loggerHomeControllerMock = new Mock<ILogger<HomeController>>();
            _httpContextAccessorMock = new Mock<IHttpContextAccessor>();
            _activityAccessorMock = new Mock<IActivityAccessor>();
            _controller = new HomeController(_loggerHomeControllerMock.Object, _httpContextAccessorMock.Object, _activityAccessorMock.Object);
        }

        [Fact]
        public void Error_ReturnsAViewResult_WithAnErrorModel()
        {
            //Arrange
            var defaultContext = new DefaultHttpContext();
            _httpContextAccessorMock.Setup(h => h.HttpContext).Returns(defaultContext).Verifiable();

            //Act
            var result = _controller.Error();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<ErrorViewModel>(viewResult.Model);
            _httpContextAccessorMock.Verify();
        }

        [Fact]
        public void Error_ReturnsAViewResult_WithAnErrorModel_IncludingTraceIdentifierInModel()
        {
            //Arrange
            var defaultContext = new DefaultHttpContext();
            defaultContext.TraceIdentifier = "Testing";
            _httpContextAccessorMock.Setup(h => h.HttpContext).Returns(defaultContext).Verifiable();

            //Act
            var result = _controller.Error();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<ErrorViewModel>(viewResult.Model);
            Assert.Equal(defaultContext.TraceIdentifier, model.RequestId);
            Assert.True(model.ShowRequestId);
            _httpContextAccessorMock.Verify();
        }

        [Fact]
        public void Error_ReturnsAViewResult_WithAnErrorModel_WithFalseShowRequestIdIfNull()
        {
            //Arrange
            var defaultContext = new DefaultHttpContext();
            _httpContextAccessorMock.Setup(h => h.HttpContext).Returns(defaultContext).Verifiable();

            //Act
            var result = _controller.Error();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<ErrorViewModel>(viewResult.Model);
            Assert.Equal(defaultContext.TraceIdentifier, model.RequestId);
            Assert.True(model.ShowRequestId);
            _httpContextAccessorMock.Verify();
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