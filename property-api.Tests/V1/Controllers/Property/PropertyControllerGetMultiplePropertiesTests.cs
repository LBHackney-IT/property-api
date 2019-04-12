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
using property_api.V1.Validation;

namespace UnitTests.V1.Controllers
{
    [TestFixture]
    public class PropertyControllerGetMultiplePropertiesTests
    {
        private PropertyController _classUnderTest;
        private Mock<IGetPropertyUseCase> _mockGetPropertyUseCase;
        private Mock<IGetMultiplePropertiesUseCase> _mockGetMultiplePropertiesUseCase;
        private Mock<ILogger<PropertyController>> _mockLogger;
        private IGetMultiplePropertiesValidator _getMultiplePropertiesValidator;

        [SetUp]
        public void SetUp()
        {
            _getMultiplePropertiesValidator = new GetMultiplePropertiesValidator();
            _mockGetPropertyUseCase = new Mock<IGetPropertyUseCase>();
            _mockLogger = new Mock<ILogger<PropertyController>>();
            _mockGetMultiplePropertiesUseCase = new Mock<IGetMultiplePropertiesUseCase>();
            _classUnderTest = new PropertyController(_mockGetPropertyUseCase.Object, _mockLogger.Object, _mockGetMultiplePropertiesUseCase.Object, _getMultiplePropertiesValidator);
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

        [TestCase("65", "57")]
        [TestCase("8", "9")]
        public void GivenAValidListOfMultipleProperyRefsWhenIExecuteThenTheUseCaseReturnsGetMultiplePropertiesUseCaseResponse(string propertyRef, string propertyRef2)
        {
            //arrange
            IList<Property> properties = new List<Property>
                    {
                        new Property
                        {
                            PropRef = propertyRef
                        },
                        new Property
                        {
                            PropRef = propertyRef2
                        }
                    };

            _mockGetMultiplePropertiesUseCase
                .Setup(v => v.Execute(It.Is<GetMultiplePropertiesUseCaseRequest>(i => i.PropertyRefs[0] == propertyRef && i.PropertyRefs[1] == propertyRef2)))
                .Returns(new GetMultiplePropertiesUseCaseResponse
                {
                    Properties = properties
                });

            IList<string> list = new List<string> { propertyRef, propertyRef2 };
            //act
            var actionResult = _classUnderTest.GetMultipleByReference(list);
            //assert
            actionResult.Should().NotBeNull();
            var okObjectResult = (OkObjectResult)actionResult;
            var response = (GetMultiplePropertiesUseCaseResponse)okObjectResult.Value;
            response.Should().NotBeNull();
            response.Properties.Should().NotBeNullOrEmpty();

            response.Properties.Should().BeOfType<List<Property>>();
            Assert.AreSame(propertyRef, response.Properties[0].PropRef);
            Assert.AreSame(propertyRef2, response.Properties[1].PropRef);
        }

        [TestCase(" ", "10")]
        [TestCase("", "7")]
        [TestCase("3", null)]
        public void GivenAnInvalidListOfMultiplePropertyRefsItShouldReturnBadInput(string propertyRef, string propertyRef2)
        {
            //arrange
            List<string> list = new List<string> { propertyRef, propertyRef2 };
            //act
            var actionResult = _classUnderTest.GetMultipleByReference(list);
            //assert
            actionResult.Should().BeOfType<BadRequestResult>();
        }

        //TO DO: valid 
    }
}
