using NUnit.Framework;
using property_api.V1.Gateways;
using property_api.V1.Domain;
using property_api.V1.Data.Entities;
using property_api.V1.Factory;
using UnitTests.V1.Helpers;
using property_api.V1.Helpers;

namespace UnitTests.V1.Gateways
{
    [TestFixture]
    public class PropertyGatewayTests : DbTest
    {
        private PropertyGateway _classUnderTest;
        private PropertyFactory _factory;

        private readonly PropertyTestHelper _uhPropertyHelper = new PropertyTestHelper();

        [SetUp]
        public void Setup(){
            var config = PropertyHelper.ConfigureMapper(); 
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
}
