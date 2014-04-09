using Core;
using StructureMap;
using System.Diagnostics;
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
            Trace.Write(whatDoIHave);
        }
    }
}
