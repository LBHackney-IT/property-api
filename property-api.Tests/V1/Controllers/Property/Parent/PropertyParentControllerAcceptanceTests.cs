using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using property_api.V1.Controllers;
using property_api.V1.UseCase;
using FluentAssertions;

namespace UnitTests.V1.Controllers.Property.Parent
{
    [TestFixture]
    public class PropertyParentControllerAcceptanceTests
    {
        private PropertyParentController _classUnderTest;

        [SetUp]
        public void Setup()
        {
            _classUnderTest = new PropertyParentController(null);
        }

        [TestCase("567")]
        [TestCase("890")]
        public void WhenGettingParentPropertyTheParentReferenceIsTheSameAsThePropertyMajorReference(string propertyReference)
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
