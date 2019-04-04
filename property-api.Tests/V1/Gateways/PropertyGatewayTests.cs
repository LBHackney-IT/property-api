using NUnit.Framework;
using property_api.V1.Gateways;
using property_api.V1.Domain;
using property_api.V1.Infrastructure;
using Bogus;
using System;
using AutoMapper;
using property_api.V1.Factory;
using UnitTests.V1.Helpers;
using System.Collections.Generic;
using FluentAssertions;
using System.Linq;

namespace UnitTests.V1.Gateways
{
    [TestFixture]
    public class PropertyGatewayTests : DbTest
    {
        private PropertyGateway _classUnderTest;
        private PropertyFactory _factory;

        private readonly UhPropertyHelper _uhPropertyHelper = new UhPropertyHelper();

        [SetUp]
        public void Setup(){
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UhPropertyEntity, Property>());
            _factory = new PropertyFactory(config.CreateMapper());
            _classUnderTest = new PropertyGateway(_uhContext, _factory);
        }
        
        [Test]
        public void GatewayIsIPropertyGateway()
        {

            Assert.True(_classUnderTest is IPropertyGateway);
        }

        [Test]
        public void GatewayReturnsAPropertyWhenGivenARef()
        {

            var expectedProperty = _uhPropertyHelper.GenerateUhProperty();
            _uhContext.UhPropertys.Add(expectedProperty);
            _uhContext.SaveChanges();

            var response = _classUnderTest.GetPropertyByPropertyReference(expectedProperty.PropRef);

            Assert.NotNull(response);
            Assert.IsInstanceOf<Property>(response);
            Assert.AreEqual(expectedProperty.PropRef, response.PropRef);
            Assert.AreEqual(expectedProperty.Telephone, response.Telephone);
            Assert.AreEqual(expectedProperty.Address1, response.Address1);
        }

        [Test]
        public void GetawayReturnsNullWhenNotFound() {
            var response = _classUnderTest.GetPropertyByPropertyReference("foo");
            Assert.Null(response);
        }
    }

    [TestFixture]
    public class PropertyChildrenGatewayTests : DbTest
    {
        private IGetPropertyChildrenGateway _classUnderTest;
        private PropertyFactory _factory;

        private readonly UhPropertyHelper _uhPropertyHelper = new UhPropertyHelper();

        [SetUp]
        public void Setup()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UhPropertyEntity, Property>());
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
            var response = _classUnderTest.GetPropertyChild(parentReference);
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
            var response = _classUnderTest.GetPropertyChild(parentReference);
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
            var response = _classUnderTest.GetPropertyChild("foo");
            //assert
            response.Count().Should().Be(0);
        }
    }
}
