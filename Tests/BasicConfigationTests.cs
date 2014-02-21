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
                // appSetting myAppSetting does not exist, will use defaultValue
                x.For<IService>().Use<ServiceWithCtorArg>()
                    .Ctor<string>("id").EqualToAppSetting("myAppSetting", defaultValue: value);
            });

            var service = ObjectFactory.GetInstance<IService>();

            Assert.Equal(value, service.Id);
        }
    }
}
