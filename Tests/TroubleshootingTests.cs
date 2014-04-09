using Core;
using StructureMap;
using Xunit;

namespace Tests
{
    public class TroubleshootingTests
    {
        [Fact]
        public void ShowBuildPlan()
        {
            var container = new Container(x =>
            {
                x.For<IService>().Use<Service>();
            });

            var buildPlan = container.Model.For<IService>()
                .Default
                .DescribeBuildPlan();

            var expectedBuildPlan =
@"PluginType: Core.IService
Lifecycle: Transient
new Service()
";

            Assert.Equal(expectedBuildPlan, buildPlan);
        }

        [Fact]
        public void WhatDoIHave()
        {
            var container = new Container(x =>
            {
                x.For<IService>().Use<Service>();
            });

            var whatDoIHave = container.WhatDoIHave();

            var expectedWhatDoIHave = @"

===================================================================================================
PluginType           Namespace        Lifecycle     Description                           Name     
---------------------------------------------------------------------------------------------------
Func<TResult>        System           Transient     Open Generic Template for Func<>      (Default)
---------------------------------------------------------------------------------------------------
Func<T, TResult>     System           Transient     Open Generic Template for Func<,>     (Default)
---------------------------------------------------------------------------------------------------
IContainer           StructureMap     Singleton     Object:  StructureMap.Container       (Default)
---------------------------------------------------------------------------------------------------
IService             Core             Transient     Core.Service                          (Default)
---------------------------------------------------------------------------------------------------
Lazy<T>              System           Transient     Open Generic Template for Func<>      (Default)
===================================================================================================";

            Assert.Equal(expectedWhatDoIHave, whatDoIHave);
        }
    }
}
