using Core;
using StructureMap;
using System.Diagnostics;
using Xunit;

namespace Tests
{
    public class TroubleshootingTests
    {
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
