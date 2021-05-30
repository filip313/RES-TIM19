using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using ReplicatorReceiver;

namespace ReplicatorReceiverTest
{
    [TestFixture]
    class CollectionDescriptionTest
    {
        [Test]
        [TestCase(1, DataSet.DATA_SET_1)]
        public void CollectionDescriptionKonstruktorTest(int id, DataSet ds)
        {
            CollectionDescription cd = new CollectionDescription(id, ds);
            Assert.AreEqual(cd.Id, id);
            Assert.AreEqual(cd.DataSet, ds);
            Assert.NotNull(cd.historicalCollection);
        }
    }
}
