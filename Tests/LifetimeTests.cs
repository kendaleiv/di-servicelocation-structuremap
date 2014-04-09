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
            var container = new Container(x =>
            {
                x.For<IService>().LifecycleIs<HybridLifecycle>().Use<Service>();
            });

            var instance1 = container.GetInstance<IService>();
            var instance2 = container.GetInstance<IService>();

            Assert.Equal(instance1.Id, instance2.Id);
        }

        [Fact]
        public void HybridSession()
        {
            var container = new Container(x =>
            {
                x.For<IService>().LifecycleIs<HybridSessionLifecycle>().Use<Service>();
            });

            var instance1 = container.GetInstance<IService>();
            var instance2 = container.GetInstance<IService>();

            Assert.Equal(instance1.Id, instance2.Id);
        }

        [Fact]
        public void Singleton()
        {
            var container = new Container(x =>
            {
                x.For<IService>().Singleton().Use<Service>();
            });

            var instance1 = container.GetInstance<IService>();
            var instance2 = container.GetInstance<IService>();

            Assert.Equal(instance1.Id, instance2.Id);
        }

        [Fact]
        public void Transient()
        {
            var container = new Container(x =>
            {
                x.For<IService>().Transient().Use<Service>();
            });

            var instance1 = container.GetInstance<IService>();
            var instance2 = container.GetInstance<IService>();

            Assert.NotEqual(instance1.Id, instance2.Id);
        }
    }
}
