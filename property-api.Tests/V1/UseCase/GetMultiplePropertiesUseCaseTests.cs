using FluentAssertions;
using Moq;
using NUnit.Framework;
using property_api.V1.Domain;
using property_api.V1.Gateways.GetMultipleProperties;
using property_api.V1.UseCase.GetMultipleProperties;
using property_api.V1.UseCase.GetMultipleProperties.Boundaries;
using property_api.V1.UseCase.GetMultipleProperties.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace property_api.Tests.V1.UseCase
{
    public class GetMultiplePropertiesUseCaseTests
    {
        private IGetMultiplePropertiesUseCase _classUnderTest;
        private Mock<IGetMultiplePropertiesGateway> _mockGetMultiplePropertiesGateway;

        [SetUp]
        public void Setup()
        {
            _mockGetMultiplePropertiesGateway = new Mock<IGetMultiplePropertiesGateway>();
            _classUnderTest = new GetMultiplePropertiesUseCase(_mockGetMultiplePropertiesGateway.Object);
        }

        [TestCase("1","2")]
        [TestCase("3","4")]
        public void GivenARequestContainingAListOfPropRefs_WhenIExecuteTheUseCase_ThenTheListOfPropRefsGetsPassedIntoTheGateway(string propertyReference, string propertyReference2)
        {
            //arrange
            var propertyReferences = new List<string> { propertyReference, propertyReference2 };
            var request = new GetMultiplePropertiesUseCaseRequest { PropertyReferences = propertyReferences };
            //act
            _classUnderTest.Execute(request);
            //assert
            _mockGetMultiplePropertiesGateway.Verify(g => g.GetMultiplePropertiesByPropertyListOfReferences(It.Is<List<string>>(arg => arg[0] == propertyReferences[0] && arg[1] == propertyReferences[1])), Times.Once);

        }

        [TestCase("1","2")]
        [TestCase("3","4")]
        public void GivenARequestContainingAListOfPropRefs_WhenIExecuteTheUseCase_ThenIGetAResponseObjectContainingListOfPropertiesBack(string propertyReference, string propertyReference2)
        {
            //arrange
            var propertyReferences = new List<string> { propertyReference, propertyReference2 };
            var request = new GetMultiplePropertiesUseCaseRequest { PropertyReferences = propertyReferences };

            var listOfProperties = new List<Property> { new Property { PropRef = propertyReference }, new Property { PropRef = propertyReference2 } };

            _mockGetMultiplePropertiesGateway
                .Setup(g => g.GetMultiplePropertiesByPropertyListOfReferences(It.Is<List<string>>(arg => arg[0] == propertyReferences[0] && arg[1] == propertyReferences[1])))
                .Returns( listOfProperties );

            //act
            GetMultiplePropertiesUseCaseResponse response = _classUnderTest.Execute(request);
            //assert
            response.Should().NotBeNull();
            response.Should().BeOfType<GetMultiplePropertiesUseCaseResponse>();

            response.Properties.Should().NotBeNull();
            response.Properties.Should().BeOfType<List<Property>>();

            Assert.AreSame(propertyReferences[0], response.Properties[0].PropRef);
            Assert.AreSame(propertyReferences[1], response.Properties[1].PropRef);
        }
    }
}
