using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Common;
using ReplicatorReceiver;

namespace ReplicatorReceiverTest
{
    [TestFixture]
    class ReplicatorConnectionTest
    {
        ReaderConnection rc;
        [SetUp]
        public void Setup()
        {
            Mock moq = new Mock<ReaderConnection>();
            rc = (ReaderConnection)moq.Object;
        }

        [Test]
        [TestCase(DataSet.DATA_SET_1)]
        [TestCase(DataSet.DATA_SET_2)]
        [TestCase(DataSet.DATA_SET_3)]
        [TestCase(DataSet.DATA_SET_4)]
        public void PosaljiTest(DataSet ds)
        {
            Assert.DoesNotThrow(() => rc.Posalji(1, ds, new Tuple<CODE, double>(CODE.CODE_ANALOG, 2134)));
        }
    }
}
