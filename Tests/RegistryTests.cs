using Core;
using StructureMap;
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
            ObjectFactory.Initialize(x =>
            {
                x.AddRegistry<ServiceRegistry>();
            });

            var service = ObjectFactory.GetInstance<IService>();

            Assert.IsType<Service>(service);
        }

        [Fact]
        public void Scan()
        {
            ObjectFactory.Initialize(x =>
            {
                x.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.LookForRegistries();
                });
            });

            var service = ObjectFactory.GetInstance<IService>();

            Assert.IsType<Service>(service);
        }
    }
}
