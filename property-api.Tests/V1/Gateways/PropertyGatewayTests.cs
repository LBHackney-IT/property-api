using NUnit.Framework;
using property_api.V1.Gateways;
using property_api.V1.Domain;
using property_api.V1.Infrastructure;
using Bogus;
using System;
using AutoMapper;
using property_api.V1.Factory;
using UnitTests.V1.Helpers;

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
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UhProperty, Property>());
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

            var response = _classUnderTest.GetPropertyByPropertyReference(expectedProperty.PropertyRef);

            Assert.NotNull(response);
            Assert.IsInstanceOf<Property>(response);
            Assert.AreEqual(expectedProperty.PropertyRef, response.PropertyRef);
            Assert.AreEqual(expectedProperty.ParentRef, response.ParentRef);
            Assert.AreEqual(expectedProperty.Address, response.Address);
        }

        [Test]
        public void GetawayReturnsNullWhenNotFound() {
            var response = _classUnderTest.GetPropertyByPropertyReference("foo");
            Assert.Null(response);
        }
    }
}
