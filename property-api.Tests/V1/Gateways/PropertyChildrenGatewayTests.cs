using NUnit.Framework;
using property_api.V1.Gateways;
using property_api.V1.Domain;
using AutoMapper;
using property_api.V1.Factory;
using UnitTests.V1.Helpers;
using System.Collections.Generic;
using FluentAssertions;
using System.Linq;
using property_api.V1.Helpers;

namespace UnitTests.V1.Gateways
{
    [TestFixture]
    public class PropertyChildrenGatewayTests : DbTest
    {
        private IGetPropertyChildrenGateway _classUnderTest;
        private PropertyFactory _factory;

        private readonly PropertyTestHelper _uhPropertyHelper = new PropertyTestHelper();

        [SetUp]
        public void Setup()
        {
            var config = PropertyHelper.ConfigureMapper();
            _factory = new PropertyFactory(config.CreateMapper());
            _classUnderTest = new PropertyGateway(_uhContext, _factory);
        }

        [Test]
        public void GatewayIsIPropertyGateway()
        {
            Assert.True(_classUnderTest is IGetPropertyChildrenGateway);
        }

        [TestCase("9876")]
        [TestCase("4567")]
        public void GatewayReturnsChildPropertiesWhenThePropertyReferenceIsTheSameAsTheMajorReferenceOnTheChild(string parentReference)
        {
            //arrange
            var child = _uhPropertyHelper.GenerateUhProperty();
            child.MajorRef = parentReference;
            _uhContext.UhPropertys.Add(child);
            _uhContext.SaveChanges();
            //act
            var response = _classUnderTest.GetPropertyChildren(parentReference);
            //assert
            response.Should().BeOfType<List<Property>>();
            response.First().MajorRef.Should().BeEquivalentTo(parentReference);
        }

        [TestCase("0567")]
        [TestCase("2567")]
        public void GatewayReturnsChildrenPropertiesWhenThePropertyReferenceIsTheSameAsTheMajorReferenceOnTheChild(string parentReference)
        {
            //arrange
            var child1 = _uhPropertyHelper.GenerateUhProperty();
            var child2 = _uhPropertyHelper.GenerateUhProperty();

            child1.MajorRef = parentReference;
            child2.MajorRef = parentReference;

            _uhContext.UhPropertys.Add(child1);
            _uhContext.UhPropertys.Add(child2);
            _uhContext.SaveChanges();
            //act
            var response = _classUnderTest.GetPropertyChildren(parentReference);
            //assert
            response.Should().BeOfType<List<Property>>();
            response[0].MajorRef.Should().BeEquivalentTo(parentReference);
            response[1].MajorRef.Should().BeEquivalentTo(parentReference);
        }

        [Test]
        public void GatewayReturnsAnEmptyListIfThereAreNoChildren()
        {
            //arrange
            //act
            var response = _classUnderTest.GetPropertyChildren("foo");
            //assert
            response.Count().Should().Be(0);
        }

        [TestCase("1234")]
        [TestCase("45677")]
        public void GatewayReturnsOnlyChildrenWithMajorReferenceEqualToPropRef(string parentReference)
        {
            //arrange
            var child1 = _uhPropertyHelper.GenerateUhProperty();
            var child2 = _uhPropertyHelper.GenerateUhProperty();
            //set up only child 1 to have the same parent reference
            child1.MajorRef = parentReference;

            _uhContext.UhPropertys.Add(child1);
            _uhContext.UhPropertys.Add(child2);
            _uhContext.SaveChanges();

            //act
            var response = _classUnderTest.GetPropertyChildren(parentReference);

            //assert
            response.Count().Should().Be(1);
            response.First().MajorRef.Should().BeEquivalentTo(parentReference);
        }
    }
}
