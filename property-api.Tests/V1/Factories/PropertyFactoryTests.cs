using property_api.V1.Factory;
using NUnit.Framework;
using property_api.V1.Infrastructure;
using property_api.V1.Domain;
using AutoMapper;
using Bogus;
using UnitTests.V1.Helpers;

namespace UnitTests.V1.Factories
{
    [TestFixture]
    public class PropertyFactoryTests
    {
        private PropertyFactory _classUnderTest;
        private readonly UhPropertyHelper _uhPropertyHelper = new UhPropertyHelper();

        [SetUp]
        public void SetUp()
        {
            var mapperConfig = new MapperConfiguration(cfg => cfg.CreateMap<UhProperty, Property>());
            var mapper = mapperConfig.CreateMapper();
            _classUnderTest = new PropertyFactory(mapper);
        }

        [Test]
        public void ReturnsEmptyPropertyWhereThereIsNoMatch()
        {
            var expectedResponse = new UhProperty();
            var result = _classUnderTest.FromUHProperty(expectedResponse);

            Assert.True(result is Property);
            Assert.IsNull(result.PropRef);
            Assert.IsNull(result.Telephone);
        }

        [Test]
        public void ReturnsPopulatedProperty()
        {
            var uhProperty = _uhPropertyHelper.GenerateUhProperty();

            var result = _classUnderTest.FromUHProperty(uhProperty);

            Assert.True(result is Property);
            Assert.AreEqual(uhProperty.PropRef, result.PropRef);
            Assert.AreEqual(uhProperty.Telephone, result.Telephone);
            Assert.AreEqual(uhProperty.Address1, result.Address1);
            //Assert.AreEqual(JsonConvert.SerializeObject(expectedResult),
            //                JsonConvert.SerializeObject(result));
        }
    }
}
