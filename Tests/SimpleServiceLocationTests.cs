using Core;
using StructureMap;
using Xunit;

namespace Tests
{
    public class SimpleServiceLocationTests
    {
        [Fact]
        public void ServiceLocation()
        {
            ObjectFactory.Initialize(x =>
            {
                x.For<IService>().Use<Service>();
            });

            var service = ObjectFactory.GetInstance<IService>();

            Assert.IsType<Service>(service);
        }

        [Fact]
        public void UsingFacade()
        {
            ObjectFactory.Initialize(x =>
            {
                x.For<IService>().Use<Service>();
            });

            var service = ServiceLocator.GetInstance<IService>();

            Assert.IsType<Service>(service);
        }
    }
}
