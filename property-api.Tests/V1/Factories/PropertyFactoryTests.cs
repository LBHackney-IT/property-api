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
            Assert.IsNull(result.PropertyRef);
            Assert.IsNull(result.ParentRef);
        }

        [Test]
        public void ReturnsPopulatedProperty()
        {
            var uhProperty = _uhPropertyHelper.GenerateUhProperty();

            var result = _classUnderTest.FromUHProperty(uhProperty);

            Assert.True(result is Property);

            Assert.AreEqual(uhProperty.PropertyRef, result.PropertyRef);
            Assert.AreEqual(uhProperty.HierarchyCode, result.HierarchyCode);
            Assert.AreEqual(uhProperty.ParentRef, result.ParentRef);
            Assert.AreEqual(uhProperty.RepairCostCode, result.RepairCostCode);
            Assert.AreEqual(uhProperty.PostCode, result.PostCode);
            Assert.AreEqual(uhProperty.AreaOffice, result.AreaOffice);
            Assert.AreEqual(uhProperty.PropertyTypeCode, result.PropertyTypeCode);
            Assert.AreEqual(uhProperty.Letable, result.Letable);
            Assert.AreEqual(uhProperty.PropertyCategoryType, result.PropertyCategoryType);
            Assert.AreEqual(uhProperty.OccupationStatus, result.OccupationStatus);
            Assert.AreEqual(uhProperty.HeatingType, result.HeatingType);
            Assert.AreEqual(uhProperty.RepairArea, result.RepairArea);
            Assert.AreEqual(uhProperty.RentCostCentre, result.RentCostCentre);
            Assert.AreEqual(uhProperty.ArrearsPatchCode, result.ArrearsPatchCode);
            Assert.AreEqual(uhProperty.NumberOfBedrooms, result.NumberOfBedrooms);
            Assert.AreEqual(uhProperty.CommunalLifts, result.CommunalLifts);
            Assert.AreEqual(uhProperty.EntranceLevel, result.EntranceLevel);
            Assert.AreEqual(uhProperty.NumberOfSingleBedrooms, result.NumberOfSingleBedrooms);
            Assert.AreEqual(uhProperty.NumberOfDoubleBedrooms, result.NumberOfDoubleBedrooms);
            Assert.AreEqual(uhProperty.Address, result.Address);
        }
    }
}
