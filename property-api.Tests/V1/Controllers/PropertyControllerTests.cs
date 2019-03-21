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
using property_api.V1.Boundary;
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
        public void ReturnsCorrectResponseWithOKStatus()
        {
            var expectedRestult = new Property
            {
                PropRef = faker.Random.Int(),
                Telephone = faker.Phone.PhoneNumber()
            };

            _mockGetPropertyUseCase.Setup(m => m.Execute(It.IsAny<string>())).Returns(expectedRestult);
            _classUnderTest = new PropertyController(_mockGetPropertyUseCase.Object,_mockLogger.Object);

            var response = _classUnderTest.GetByReference("foo");
            Assert.NotNull(response);
            Assert.AreEqual(200, ((ObjectResult)response).StatusCode);
            Assert.AreEqual(JsonConvert.SerializeObject(expectedRestult),
                            JsonConvert.SerializeObject(((ObjectResult)response).Value));
        }

        [Test]
        public void ReturnsCorrectResponseWithNotFoundStatus()
        {
            _mockGetPropertyUseCase.Setup(m => m.Execute(It.IsAny<string>()));
            _classUnderTest = new PropertyController(_mockGetPropertyUseCase.Object,_mockLogger.Object);

            var response = _classUnderTest.GetByReference("foo");
            Assert.NotNull(response);
            Assert.AreEqual(404, ((StatusCodeResult)response).StatusCode);
        }

        [Test]
        public void ReturnsCorrectResponseWithInternalServerError()
        {
            var expectedResult = new ErrorResponse
            {
                DeveloperMessage = faker.Lorem.Word(),
                UserMessage = "We had some issues processing your request"
            };

            _mockGetPropertyUseCase.Setup(m => m.Execute(It.IsAny<string>())).Throws(new Exception(expectedResult.DeveloperMessage));

            _classUnderTest = new PropertyController(_mockGetPropertyUseCase.Object,_mockLogger.Object);

            var response = _classUnderTest.GetByReference("foo");
            Assert.NotNull(response);
            Assert.AreEqual(500, ((ObjectResult)response).StatusCode);
            Assert.AreEqual(expectedResult.UserMessage, ((ErrorResponse)((ObjectResult)response).Value).UserMessage);
            Assert.AreEqual(expectedResult.DeveloperMessage, ((ErrorResponse)((ObjectResult)response).Value).DeveloperMessage);
        }
    }
}