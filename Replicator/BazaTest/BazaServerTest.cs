using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Baza;
using System.ServiceModel;

namespace BazaTest
{
    [TestFixture]
    public class BazaServerTest
    {

        [Test]
        public void BazaServer_KonstruktorTest()
        {
            BazaServer server = null;
            Assert.DoesNotThrow(() => server = new BazaServer());
            Assert.NotNull(server.serviceHost);
        }
    }
}
