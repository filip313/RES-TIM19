using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Reader1;
using System.ServiceModel;

namespace ReaderTest
{
    [TestFixture]
    public class ReaderServerTest
    {
        [Test]
        [TestCase("0")]
        [TestCase("2")]
        [TestCase("3")]
        public void ReaderServer_KonstruktorTest(string port)
        {
            ReaderServer server = null;
            Assert.DoesNotThrow(()=> server = new ReaderServer(port));
            Assert.NotNull(server.serviceHost);
            Assert.AreEqual(ReaderServer.dataSet.ToString(), port);
        }
    }
}
