using System.Collections.Generic;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using property_api.V1.Controllers;
using property_api.V1.UseCase.GetPropertyParent;
using property_api.V1.UseCase.GetPropertyParent.Models;

namespace UnitTests.V1.Controller.Controllers.Property.Parent
{
    [TestFixture]
    public class PropertyParentControllerTests
    {
        private PropertyParentController _classUnderTest;
        private Mock<IGetPropertyParentUseCase> _mockUseCase;

        [SetUp]
        public void Setup()
        {
            _mockUseCase = new Mock<IGetPropertyParentUseCase>();
            _classUnderTest = new PropertyParentController(_mockUseCase.Object);
        }

        [TestCase("567")]
        [TestCase("890")]
        public void WhenCallingGetAndTheUseCaseReturnsAResponseThenTheControllerReturnsThatResponse(string propertyReference)
        {
            //arrange
            _mockUseCase.Setup(s => s.Execute(It.Is<GetPropertyParentRequest>(i => i.PropertyReference == propertyReference))).Returns(
                new GetPropertyParentResponse
                {
                    Property = new property_api.V1.Domain.Property
                    {
                        MajorRef = propertyReference
                    }
                });
            //act
            var response = _classUnderTest.Get(propertyReference);
            var okResult = (OkObjectResult)response;
            //assert
            okResult.Should().NotBeNull();
            okResult.Value.Should().NotBeNull();
            var getPropertyParentResponse = okResult.Value as GetPropertyParentResponse;
            getPropertyParentResponse.Should().NotBeNull();
        }

        [TestCase("567")]
        [TestCase("890")]
        public void WhenCallingGetThenPropertyRefGetsPassedToUseCase(string propertyReference)
        {
            //arrange
            _mockUseCase.Setup(s => s.Execute(It.Is<GetPropertyParentRequest>(i => i.PropertyReference == propertyReference))).Returns(
                new GetPropertyParentResponse());
            //act
            var response = _classUnderTest.Get(propertyReference);
            var okResult = (OkObjectResult)response;
            //assert
            _mockUseCase.Verify(s => s.Execute(It.Is<GetPropertyParentRequest>(i => i.PropertyReference == propertyReference)), Times.Once);
        }
    }
}
