using StructureMap;

namespace Core
{
    public static class ServiceLocator
    {
        public static T GetInstance<T>()
        {
            return ObjectFactory.Container.GetInstance<T>();
        }
    }
}
