using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using property_api.V1.Controllers;
using property_api.V1.UseCase.GetPropertyChildren;
using property_api.V1.UseCase.GetPropertyChildren.Models;

namespace UnitTests.V1.Controller.Controllers.Property.Children
{
    [TestFixture]
    public class PropertyChildrenControllerTests
    {
        private PropertyChildrenController _classUnderTest;
        private Mock<IGetPropertyChildrenUseCase> _mockUseCase;

        [SetUp]
        public void Setup()
        {
            _mockUseCase = new Mock<IGetPropertyChildrenUseCase>();
            _classUnderTest = new PropertyChildrenController(_mockUseCase.Object);
        }

        [TestCase("123")]
        [TestCase("456")]
        public void WhenCallingGetAndTheUseCaseReturnsAResponseThenTheControllerReturnsThatResponse(string propertyReference)
        {
            //arrange
            _mockUseCase.Setup(s => s.Execute(It.Is<GetPropertyChildrenRequest>(i => i.PropertyReference == propertyReference))).Returns(
                new GetPropertyChildrenResponse
                {
                    Children = new List<property_api.V1.Domain.Property>
                    {
                        new property_api.V1.Domain.Property
                        {
                           MajorRef = propertyReference
                        }
                    }
                });
            //act
            var response = _classUnderTest.Get(propertyReference);
            var okResult = (OkObjectResult)response;
            //assert
            okResult.Should().NotBeNull();
            okResult.Value.Should().NotBeNull();
            var getPropertyChildrenResponse = okResult.Value as GetPropertyChildrenResponse;
            getPropertyChildrenResponse.Should().NotBeNull();
        }

        [TestCase("123")]
        [TestCase("456")]
        public void WhenCallingGetThenPropertyRefGetsPassedToUseCase(string propertyReference)
        {
            //arrange
            _mockUseCase.Setup(s => s.Execute(It.Is<GetPropertyChildrenRequest>(i => i.PropertyReference == propertyReference))).Returns(
                new GetPropertyChildrenResponse());
            //act
            var response = _classUnderTest.Get(propertyReference);
            var okResult = (OkObjectResult)response;
            //assert
            _mockUseCase.Verify(s => s.Execute(It.Is<GetPropertyChildrenRequest>(i => i.PropertyReference == propertyReference)), Times.Once);
        }
    }
}
