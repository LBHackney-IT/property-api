using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using property_api.V1.Controllers;
using property_api.V1.UseCase;
using property_api.V1.Domain;
using Moq;
using Microsoft.Extensions.Logging;
using FluentAssertions;
using property_api.V1.UseCase.GetMultipleProperties;
using property_api.V1.Validation;
using property_api.V1.UseCase.GetMultipleProperties.Boundaries;

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
        public void GivenAListOfMultipleProperties_WhenIExecute_ThenParametersArePassedIntoTheUseCase(string propertyReference, string propertyReference2)
        {
            //arrange
            var propertyReferences = new List<string> { propertyReference, propertyReference2};
            //act
            _classUnderTest.GetMultipleByReference(propertyReferences);
            //assert
            _mockGetMultiplePropertiesUseCase.Verify(v=> v.Execute(It.Is<GetMultiplePropertiesUseCaseRequest>(i=> i.PropertyReferences[0] == propertyReference && i.PropertyReferences[1] == propertyReference2)), Times.Once);
        }

        [TestCase("65", "57")]
        [TestCase("8", "9")]
        public void GivenAValidListOfMultipleProperyRefs_WhenIExecute_ThenTheUseCaseReturnsGetMultiplePropertiesUseCaseResponse(string propertyReference, string propertyReference2)
        {
            //arrange
            IList<Property> properties = new List<Property>
                    {
                        new Property
                        {
                            PropRef = propertyReference
                        },
                        new Property
                        {
                            PropRef = propertyReference2
                        }
                    };

            _mockGetMultiplePropertiesUseCase
                .Setup(v => v.Execute(It.Is<GetMultiplePropertiesUseCaseRequest>(i => i.PropertyReferences[0] == propertyReference && i.PropertyReferences[1] == propertyReference2)))
                .Returns(new GetMultiplePropertiesUseCaseResponse
                {
                    Properties = properties
                });

            IList<string> propertyReferences = new List<string> { propertyReference, propertyReference2 };
            //act
            var actionResult = _classUnderTest.GetMultipleByReference(propertyReferences);
            //assert
            actionResult.Should().NotBeNull();
            var okObjectResult = (OkObjectResult)actionResult;
            var response = (GetMultiplePropertiesUseCaseResponse)okObjectResult.Value;
            response.Should().NotBeNull();
            response.Properties.Should().NotBeNullOrEmpty();

            response.Properties.Should().BeOfType<List<Property>>();
            Assert.AreSame(propertyReference, response.Properties[0].PropRef);
            Assert.AreSame(propertyReference2, response.Properties[1].PropRef);
        }

        [TestCase(" ", "10")]
        [TestCase("", "7")]
        [TestCase("3", null)]
        public void GivenAnInvalidListOfMultiplePropertyRefs_ItShouldReturnBadInput(string propertyReference, string propertyReference2)
        {
            //arrange
            List<string> propertyReferences = new List<string> { propertyReference, propertyReference2 };
            //act
            var actionResult = _classUnderTest.GetMultipleByReference(propertyReferences);
            //assert
            actionResult.Should().BeOfType<BadRequestResult>();
        }
    }
}
