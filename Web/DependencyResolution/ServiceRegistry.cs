using Core;
using StructureMap.Configuration.DSL;
using StructureMap.Web.Pipeline;

namespace Web.DependencyResolution
{
    public class ServiceRegistry : Registry
    {
        public ServiceRegistry()
        {
            For<IService>().LifecycleIs<HybridLifecycle>().Use<Service>();
        }
    }
}