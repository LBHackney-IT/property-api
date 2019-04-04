using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using property_api.V1.Controllers;
using property_api.V1.UseCase;
using FluentAssertions;
using property_api.V1.UseCase.GetPropertyChildren.Models;

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
        public void WhenGettingChildPropertiesThePropertyReferenceIsTheSameAsTheMajorReferenceOnTheChild(string propertyReference)
        {
            //arrange
            //act
            var response = _classUnderTest.Get(propertyReference);
            var okResult = (OkObjectResult)response;
            //assert
            var getPropertyChildrenResponse = okResult.Value as GetPropertyChildrenResponse;
            getPropertyChildrenResponse.Children[0].MajorRef.Should().Be(propertyReference);
        }
    }
}
