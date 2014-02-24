using Core;
using StructureMap;
using Xunit;

namespace Tests
{
    public class ExtraInitializationTests
    {
        [Fact]
        public void OnCreation()
        {
            var ran = false;

            ObjectFactory.Initialize(x =>
            {
                x.For<IService>().Use<Service>().OnCreation((context, myService) =>
                {
                    // You could run a method on service in here, etc.
                    // For testing, we'll just modify the ran variable.

                    ran = true;
                });
            });

            var service = ObjectFactory.GetInstance<IService>();

            Assert.True(ran);
        }

        [Fact]
        public void SettingPropertyDuringInitialization_SetProperty()
        {
            ObjectFactory.Initialize(x =>
            {
                x.For<TypeWithSetter>().Use<TypeWithSetter>().SetProperty(svc => svc.Id = "value");
            });

            var service = ObjectFactory.GetInstance<TypeWithSetter>();

            Assert.Equal("value", service.Id);
        }
        
        [Fact]
        public void SettingPropertyDuringInitialization_WithProperty_EqualTo()
        {
            ObjectFactory.Initialize(x =>
            {
                x.For<TypeWithSetter>().Use<TypeWithSetter>().WithProperty("Id").EqualTo("value");
            });

            var service = ObjectFactory.GetInstance<TypeWithSetter>();

            Assert.Equal("value", service.Id);
        }

        [Fact]
        public void SettingPropertyDuringInitialization_WithProperty_EqualToAppSetting()
        {
            ObjectFactory.Initialize(x =>
            {
                x.For<TypeWithSetter>().Use<TypeWithSetter>().WithProperty("Id").EqualToAppSetting("Id");
            });

            var service = ObjectFactory.GetInstance<TypeWithSetter>();

            Assert.Equal("value", service.Id);
        }

        public class TypeWithSetter
        {
            public string Id { get; set; }
        }
    }
}
