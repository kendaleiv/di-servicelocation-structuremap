using Core;
using StructureMap;
using StructureMap.Graph;
using StructureMap.Configuration.DSL;
using Xunit;

namespace Tests
{
    public class RegistryTests
    {
        public class ServiceRegistry : Registry
        {
            public ServiceRegistry()
            {
                For<IService>().Use<Service>();
            }
        }

        [Fact]
        public void Add()
        {
            var container = new Container(x =>
            {
                x.AddRegistry<ServiceRegistry>();
            });

            var service = container.GetInstance<IService>();

            Assert.IsType<Service>(service);
        }

        [Fact]
        public void Scan()
        {
            var container = new Container(x =>
            {
                x.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.LookForRegistries();
                });
            });

            var service = container.GetInstance<IService>();

            Assert.IsType<Service>(service);
        }
    }
}
