using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using property_api.V1.Controllers;
using property_api.V1.UseCase;
using property_api.V1.Domain;
using Moq;
using Newtonsoft.Json;

namespace UnitTests.V1.Controllers
{

    [TestFixture]
    public class ControllerTests
    {
        private PropertyController _classUnderTest;
        private Mock<IGetPropertyUseCase> _mockGetPropertyUseCase; 

        [SetUp]
        public void SetUp()
        {
            _mockGetPropertyUseCase = new Mock<IGetPropertyUseCase>();
        }

        [Test]
        public void ReturnsResponseWithStatus()
        {
            
            _mockGetPropertyUseCase.Setup(m => m.Execute()).Returns(new Property());
            _classUnderTest = new PropertyController(_mockGetPropertyUseCase.Object);

            var response = _classUnderTest.GetByReference("foo");


            var resultStatusCode = JsonConvert.SerializeObject(response.StatusCode);

            Assert.AreEqual("200", resultStatusCode);
        }
    }
}