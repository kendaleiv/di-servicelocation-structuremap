using Core;
using StructureMap;
using System;
using Xunit;

namespace Tests
{
    public class ValidationTests
    {
        [Fact]
        public void MissingRequiredConstructorArgument()
        {
            var container = new Container(x =>
            {
                x.For<IService>().Use<ServiceWithCtorArg>();
            });

            Assert.Throws<StructureMapConfigurationException>(
                () => container.AssertConfigurationIsValid());
        }

        [Fact]
        public void VerifyValidConfiguration()
        {
            var container = new Container(x =>
            {
                x.For<IService>().Use<Service>();
            });

            container.AssertConfigurationIsValid();
        }

        [Fact]
        public void VerifyInvalidConfiguration()
        {
            var container = new Container(x =>
            {
                x.For<IService>().Use<BrokenService>();
            });

            Assert.Throws<StructureMapConfigurationException>(
                () => container.AssertConfigurationIsValid());
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
