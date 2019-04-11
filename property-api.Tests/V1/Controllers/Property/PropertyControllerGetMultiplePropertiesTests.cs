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
using FluentAssertions;
using property_api.V1.UseCase.GetMultipleProperties;

namespace UnitTests.V1.Controllers
{
    [TestFixture]
    public class PropertyControllerGetMultiplePropertiesTests
    {
        private PropertyController _classUnderTest;
        private Mock<IGetPropertyUseCase> _mockGetPropertyUseCase;
        private Mock<IGetMultiplePropertiesUseCase> _mockGetMultiplePropertiesUseCase;
        private Mock<ILogger<PropertyController>> _mockLogger;
        private Faker faker = new Faker("en_GB");

        [SetUp]
        public void SetUp()
        {
            _mockGetPropertyUseCase = new Mock<IGetPropertyUseCase>();
            _mockLogger = new Mock<ILogger<PropertyController>>();
            _mockGetMultiplePropertiesUseCase = new Mock<IGetMultiplePropertiesUseCase>();
            _classUnderTest = new PropertyController(_mockGetPropertyUseCase.Object, _mockLogger.Object, _mockGetMultiplePropertiesUseCase.Object);
        }

        [TestCase("1", "2")]
        [TestCase("3", "4")]
        public void GivenAListOfMultiplePropertiesWhenIExecuteThenParametersArePassesIntoTheUseCase(string propertyRef, string propertyRef2)
        {
            //arrange
            var list = new List<string> { propertyRef, propertyRef2};
            //act
            _classUnderTest.GetMultipleByReference(list);
            //assert
            _mockGetMultiplePropertiesUseCase.Verify(v=> v.Execute(It.Is<GetMultiplePropertiesUseCaseRequest>(i=> i.PropertyRefs[0] == propertyRef && i.PropertyRefs[1] == propertyRef2)),Times.Once);
        }

        [TestCase("1", "2")]
        [TestCase("3", "4")]
        public void GivenAListOfMultiplePropertiesWhenIExecuteThenTheUseCaseReturnsGetMultiplePropertiesUseCaseResponse(string propertyRef, string propertyRef2)
        {
            //arrange
            var list = new List<string> { propertyRef, propertyRef2 };

            _mockGetMultiplePropertiesUseCase.Setup(v => v.Execute(It.Is<GetMultiplePropertiesUseCaseRequest>(i => i.PropertyRefs[0] == propertyRef && i.PropertyRefs[1] == propertyRef2)))
                .Returns(new GetMultiplePropertiesUseCaseResponse{
                    Properties = new List<Property>
                    {
                        new Property
                        {
                            PropRef = propertyRef
                        },
                        new Property
                        {
                            PropRef = propertyRef2
                        }
                    }
                    });
            //act
            var response = _classUnderTest.GetMultipleByReference(list);
            //assert
            response.Should().NotBeNull();
            
            response.pro.Should().NotBeNull();
            response.Should().BeOfType<GetMultiplePropertiesUseCaseResponse>();
        }
    }
}
