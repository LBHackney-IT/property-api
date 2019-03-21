using property_api.V1.Factory;
using NUnit.Framework;
using property_api.V1.Infrastructure;
using property_api.V1.Domain;

namespace property_api.Tests 
{
    [TestFixture]
    public class PropertyFactoryTests
    {
        PropertyFactory _classUnderTest;
        
        [Test]
        public void ReturnsPropertyWhereThereIsNoMatch()
        {
            _classUnderTest = new PropertyFactory();

            var expectedResponse = new UHProperty();

            var response = _classUnderTest.FromUHProperty(expectedResponse);

            //Assert.AreEqual(new Property(), response);
            Assert.True(response is Property);
            Assert.Zero(response.PropRef);
            Assert.IsNull(response.Telephone);
        }
    }
}