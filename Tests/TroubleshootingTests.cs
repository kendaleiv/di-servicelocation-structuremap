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
            ObjectFactory.Initialize(x =>
            {
                x.For<IService>().Use<Service>();
            });

            var whatDoIHave = ObjectFactory.WhatDoIHave();
            Trace.Write(whatDoIHave);
        }
    }
}
