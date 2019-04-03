using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using property_api.V1.UseCase.GetPropertyParent;
using property_api.V1.UseCase.GetPropertyParent.Impl;

namespace property_api.Tests.V1.UseCase
{
    [TestFixture]
    public class GetPropertyParentUseCaseTests
    {
        private IGetPropertyParentUseCase _classUnderTest;

        [SetUp]
        public void Setup()
        {
            _classUnderTest = new GetPropertyParentUseCase();
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
