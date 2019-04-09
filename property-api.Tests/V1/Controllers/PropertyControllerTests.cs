using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using property_api.V1.Controllers;
using property_api.V1.UseCase;
using property_api.V1.Domain;
using Moq;
using Bogus;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace UnitTests.V1.Controllers
{
    [TestFixture]
    public class ControllerTests
    {
        private PropertyController _classUnderTest;
        private Mock<IGetPropertyUseCase> _mockGetPropertyUseCase;
        private Mock<ILogger<PropertyController>> _mockLogger;
        private Faker faker = new Faker("en_GB");

        [SetUp]
        public void SetUp()
        {
            _mockGetPropertyUseCase = new Mock<IGetPropertyUseCase>();
            _mockLogger = new Mock<ILogger<PropertyController>>();
        }

        [Test]
        public void ReturnsCorrectResponseWithOkStatus()
        {
            var expectedResult = new GetPropertyUseCase.GetPropertyByRefResponse(new Property
            {
                PropertyRef = faker.Random.String(12),
                ParentRef = faker.Random.String(12)
            });

            _mockGetPropertyUseCase.Setup(m => m.Execute(It.IsAny<string>())).Returns(expectedResult);
            _classUnderTest = new PropertyController(_mockGetPropertyUseCase.Object,_mockLogger.Object);

            var response = _classUnderTest.GetByReference("foo");

            Assert.NotNull(response);
            Assert.AreEqual(200, ((ObjectResult)response).StatusCode);
            Assert.AreEqual(JsonConvert.SerializeObject(expectedResult.Property),
                            JsonConvert.SerializeObject(((ObjectResult)response).Value));
        }

        [Test]
        public void ReturnsCorrectResponseWhenNotFound()
        {
            var expectedResult = new GetPropertyUseCase.GetPropertyByRefResponse(null);

            _mockGetPropertyUseCase.Setup(m => m.Execute(It.IsAny<string>())).Returns(expectedResult);
            _classUnderTest = new PropertyController(_mockGetPropertyUseCase.Object,_mockLogger.Object);

            var response = _classUnderTest.GetByReference("foo");
            Assert.NotNull(response);
            Assert.IsInstanceOf(typeof(NotFoundResult), response);
        }
    }
}
