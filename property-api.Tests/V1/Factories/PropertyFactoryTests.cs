using property_api.V1.Factory;
using NUnit.Framework;
using property_api.V1.Infrastructure;
using property_api.V1.Domain;
using AutoMapper;
using Castle.Core.Internal;
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
            Assert.IsNull(result.MajorRef);
        }

        [Test]
        public void ReturnsPopulatedProperty()
        {
            var uhProperty = _uhPropertyHelper.GenerateUhProperty();

            var result = _classUnderTest.FromUHProperty(uhProperty);

            Assert.True(result is Property);

            Assert.AreEqual(uhProperty.PropRef, result.PropRef);
            Assert.AreEqual(uhProperty.LevelCode, result.LevelCode);
            Assert.AreEqual(uhProperty.MajorRef, result.MajorRef);
            Assert.AreEqual(uhProperty.ManScheme, result.ManScheme);
            Assert.AreEqual(uhProperty.PostCode, result.PostCode);
            Assert.AreEqual(uhProperty.PostDesig, result.PostDesig);
            Assert.AreEqual(uhProperty.ShortAddress, result.ShortAddress);
            Assert.AreEqual(uhProperty.AreaOffice, result.AreaOffice);
            Assert.AreEqual(uhProperty.SubtypCode, result.SubtypCode);
            Assert.AreEqual(uhProperty.Letable, result.Letable);
            Assert.AreEqual(uhProperty.CatType, result.CatType);
            Assert.AreEqual(uhProperty.OccStat, result.OccStat);
            Assert.AreEqual(uhProperty.Heating, result.Heating);
            Assert.AreEqual(uhProperty.RepArea, result.RepArea);
            Assert.AreEqual(uhProperty.PostPreamble, result.PostPreamble);
            Assert.AreEqual(uhProperty.UNom2, result.UNom2);
            Assert.AreEqual(uhProperty.ArrPatch, result.ArrPatch);
            Assert.AreEqual(uhProperty.NumBedrooms, result.NumBedrooms);
            Assert.AreEqual(uhProperty.CommLifts, result.CommLifts);
            Assert.AreEqual(uhProperty.EntLevel, result.EntLevel);
            Assert.AreEqual(uhProperty.CompAvail, result.CompAvail);
            Assert.AreEqual(uhProperty.NoSingleBeds, result.NoSingleBeds);
            Assert.AreEqual(uhProperty.NoDoubleBeds, result.NoDoubleBeds);
            Assert.AreEqual(uhProperty.Address1, result.Address1);
        }
    }
}
