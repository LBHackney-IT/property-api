using property_api.V1.Factory;
using NUnit.Framework;
using property_api.V1.Infrastructure;
using property_api.V1.Domain;
using Newtonsoft.Json;

namespace property_api.Tests
{
    [TestFixture]
    public class PropertyFactoryTests
    {
        PropertyFactory _classUnderTest;

        [Test]
        public void ReturnsEmptyPropertyWhereThereIsNoMatch()
        {
            _classUnderTest = new PropertyFactory();
            var expectedResponse = new UhProperty();
            var result = _classUnderTest.FromUHProperty(expectedResponse);

            Assert.True(result is Property);
            Assert.IsNull(result.PropRef);
            Assert.IsNull(result.Telephone);
        }

        [Test]
        public void ReturnsPopulatedProperty()
        {
            _classUnderTest = new PropertyFactory();
            var uhProperty = new UhProperty
            {
                PropRef = "12345",
                Telephone = "123"
            };
            var result = _classUnderTest.FromUHProperty(uhProperty);

            var expectedResult = new Property
            {
                PropRef = "12345",
                Telephone = "123" 
            };

            Assert.AreEqual(JsonConvert.SerializeObject(expectedResult),
                            JsonConvert.SerializeObject(result));
            Assert.True(result is Property);
        }

    }
}
