using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Logger;
using System.ServiceModel;

namespace LogerTest
{
    [TestFixture]
    public class LogerServerTest
    {
        [Test]
        public void LogerServerKonstruktorTest()
        {
            Assert.DoesNotThrow(() => new LogerServer());
        }

        [Test]
        public void LogerServerServiceHostNotNull()
        {
            var server = new LogerServer();
            Assert.NotNull(server.serviceHost);
        }
    }
}
