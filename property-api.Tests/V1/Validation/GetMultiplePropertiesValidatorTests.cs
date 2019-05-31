using System;
using System.Collections.Generic;
using NUnit.Framework;
using property_api.V1.UseCase.GetMultipleProperties.Boundaries;
using property_api.V1.Validation;

namespace UnitTests.V1.Validation
{
    public class GetMultiplePropertiesValidatorTests
    {
        private GetMultiplePropertiesValidator _classUnderTest;

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
            var propertiesUseCaseRequest = new GetMultiplePropertiesUseCaseRequest(new List<string> { propertyReference, propertyReference2 });
            //act
            bool validationResult = _classUnderTest.Validate(propertiesUseCaseRequest).IsValid;
            //assert
            Assert.True(validationResult);
        }

        [TestCase(" ", "1")]
        [TestCase("2", "")]
        [TestCase(null, "3")]
        public void GivenAnInvalidListofPropertyRefs_TheValidatorShouldReturnFalse(string propertyReference, string propertyReference2)
        {
            //arrange
            var propertiesUseCaseRequest = new GetMultiplePropertiesUseCaseRequest(new List<string> { propertyReference, propertyReference2 });
            //act
            bool validationResult = _classUnderTest.Validate(propertiesUseCaseRequest).IsValid;
            //assert
            Assert.False(validationResult);
        }

        [Test]
        public void GivenANullList_TheValidatorShouldReturnFalse()
        {
            //arrange
            var propertiesUseCaseRequest = new GetMultiplePropertiesUseCaseRequest(null);

            //act
            bool validationResult = _classUnderTest.Validate(propertiesUseCaseRequest).IsValid;
            //assert
            Assert.False(validationResult);
        }
    }
}
