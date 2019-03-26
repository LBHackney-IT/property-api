using NUnit.Framework;
using property_api.V1.Gateways;
using property_api.V1.Domain;
using property_api.V1.Infrastructure;
using Bogus;
using System;
using AutoMapper;
using property_api.V1.Factory;

namespace UnitTests.V1.Gateways
{
    [TestFixture]
    public class PropertyGatewayTests : DbTest
    {
        private PropertyGateway _classUnderTest;
        private PropertyFactory _factory;

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

        private static Faker<Property> TestProperty()
        {
            var property = new Faker<Property>();
            property.RuleFor(u => u.PropRef, f => f.Random.Hash(length: 12));
            property.RuleFor(u => u.Telephone, f => f.Phone.PhoneNumber());
            property.RuleFor(u => u.Address1, f => f.Random.Hash(12));
            return property;
        }

        [Test]
        public void GatewayReturnsAPropertyWhenGivenARef()
        {
            var expectedProperty = TestProperty().Generate();

            UhProperty property = new UhProperty
            {
                PropRef = expectedProperty.PropRef, //db will generate this automatically
                Telephone = expectedProperty.Telephone,
                Address1 = expectedProperty.Address1,

                //non null fields
                NoSingleBeds = 1,
                NoDoubleBeds = 1,
                Dtstamp = DateTime.Now,
                ManagedProperty = false,
                Ownership = "test",
                Letable = false,
                Repairable = false,
                Lounge = false,
                Laundry = false,
                VisitorBed = false,
                Store = false,
                WardenFlat = false,
                Sheltered = false,
                Shower = false,
                Rtb = false,
                CoreShared = false,
                OnlineRepairs = false,
                Asbestos = false
            };

            _uhContext.UhPropertys.Add(property);
            _uhContext.SaveChanges();

            var response = _classUnderTest.GetPropertyByPropertyReference(property.PropRef);

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
}
