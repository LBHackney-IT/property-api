using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private PropertyController _classUnderTest;
        private Mock<IGetPropertyChildrenUseCase> _mockUseCase;
        private Mock<ILogger<PropertyController>> _mockLogger;

        [SetUp]
        public void Setup()
        {
            _mockLogger = new Mock<ILogger<PropertyController>>();
            _mockUseCase = new Mock<IGetPropertyChildrenUseCase>();
            _classUnderTest = new PropertyController(null, _mockLogger.Object, null, _mockUseCase.Object);
        }

        [TestCase("123")]
        [TestCase("456")]
        public void Response_should_contain_response_from_children_usecase(string propertyReference)
        {
            //arrange
            var expectedResponse = new GetPropertyChildrenResponse
            {
                Children = new List<Property>
                {
                    new Property { MajorRef = propertyReference }
                }
            };

            _mockUseCase.Setup(s => s.Execute(It.Is<GetPropertyChildrenRequest>(i => i.PropertyReference == propertyReference)))
                .Returns(expectedResponse);

            //act
            var response = _classUnderTest.GetChildenProperties(propertyReference);
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
        public void Should_call_children_uset_case_once(string propertyReference)
        {
            //arrange
            _mockUseCase.Setup(s => s.Execute(It.Is<GetPropertyChildrenRequest>(i => i.PropertyReference == propertyReference)))
                .Returns(new GetPropertyChildrenResponse());

            //act
            var test = _classUnderTest.GetChildenProperties(propertyReference);

            //assert
            _mockUseCase.Verify(s => s.Execute(It.Is<GetPropertyChildrenRequest>(i => i.PropertyReference == propertyReference)), Times.Once);
        }
    }
}
