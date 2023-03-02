using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using UnitTestScenarios.Mvc.Controllers;

namespace UnitTestScenarios.Mvc.Tests
{
    [TestFixture]
    public class HomeControllerTests
    {
        private HomeController _controller;

        [SetUp]
        public void Initialize()
        {
            var loggerMock = new Mock<ILogger<HomeController>>();
            _controller = new HomeController(loggerMock.Object);
        }

        [Test]
        public void HomeController_Index_ReturnsView()
        {

            var actResult = _controller.Index() as ViewResult;

            Assert.IsNotNull(actResult);
            Assert.That(actResult.ViewName, Is.EqualTo("Index"));
        }

        [Test]
        public void HomeController_Privacy_ReturnsView()
        {

            var actResult = _controller.Privacy() as ViewResult;

            Assert.IsNotNull(actResult);
            Assert.That(actResult.ViewName, Is.EqualTo("Privacy"));
        }
    }
}
