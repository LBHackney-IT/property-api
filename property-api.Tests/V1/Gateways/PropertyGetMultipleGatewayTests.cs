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
        public void GivenAListOfPropRefs_WhenItIsExecuted_ThenItReturnsAListOfSpecifiedPropertyObjects(string propertyReference, string propertyReference2)
        {
            //arrange
            var property1 = _uhPropertyHelper.GenerateUhProperty();
            property1.PropRef = propertyReference;
            var property2 = _uhPropertyHelper.GenerateUhProperty();
            property2.PropRef = propertyReference2;

            _uhContext.UhPropertys.Add(property1);
            _uhContext.UhPropertys.Add(property2);
            _uhContext.SaveChanges();

            var propertyReferences = new List<string> { propertyReference, propertyReference2 };
            //act
            List<Property> propertiesList = _classUnderTest.GetMultiplePropertiesByPropertyListOfReferences(propertyReferences);
            //assert
            propertiesList.Should().NotBeNull();
            propertiesList.Should().BeOfType<List<Property>>();

            Assert.AreEqual(propertyReferences[0], propertiesList[0].PropRef);
            Assert.AreEqual(propertyReferences[1], propertiesList[1].PropRef);
        }

        [TestCase("4","7")]
        [TestCase("5","3")]
        public void GivenAListOfNonexistentPropRefs_WhenItIsExecuted_ThenItShouldReturnAnEmptyListOfProperties(string propertyReference, string propertyReference2)
        {
            //arrange
            var propertyReferences = new List<string> { propertyReference, propertyReference2 };
            //act
            List<Property> propertiesList = _classUnderTest.GetMultiplePropertiesByPropertyListOfReferences(propertyReferences);
            //assert
            propertiesList.Should().BeEmpty();
            propertiesList.Should().BeOfType<List<Property>>();
        }

        [Test]
        public void GivenANullPropRefsList_WhenItIsExecuted_ThenItShouldReturnNull()
        {
            //arrange
            List<string> propertyReferences = null;
            //act
            List<Property> propertiesList = _classUnderTest.GetMultiplePropertiesByPropertyListOfReferences(propertyReferences);
            //assert
            propertiesList.Should().BeNull();
        }
    }
}
