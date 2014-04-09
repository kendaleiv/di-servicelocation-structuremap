using Core;
using StructureMap;
using Xunit;

namespace Tests
{
    public class HelpfulErrorsTests
    {
        [Fact]
        public void MissingConfiguration()
        {
            var container = new Container();

            var exception = Assert.Throws<StructureMapConfigurationException>(
                () => container.GetInstance<IService>());

            var expectedMessage =
@"No default Instance is registered and cannot be automatically determined for type 'Core.IService'

There is no configuration specified for Core.IService

1.) Container.GetInstance(Core.IService)
";

            Assert.Equal(expectedMessage, exception.Message);
        }
    }
}
