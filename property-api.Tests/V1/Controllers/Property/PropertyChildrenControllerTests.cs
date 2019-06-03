using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using property_api.V1.Controllers;
using property_api.V1.Domain;
using property_api.V1.UseCase.GetPropertyChildren;
using property_api.V1.UseCase.GetPropertyChildren.Models;

namespace UnitTests.V1.Controllers
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
            var expectedResponse = new GetPropertyChildrenResponse
            {
                Children = new List<Property>
                    {
                        new Property
                        {
                           MajorRef = propertyReference
                        }
                    }
            };

            _mockUseCase.Setup(s => s.Execute(It.Is<GetPropertyChildrenRequest>(i => i.PropertyReference == propertyReference))).Returns(expectedResponse);
            //act
            var response = _classUnderTest.Get(propertyReference);
            var okResult = (OkObjectResult)response;
            var resultContent = (GetPropertyChildrenResponse)okResult.Value;
            //assert
            okResult.Should().NotBeNull();
            okResult.Value.Should().NotBeNull();
            resultContent.Should().NotBeNull();
            JsonConvert.SerializeObject(expectedResponse).Should().BeEquivalentTo(JsonConvert.SerializeObject(resultContent));
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
