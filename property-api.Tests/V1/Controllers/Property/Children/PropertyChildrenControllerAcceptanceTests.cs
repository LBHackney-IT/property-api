using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using property_api.V1.Controllers;
using property_api.V1.UseCase;
using FluentAssertions;
using property_api.V1.Factory;
using property_api.V1.Gateways;
using property_api.V1.Infrastructure;
using property_api.V1.UseCase.GetPropertyChildren.Models;
using property_api.V1.UseCase.GetPropertyChildren;
using property_api.V1.UseCase.GetPropertyChildren.Impl;
using UnitTests.V1.Helpers;

namespace UnitTests.V1.Controller.AcceptanceTests { 
    [TestFixture]
    public class PropertyChildrenControllerAcceptanceTests : DbTest
    {
        private PropertyChildrenController _classUnderTest;
        private IGetPropertyChildrenUseCase _useCase;
        private PropertyFactory _factory;
        private readonly UhPropertyHelper _uhPropertyHelper = new UhPropertyHelper();


        [SetUp]
        public void Setup()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UhPropertyEntity, property_api.V1.Domain.Property>());
            _factory = new PropertyFactory(config.CreateMapper());
            var _gateway = new PropertyGateway(_uhContext, _factory);
            _useCase = new GetPropertyChildrenUseCase(_gateway);
            _classUnderTest = new PropertyChildrenController(_useCase);
        }

        [TestCase("123")]
        [TestCase("456")]
        public void WhenGettingChildPropertiesThePropertyReferenceIsTheSameAsTheMajorReferenceOnTheChild(string propertyReference)
        {
            //arrange
            var expectedProperty = _uhPropertyHelper.GenerateUhProperty();
            expectedProperty.MajorRef = propertyReference;
            _uhContext.UhPropertys.Add(expectedProperty);
            _uhContext.SaveChanges();
            //act
            var response = _classUnderTest.Get(propertyReference);
            var okResult = (OkObjectResult)response;
            //assert
            var getPropertyChildrenResponse = okResult.Value as GetPropertyChildrenResponse;
            getPropertyChildrenResponse.Children[0].MajorRef.Should().Be(propertyReference);
        }
    }
}
