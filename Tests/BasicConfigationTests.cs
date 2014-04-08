using Core;
using StructureMap;
using System;
using Xunit;

namespace Tests
{
    public class BasicConfigationTests
    {
        [Fact]
        public void NamedInstance()
        {
            var container = new Container(x =>
            {
                x.For<IService>().Use<Service>().Named("A");
                x.For<IService>().Use<ServiceB>().Named("B");
            });

            var service = container.GetInstance<IService>("A");

            Assert.IsType<Service>(service);
        }

        [Fact]
        public void GetInstanceT_MultipleNamedInstances_LastInWins()
        {
            var container = new Container(x =>
            {
                x.For<IService>().Use<Service>().Named("A");
                x.For<IService>().Use<ServiceB>().Named("B");
            });

            var service = container.GetInstance<IService>();

            Assert.IsType<ServiceB>(service);
        }

        /// <remarks>
        /// This isn't the best practice.
        /// Demoing that specifying constructor parameters as part of wireup is possible.
        /// Ideally, other rules would make this unnecessary.
        /// </remarks>
        [Fact]
        public void ProvideConstructorDependencyManually()
        {
            var value = Guid.NewGuid().ToString();

            var container = new Container(x =>
            {
                x.For<IService>().Use<ServiceWithCtorArg>()
                    .Ctor<string>("id").Is(value);
            });

            var service = container.GetInstance<IService>();

            Assert.Equal(value, service.Id);
        }
    }
}
