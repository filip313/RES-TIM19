using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using ReplicatorReceiver;
using System.ServiceModel;

namespace ReplicatorReceiverTest
{
    [TestFixture]
    class ReceiverServerTest
    {
        [Test]
        public void ReceiverServerKonstruktorTest()
        {
            ReceiverServer server = new ReceiverServer();
            Assert.NotNull(server.serviceHost);
        }
    }
}
