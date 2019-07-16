using System;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using property_api.V1.Controllers;
using FluentAssertions;
using property_api.V1.Factory;
using property_api.V1.Gateways;
using property_api.V1.UseCase.GetPropertyChildren.Models;
using UnitTests.V1.Helpers;
using property_api.V1.Helpers;
using Moq;
using Microsoft.Extensions.Logging;
using property_api.V1.UseCase.GetPropertyChildren;
using property_api.V1.UseCase.GetPropertyChildren.Impl;

namespace UnitTests.V1.Controllers 
{ 
    [TestFixture]
    public class PropertyControllerChildrenEndpointAcceptanceTests : DbTest
    {
        private PropertyController _classUnderTest;
        private IGetPropertyChildrenUseCase _useCase;
        private PropertyFactory _factory;
        private readonly PropertyTestHelper _uhPropertyHelper = new PropertyTestHelper();

        [SetUp]
        public void Setup()
        {
            var config = PropertyHelper.ConfigureMapper();
            _factory = new PropertyFactory(config.CreateMapper());
            var _gateway = new PropertyGateway(_uhContext, _factory);
            _useCase = new GetPropertyChildrenUseCase(_gateway);
            var mockLogger = new Mock<ILogger<PropertyController>>();
            _classUnderTest = new PropertyController(null, mockLogger.Object, null, _useCase);
        }

        [TestCase("123")]
        [TestCase("456")]
        public void PropertyReference_should_be_the_same_as_the_majorReference_on_response_property(string propertyReference)

        {
            //arrange
            var expectedProperty = _uhPropertyHelper.GenerateUhProperty();
            expectedProperty.MajorRef = propertyReference;
            _uhContext.UhPropertys.Add(expectedProperty);
            _uhContext.SaveChanges();

            //act
            var response = _classUnderTest.GetChildenProperties(propertyReference);
            var okResult = (OkObjectResult)response;

            //assert
            var getPropertyChildrenResponse = okResult.Value as GetPropertyChildrenResponse;
            getPropertyChildrenResponse.Children[0].MajorRef.Should().Be(propertyReference);
        }
    }
}
