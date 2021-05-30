using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using ReplicatorReceiver;
using ReplicatorReceiver.Interfejsi;
using Moq;

namespace ReplicatorReceiverTest
{
    [TestFixture]
    class SenderReceiverServiceProviderTest
    {
        [Test]
        public void GenerisiIdTest()
        {
            Mock moq = new Mock<ReplicatorReceiver.Interfejsi.IServiceProvider>();
            var provider = (ReplicatorReceiver.Interfejsi.IServiceProvider)moq.Object;

            int id = provider.GenerisiId();
            Assert.GreaterOrEqual(id, 0);
            Assert.LessOrEqual(id, 100);
        }

        [Test]
        [TestCase(CODE.CODE_ANALOG)]
        [TestCase(CODE.CODE_CONSUMER)]
        [TestCase(CODE.CODE_MULTIPLENODE)]
        [TestCase(CODE.CODE_LIMITSET)]
        [TestCase(9)]
        public void OdrediDataSet(CODE code)
        {
            Mock moq = new Mock<SenderReceiverServiceProvider>();
            var provider = (SenderReceiverServiceProvider)moq.Object;
            var ds = provider.OdrediDataSet(code);
            DataSet local_ds = DataSet.DATA_SET_1;

            int c = (int)code;
            if (c <= 1)
            {
                local_ds = DataSet.DATA_SET_1;
            }
            else if (c > 1 && c <= 3)
            {
                local_ds = DataSet.DATA_SET_2;
            }
            else if (c > 3 && c <= 5)
            {
                local_ds = DataSet.DATA_SET_3;
            }
            else if (c > 5 && c <= 7)
            {
                local_ds = DataSet.DATA_SET_4;
            }
            else
                local_ds = 0;

            Assert.AreEqual(ds, local_ds);
        }

        [Test]
        public void PosaljiNaReceiverTest()
        {
            Mock cd_moq = new Mock<ICollectionDescription>();
            Mock moq = new Mock<SenderReceiverServiceProvider>();
            var provider = (SenderReceiverServiceProvider)moq.Object;
            provider.GetDict = new Dictionary<int, CollectionDescription> { { 1, new CollectionDescription(1, DataSet.DATA_SET_1) } };

            Assert.DoesNotThrow(() => provider.PosaljiNaReceiver(new Tuple<CODE, double>(CODE.CODE_ANALOG, 1234)));
        }

        [Test]
        public void GetDictTest()
        {
            Mock moq = new Mock<SenderReceiverServiceProvider>();
            var provider = (SenderReceiverServiceProvider)moq.Object;

            var dict = provider.GetDict;
            Assert.NotNull(dict);
        }
    }
}
