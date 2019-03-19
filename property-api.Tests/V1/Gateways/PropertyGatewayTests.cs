using NUnit.Framework;
using property_api.V1.Gateways; 
using property_api.V1.Domain; 
using property_api.V1.Infrastructure;
using Bogus;
using System;
using Microsoft.EntityFrameworkCore;

namespace UnitTests.V1.Gateways
{
    [TestFixture]
    public class PropertyGatewayTests
    {
        private PropertyGateway classUnderTest;
        private UhContext _uhContext;
    
        [SetUp]
        public void Setup(){
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();

            string TEST_UH_URL = Environment.GetEnvironmentVariable("TEST_UH_URL") ??
                                 @"Server=localhost;Database=uhsimulator;User Id='sa';Password='Rooty-Tooty';";

            builder.UseSqlServer(TEST_UH_URL);

            _uhContext = new UhContext(builder.Options);
            _uhContext.Database.BeginTransaction();

            classUnderTest = new PropertyGateway(_uhContext);
        }

        [Test]
        public void GatewayIsIPropertyGateway()
        {
            
            Assert.True(classUnderTest is IPropertyGateway);
        }

        private static Faker<Property> TestProperty()
        {
            var property = new Faker<Property>();
            // property.RuleFor(u => u.PropRef, f => f.Random.Hash(length: 12));
            // property.RuleFor(u => u.Telephone, f => f.Phone.PhoneNumber());
            return property;
        }

        // [Test]
        // public void GatewayReturnsAPropertyWhenGivenARef()
        // {
        //     var expectedProperty = TestProperty().Generate();

        //     _uhContext.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.property ON");
            
        //     _uhContext.UHPropertys.Add(new UHProperty());

        //     _uhContext.SaveChanges();

        //     var response = classUnderTest.GetPropertyByPropertyReference(expectedProperty.PropRef);

        //     Assert.NotNull(response);
        //     Assert.IsInstanceOf<Property>(response);
        //     Assert.AreEqual(expectedProperty.PropRef, response.PropRef);
        //     Assert.AreEqual(expectedProperty.Telephone, response.Telephone);
        // }

        // [Test]
        // public void GetawayReturnsVoid() {
        //     var response = classUnderTest.GetPropertyByPropertyReference("1212373");
        //     var property = new Faker<Property>();
        //     property.RuleFor(u => u.PropRef, f => f.Random.Hash(length: 12));
        //     property.RuleFor(u => u.Telephone, f => f.Phone.PhoneNumber());
        //     return property;
        // }
    }
}           