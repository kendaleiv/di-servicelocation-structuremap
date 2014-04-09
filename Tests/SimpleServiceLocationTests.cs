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
            var container = new Container(x =>
            {
                x.For<IService>().Use<Service>();
            });

            var service = container.GetInstance<IService>();

            Assert.IsType<Service>(service);
        }

        [Fact]
        public void UsingFacade()
        {
            ObjectFactory.Container.Configure(x =>
            {
                x.For<IService>().Use<Service>();
            });

            var service = ServiceLocator.GetInstance<IService>();

            Assert.IsType<Service>(service);
        }
    }
}
