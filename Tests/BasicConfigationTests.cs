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
            ObjectFactory.Initialize(x =>
            {
                x.For<IService>().Use<Service>().Named("A");
                x.For<IService>().Use<ServiceB>().Named("B");
            });

            var service = ObjectFactory.GetNamedInstance<IService>("A");

            Assert.IsType<Service>(service);
        }

        [Fact]
        public void GetInstanceT_MultipleNamedInstances_LastInWins()
        {
            ObjectFactory.Initialize(x =>
            {
                x.For<IService>().Use<Service>().Named("A");
                x.For<IService>().Use<ServiceB>().Named("B");
            });

            var service = ObjectFactory.GetInstance<IService>();

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

            ObjectFactory.Initialize(x =>
            {
                x.For<IService>().Use<ServiceWithCtorArg>()
                    .Ctor<string>("id").Is(value);
            });

            var service = ObjectFactory.GetInstance<IService>();

            Assert.Equal(value, service.Id);
        }
    }
}
