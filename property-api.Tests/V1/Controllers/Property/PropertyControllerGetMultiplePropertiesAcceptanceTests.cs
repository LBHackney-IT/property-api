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
using property_api.V1.UseCase.GetMultipleProperties;
using FluentAssertions;
using property_api.V1.Validation;

namespace UnitTests.V1.Controllers
{
    [TestFixture]
    public class PropertyControllerGetMultiplePropertiesAcceptanceTests
    {
        private PropertyController _classUnderTest;
        private Mock<ILogger<PropertyController>> _mockLogger;
        private IGetMultiplePropertiesUseCase _getMultiplePropertiesUseCase;
        private IGetMultiplePropertiesValidator _getMultiplePropertiesValidator;

        [SetUp]
        public void SetUp()
        {
            _mockLogger = new Mock<ILogger<PropertyController>>();
            _getMultiplePropertiesValidator = new GetMultiplePropertiesValidator();
            //_getMultiplePropertiesUseCase = new GetMultiplePropertiesUseCase();
            _classUnderTest = new PropertyController(null, _mockLogger.Object, _getMultiplePropertiesUseCase, _getMultiplePropertiesValidator);
        }

        [TestCase("1", "2")]
        [TestCase("3", "4")]
        public void GivenMultiplePropRefsAreProvidedItShouldReturnTheMultiplePropertiesSpecified(string propRef1, string propRef2)
        {
            //arrange
            List<string> propRefs = new List<string> { propRef1, propRef2 };
            //act
            var actual = _classUnderTest.GetMultipleByReference(propRefs);
            //assert
            actual.Should().NotBeNull();
            var okObjectResult = (OkObjectResult)actual;
            var response = (GetMultiplePropertiesUseCaseResponse)okObjectResult.Value;
            response.Should().NotBeNull();
            response.Properties.Should().NotBeNullOrEmpty();

            response.Properties.Should().BeOfType<IList<Property>>();
            Assert.AreSame(propRef1, response.Properties[0].PropRef);
            Assert.AreSame(propRef2, response.Properties[1].PropRef);
        }
    }
}
