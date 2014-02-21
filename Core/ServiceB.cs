using System;

namespace Core
{
    public class ServiceB : IService
    {
        public ServiceB()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; private set; }
    }
}
