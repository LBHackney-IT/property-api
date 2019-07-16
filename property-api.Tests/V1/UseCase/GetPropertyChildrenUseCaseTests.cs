using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using property_api.V1.Domain;
using property_api.V1.Gateways;
using property_api.V1.UseCase.GetPropertyChildren;
using property_api.V1.UseCase.GetPropertyChildren.Impl;
using property_api.V1.UseCase.GetPropertyChildren.Models;
using FluentAssertions;

namespace UnitTests.V1.UseCase
{
    [TestFixture]
    public class GetPropertyChildrenUseCaseTests
    {
        private IGetPropertyChildrenUseCase _classUnderTest;
        private Mock<IGetPropertyChildrenGateway> _mockGateway;

        [SetUp]
        public void Setup()
        {
            _mockGateway = new Mock<IGetPropertyChildrenGateway>();
            _classUnderTest = new GetPropertyChildrenUseCase(_mockGateway.Object);
            
        }

        [TestCase("1223")]
        [TestCase("1224")]
        public void WhenExecutingCallsGatewayWithParameters(string propReference)
        {
            //arrange
            var request = new GetPropertyChildrenRequest
            {
                PropertyReference = propReference,
            };
            //act
            var response = _classUnderTest.Execute(request);
            //assert
            _mockGateway.Verify(v=> v.GetPropertyChildren(It.Is<string>(i=> i == propReference)), Times.Once);
        }

        [Test]
        public void WhenExecutingTheGatewayReturnsAListOfProperties()
        {
            //arrange
            _mockGateway.Setup(s=> s.GetPropertyChildren(It.IsAny<string>())).Returns(new List<Property>());
            //act
            var response = _classUnderTest.Execute(new GetPropertyChildrenRequest());
            //assert
            response.Should().NotBeNull();
            response.Should().BeOfType<GetPropertyChildrenResponse>();
            response.Children.Should().NotBeNull();
            response.Children.Should().BeOfType<List<Property>>();
        }

        [Test]
        public void When_executing_the_gateway_with_null_an_ArgumentNullException_is_thrown()
        {
            //arrange
            //act
            //assert
            Assert.Throws<ArgumentNullException>(() => _classUnderTest.Execute(null));
        }
    }
}
