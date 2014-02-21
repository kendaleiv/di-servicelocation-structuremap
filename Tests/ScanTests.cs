using Core;
using StructureMap;
using StructureMap.Configuration.DSL;
using StructureMap.Graph;
using System;
using Xunit;

namespace Tests
{
    public class ScanTests
    {
        public class ServiceRegistry : Registry
        {
            public ServiceRegistry()
            {
                For<IService>().Use<Service>();
            }
        }

        public class TestConvention : IRegistrationConvention
        {
            public void Process(Type type, Registry registry)
            {
                registry.For<IService>().Use<Service>();
            }
        }

        [Fact]
        public void ScanTheCallingAssemblyForRegistries()
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

        [Fact]
        public void ScanTheCallingAssemblyWithDefaultConventions()
        {
            ObjectFactory.Initialize(x =>
            {
                x.Scan(scan =>
                {
                    scan.AssemblyContainingType<IService>();
                    scan.WithDefaultConventions();
                });
            });

            var service = ObjectFactory.GetInstance<IService>();

            Assert.IsType<Service>(service);
        }

        [Fact]
        public void ScanTheCallingAssemblyWithCustomConventions()
        {
            ObjectFactory.Initialize(x =>
            {
                x.Scan(scan =>
                {
                    scan.AssemblyContainingType<IService>();
                    scan.Convention<TestConvention>();
                });
            });

            var service = ObjectFactory.GetInstance<IService>();

            Assert.IsType<Service>(service);
        }
    }
}
