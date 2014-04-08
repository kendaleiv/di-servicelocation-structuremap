using Core;
using StructureMap;
using System;
using Xunit;

namespace Tests
{
    public class ValidationTests
    {
        [Fact]
        public void VerifyValidConfiguration()
        {
            ObjectFactory.Initialize(x =>
            {
                x.For<IService>().Use<Service>();
            });

            ObjectFactory.Container.AssertConfigurationIsValid();
        }

        [Fact]
        public void VerifyInvalidConfiguration()
        {
            ObjectFactory.Initialize(x =>
            {
                x.For<IService>().Use<BrokenService>();
            });

            Assert.Throws<StructureMapConfigurationException>(
                () => ObjectFactory.Container.AssertConfigurationIsValid());
        }

        public class BrokenService : IService
        {
            public string Id { get; private set; }

            [ValidationMethod]
            public void BrokenMethod()
            {
                throw new ApplicationException();
            }
        }
    }
}
