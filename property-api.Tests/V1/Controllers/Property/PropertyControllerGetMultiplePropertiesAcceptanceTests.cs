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
using property_api.V1.Gateways.GetMultipleProperties;
using property_api.V1.Factory;
using property_api.V1.Helpers;
using property_api.V1.Gateways;
using UnitTests.V1.Helpers;
using property_api.V1.UseCase.GetMultipleProperties.Impl;
using property_api.V1.UseCase.GetMultipleProperties.Boundaries;

namespace UnitTests.V1.Controllers
{
    [TestFixture]
    public class PropertyControllerGetMultiplePropertiesAcceptanceTests : DbTest
    {
        private PropertyController _classUnderTest;
        private Mock<ILogger<PropertyController>> _mockLogger;
        private IGetMultiplePropertiesUseCase _getMultiplePropertiesUseCase;
        private IGetMultiplePropertiesValidator _getMultiplePropertiesValidator;
        private PropertyFactory _factory;
        private IGetMultiplePropertiesGateway _getMultiplePropertiesGateway;

        private readonly PropertyTestHelper _uhPropertyHelper = new PropertyTestHelper();

        [SetUp]
        public void SetUp()
        {
            var config = PropertyHelper.ConfigureMapper();
            _factory = new PropertyFactory(config.CreateMapper());

            _mockLogger = new Mock<ILogger<PropertyController>>();
            _getMultiplePropertiesValidator = new GetMultiplePropertiesValidator();

            _getMultiplePropertiesGateway = new PropertyGateway(_uhContext, _factory);
            _getMultiplePropertiesUseCase = new GetMultiplePropertiesUseCase(_getMultiplePropertiesGateway);
            _classUnderTest = new PropertyController(null, _mockLogger.Object, _getMultiplePropertiesUseCase, _getMultiplePropertiesValidator);
        }

        [TestCase("1", "2")]
        [TestCase("3", "4")]
        public void GivenListOfPropRefsAreProvided_WhenEndpointIsCalled_ThenItShouldReturnTheMultiplePropertiesSpecified(string propertyRef, string propertyRef2)
        {
            //arrange
            var prop1 = _uhPropertyHelper.GenerateUhProperty();
            prop1.PropRef = propertyRef;
            var prop2 = _uhPropertyHelper.GenerateUhProperty();
            prop2.PropRef = propertyRef2;

            _uhContext.UhPropertys.Add(prop1);
            _uhContext.UhPropertys.Add(prop2);
            _uhContext.SaveChanges();

            List<string> propRefs = new List<string> { propertyRef, propertyRef2 };
            //act
            var actual = _classUnderTest.GetMultipleByReference(propRefs);
            //assert
            actual.Should().NotBeNull();
            var okObjectResult = (OkObjectResult)actual;
            var response = (GetMultiplePropertiesUseCaseResponse)okObjectResult.Value;
            response.Should().NotBeNull();
            response.Properties.Should().NotBeNullOrEmpty();

            response.Properties.Should().BeOfType<List<Property>>();
            Assert.AreSame(propertyRef, response.Properties[0].PropRef);
            Assert.AreSame(propertyRef2, response.Properties[1].PropRef);
        }
    }
}
