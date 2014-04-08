using Core;
using StructureMap;
using StructureMap.Web.Pipeline;
using Xunit;

namespace Tests
{
    public class LifetimeTests
    {
        [Fact]
        public void Hybrid()
        {
            ObjectFactory.Initialize(x =>
            {
                x.For<IService>().LifecycleIs<HybridLifecycle>().Use<Service>();
            });

            var instance1 = ObjectFactory.GetInstance<IService>();
            var instance2 = ObjectFactory.GetInstance<IService>();

            Assert.Equal(instance1.Id, instance2.Id);
        }

        [Fact]
        public void HybridSession()
        {
            ObjectFactory.Initialize(x =>
            {
                x.For<IService>().LifecycleIs<HybridSessionLifecycle>().Use<Service>();
            });

            var instance1 = ObjectFactory.GetInstance<IService>();
            var instance2 = ObjectFactory.GetInstance<IService>();

            Assert.Equal(instance1.Id, instance2.Id);
        }

        [Fact]
        public void Singleton()
        {
            ObjectFactory.Initialize(x =>
            {
                x.For<IService>().Singleton().Use<Service>();
            });

            var instance1 = ObjectFactory.GetInstance<IService>();
            var instance2 = ObjectFactory.GetInstance<IService>();

            Assert.Equal(instance1.Id, instance2.Id);
        }

        [Fact]
        public void Transient()
        {
            ObjectFactory.Initialize(x =>
            {
                x.For<IService>().Transient().Use<Service>();
            });

            var instance1 = ObjectFactory.GetInstance<IService>();
            var instance2 = ObjectFactory.GetInstance<IService>();

            Assert.NotEqual(instance1.Id, instance2.Id);
        }
    }
}
