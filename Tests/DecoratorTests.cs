using Core;
using Moq;
using StructureMap;
using Xunit;

namespace Tests
{
    public class DecoratorTests
    {
        [Fact]
        public void EnrichWithLoggingService()
        {
            var logger = Mock.Of<ILogger>();
            Mock.Get(logger).Setup(x => x.Log(It.IsAny<string>()));

            var container = new Container(x =>
            {
                x.For<IService>().Use<Service>().DecorateWith("LoggingService", (context, svc) =>
                {
                    return new LoggingService(svc, logger);
                });
            });

            var service = container.GetInstance<IService>();
            var id = service.Id;

            Mock.Get(logger).Verify(x => x.Log(It.IsAny<string>()), Times.Once());
        }

        public class LoggingService : IService
        {
            private readonly IService _service;
            private readonly ILogger _logger;

            public LoggingService(IService service, ILogger logger)
            {
                _service = service;
                _logger = logger;
            }

            public string Id
            {
                get
                {
                    _logger.Log("Id getter called.");
                    return _service.Id;
                }
            }
        }

        public interface ILogger
        {
            void Log(string message);
        }
    }
}
