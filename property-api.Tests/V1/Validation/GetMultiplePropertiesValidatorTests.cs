using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using property_api.V1.Validation;

namespace property_api.Tests.V1.Validation
{
    public class GetMultiplePropertiesValidatorTests
    {
        private IGetMultiplePropertiesValidator _classUnderTest;
        
        [SetUp]
        public void Setup()
        {
            _classUnderTest = new GetMultiplePropertiesValidator();
        }

        [TestCase("5","8")]
        [TestCase("00002303","00001234")]
        public void GivenAValidListofPropertyRefs_TheValidatorShouldReturnTrue(string propertyReference, string propertyReference2)
        {
            //arrange
            List<string> propertyReferences = new List<string> { propertyReference, propertyReference2 };
            //act
            bool validationResult = _classUnderTest.Validate(propertyReferences);
            //assert
            Assert.True(validationResult);
        }

        [TestCase(" ", "1")]
        [TestCase("2", "")]
        [TestCase(null, "3")]
        public void GivenAInvalidListofPropertyRefsTheValidatorShouldReturnFalse(string propertyReference, string propertyReference2)
        {
            //arrange
            List<string> propertyReferences = new List<string> { propertyReference, propertyReference2 };
            //act
            bool validationResult = _classUnderTest.Validate(propertyReferences);
            //assert
            Assert.False(validationResult);
        }

        [Test]
        public void GivenANullListTheValidatorShouldReturnFalse()
        {
            //arrange
            List<string> propertyReferences = null;
            //act
            bool validationResult = _classUnderTest.Validate(propertyReferences);
            //assert
            Assert.False(validationResult);
        }
    }
}
