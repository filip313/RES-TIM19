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
    class HistoricalCollectionTest
    {
        [Test]
        public void HistoricalCollectionKonstruktorTest()
        {
            HistoricalCollection collection = new HistoricalCollection();
            Assert.NotNull(collection.receiverProperties);
        }

        [Test]
        [TestCase(CODE.CODE_ANALOG, 21314)]
        [TestCase(CODE.CODE_SOURCE, 0.1234)]
        public void AddReceiverPropertyTest(CODE code, double value)
        {
            HistoricalCollection collection = new HistoricalCollection();
            collection.Add(new Tuple<CODE, double>(code, value));

            foreach(var item in collection.receiverProperties)
            {
                Assert.AreEqual(item.Code, code);
                Assert.AreEqual(item.ReceiverValue, value);
            }
        }
    }
}
