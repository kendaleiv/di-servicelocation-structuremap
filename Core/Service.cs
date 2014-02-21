using System;

namespace Core
{
    public class Service : IService
    {
        public Service()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; private set; }
    }
}
