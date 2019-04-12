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

        [TestCase(" ", "1")]
        [TestCase("2", "")]
        [TestCase(null, "3")]
        public void GivenAInvalidListofPropertyRefsTheValidatorShouldReturnFalse(string propertyRef, string propertyRef2)
        {
            //arrange
            List<string> propList = new List<string> { propertyRef, propertyRef2 };
            //act
            bool validationResult = _classUnderTest.Validate(propList);
            //assert
            Assert.False(validationResult);
        }


    }
}
