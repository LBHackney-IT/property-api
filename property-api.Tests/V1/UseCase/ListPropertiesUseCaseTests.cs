using System;
using NUnit.Framework;
using Moq;

namespace propertyapi.Tests.V1.UseCase
{
    [TestFixture]
    public class GetPropertyUseCaseTests
    { 

        [Test]
        public void GetPropertyImplementsBoundaryInterface()
        {
            //Arrange
            var _classTest = new GetPropertyUseCase();

            //Assert
            Assert.True(_classTest is GetPropertyUseCase);
        }


        [Test]
        public void GetPropertyReturnsProperty()
        {
            var useCase = new GetPropertyUseCase();
            var respose = useCase.Execute();


            Assert.True(respose.property_ref is string);
        }

        [Test]
        public void ExecutesGetResponseFromGateway()
        {
            //Arrange
            var expectedResponse = "1234";
            var useCase = new GetPropertyUseCase();
           

            //Act
            var propertyGateway = new Mock<IPropertyGateway>();
            propertyGateway.Setup(method => method.GetProperty()).Returns(expectedResponse);
            var response = useCase.Execute();

            //Assert
            Assert.AreEqual(expectedResponse, response);
        }


    }

    public interface IPropertyGateway
    {
        string GetProperty();
    }

    public class PropertyGateway : IPropertyGateway
    {
        public string GetProperty()
        {
            return null;
        }
    }

    public class Property
    {
        public string property_ref { get; set; }
    }

    public interface IGetPropertyUseCase
    {
    }

    public class GetPropertyUseCase : IGetPropertyUseCase
    {
        public Property Execute()
        {
            return new Property
            {
                property_ref = "1234"
            };
        }
    }
}
