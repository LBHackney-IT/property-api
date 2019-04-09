using System;
using NUnit.Framework;
using Moq;
using Bogus;
using property_api.V1.Gateways;
using property_api.V1.Domain;
using property_api.V1.UseCase;

namespace UnitTests.V1.UseCase
{
    [TestFixture]
    public class GetPropertyUseCaseTests
    {
        private GetPropertyUseCase _classUnderTest;
        private Faker _faker;
        private Mock<IPropertyGateway> _gateway;

        [SetUp]
        public void Setup()
        {
            _gateway = new Mock<IPropertyGateway>();
            _classUnderTest = new GetPropertyUseCase(_gateway.Object);
            _faker = new Faker();
        }

        [Test]
        public void GetPropertyImplementsBoundaryInterface()
        {
            Assert.True(_classUnderTest is GetPropertyUseCase);
        }

        [Test]
        public void GetPropertyReturnsProperty()
        {
            // Arrange
            _gateway.Setup(method => method.GetPropertyByPropertyReference("foo")).Returns(new Property());
            // Act
            var respose = _classUnderTest.Execute("foo");
            // Assert
            Assert.IsNotNull(respose);
            Assert.IsInstanceOf<GetPropertyUseCase.GetPropertyByRefResponse>(respose);
        }

        [Test]
        public void ExecutesGetResponseFromGateway()
        {
            //Arrange
            var expectedResponse = new Property();
            expectedResponse.PropertyRef = _faker.Random.String(8);
            _gateway.Setup(method => method.GetPropertyByPropertyReference("foo")).Returns(expectedResponse);

            //Act
            var response = _classUnderTest.Execute("foo");

            //Assert
            Assert.NotNull(response);
            Assert.IsInstanceOf<GetPropertyUseCase.GetPropertyByRefResponse>(response);
            Assert.AreEqual(expectedResponse.PropertyRef, response.Property.PropertyRef);
        }
    }
}
