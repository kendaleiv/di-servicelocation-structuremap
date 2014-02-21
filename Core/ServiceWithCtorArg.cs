namespace Core
{
    public class ServiceWithCtorArg : IService
    {
        public ServiceWithCtorArg(string id)
        {
            Id = id;
        }

        public string Id { get; private set; }
    }
}
