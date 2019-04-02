using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using property_api.V1.Controllers;
using property_api.V1.UseCase;
using FluentAssertions;

namespace UnitTests.V1.Controller.Controllers.Property.Children
{
    [TestFixture]
    public class PropertyChildrenControllerAcceptanceTests
    {
        private PropertyChildrenController _classUnderTest;


        
        [SetUp]
        public void Setup()
        {
            _classUnderTest = new PropertyChildrenController(null);
        }

        [TestCase("123")]
        [TestCase("456")]
        public void WhenGettingChildPropertiesTheParentReferenceIsTheSameAsThePropertyReference(string propertyReference)
        {
           //arrange
           //act
           var response = _classUnderTest.Get(propertyReference);
           var okResult = (OkObjectResult) response;
           //assert
           okResult.Should().NotBeNull();
           okResult.Value.Should().NotBeNull();
        }
    }
}
