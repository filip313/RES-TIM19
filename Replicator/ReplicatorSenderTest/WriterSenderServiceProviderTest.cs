using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Moq;
using ReplicatorSender;

namespace ReplicatorSenderTest
{
    [TestFixture]
    class WriterSenderServiceProviderTest
    {
        WriterSenderServiceProvider serviceMoq;

        [SetUp]
        public void SetUp()
        {
            serviceMoq = new WriterSenderServiceProvider();
        }

        [Test]
        public void PosaljiNaSenderTest()
        {
            Assert.DoesNotThrow(() => serviceMoq.PosaljiNaSender(CODE.CODE_ANALOG, 12354));
        }

        [Test]
        public void ServiceProviderBufferTest()
        {
            var code = CODE.CODE_ANALOG;
            double value = 1242143;
            serviceMoq.PosaljiNaSender(code, value);
            
            
            foreach(Tuple<CODE, double> item in WriterSenderServiceProvider.buffer)
            {
                Assert.AreEqual(code, item.Item1);
                Assert.AreEqual(value, item.Item2);
            }
        }
    }
}
