using FluentAssertions;
using NUnit.Framework;
using property_api.V1.Domain;
using property_api.V1.Factory;
using property_api.V1.Gateways;
using property_api.V1.Gateways.GetMultipleProperties;
using property_api.V1.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitTests;
using UnitTests.V1.Helpers;

namespace property_api.Tests.V1.Gateways
{
    public class PropertyGetMultipleGatewayTests : DbTest
    {
        private IGetMultiplePropertiesGateway _classUnderTest;

        private PropertyFactory _factory;

        private readonly PropertyTestHelper _uhPropertyHelper = new PropertyTestHelper();

        [SetUp]
        public void Setup()
        {
            var config = PropertyHelper.ConfigureMapper();
            _factory = new PropertyFactory(config.CreateMapper());
            _classUnderTest = new PropertyGateway(_uhContext, _factory);
        }

        [TestCase("1","2")]
        [TestCase("3","4")]
        public void GivenAListOfPropRefs_WhenItIsExecuted_ThenItReturnsAListOfSpecifiedPropertyObjects(string propertyRef, string propertyRef2)
        {
            //arrange
            var prop1 = _uhPropertyHelper.GenerateUhProperty();
            prop1.PropRef = propertyRef;
            var prop2 = _uhPropertyHelper.GenerateUhProperty();
            prop2.PropRef = propertyRef2;

            _uhContext.UhPropertys.Add(prop1);
            _uhContext.UhPropertys.Add(prop2);
            _uhContext.SaveChanges();

            var list = new List<string> { propertyRef, propertyRef2 };
            //act
            List<Property> propList = _classUnderTest.GetMultiplePropertiesByPropertyListOfReferences(list);
            //assert
            propList.Should().NotBeNull();
            propList.Should().BeOfType<List<Property>>();

            Assert.AreEqual(list[0], propList[0].PropRef);
            Assert.AreEqual(list[1], propList[1].PropRef);
        }

        [TestCase("4","7")]
        [TestCase("5","3")]
        public void GivenAListOfNonexistentPropRefs_WhenItIsExecuted_ThenItShouldReturnAnEmptyListOfProperties(string propertyRef, string propertyRef2)
        {
            //arrange
            var list = new List<string> { propertyRef, propertyRef2 };
            //act
            List<Property> propList = _classUnderTest.GetMultiplePropertiesByPropertyListOfReferences(list);
            //assert
            propList.Should().BeEmpty();
            propList.Should().BeOfType<List<Property>>();
        }

        [Test]
        public void GivenANullPropRefsList_WhenItIsExecuted_ThenItShouldReturnNull()
        {
            //arrange
            List<string> list = null;
            //act
            List<Property> propList = _classUnderTest.GetMultiplePropertiesByPropertyListOfReferences(list);
            //assert
            propList.Should().BeNull();
        }
    }
}
