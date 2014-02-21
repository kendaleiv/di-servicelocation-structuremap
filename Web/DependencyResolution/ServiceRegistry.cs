using Core;
using StructureMap.Configuration.DSL;

namespace Web.DependencyResolution
{
    public class ServiceRegistry : Registry
    {
        public ServiceRegistry()
        {
            For<IService>().HybridHttpOrThreadLocalScoped().Use<Service>();
        }
    }
}