using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using property_api.V1.UseCase.GetPropertyChildren;
using property_api.V1.UseCase.GetPropertyChildren.Impl;

namespace property_api.Tests.V1.UseCase
{
    [TestFixture]
    public class GetPropertyChildrenUseCaseTests
    {
        private IGetPropertyChildrenUseCase _classUnderTest;

        [SetUp]
        public void Setup()
        {
            _classUnderTest = new GetPropertyChildrenUseCase();
        }

        [Test]
        public void WhenExecutingCallsGatewayWithParameters()
        {
            //arrange

            //act

            //assert

        }
    }
}
