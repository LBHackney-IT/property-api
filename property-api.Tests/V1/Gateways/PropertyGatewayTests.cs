using NUnit.Framework;
using property_api.V1.Gateways; 
using property_api.V1.Domain; 
using property_api.V1.Infrastructure;
using System;

namespace UnitTests.V1.Gateways
{
    [TestFixture]
    public class PropertyGatewayTests
    {
        private PropertyGateway classUnderTest;
        private UhContext dbContext;
    
        
        [SetUp]
        public void Setup(){
            classUnderTest = new PropertyGateway(dbContext);
        }

        [Test]
        public void GatewayIsIPropertyGateway()
        {
            
            Assert.True(classUnderTest is IPropertyGateway);
        }

        [Test]
        public void GatewayReturnsAProperty()
        {
            var dbProperty = new Property();
             
            var response = classUnderTest.GetPropertyByPropertyReference();


            Assert.NotNull(response);
            Assert.IsInstanceOf<Property>(response);
        }

        [Test]
        public void GetawayReturnsVoid() {
            var response = classUnderTest.GetPropertyByPropertyReference();
            Assert.Null(response);
        }
    }
}