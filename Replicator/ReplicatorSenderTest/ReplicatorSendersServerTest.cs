using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using ReplicatorSender;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ReplicatorSenderTest
{
    [TestFixture]
    public class ReplicatorSenderServerTest
    {
        [Test]
        public void ReplicatorSenderServerKonstruktorTest()
        { 
            Assert.DoesNotThrow(() => new ReplicatorSenderServer());
        }

        [Test]
        public void ReplicatorSenderServerServiceHostNotNull()
        {
            var server = new ReplicatorSenderServer();
            Assert.NotNull(server.serviceHost);
        }
    }
}
