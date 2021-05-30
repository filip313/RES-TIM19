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
    class LogerConnectionTest
    {
        LogerConnection con;
        [SetUp]
        public void Setup()
        {
            Mock moq = new Mock<LogerConnection>();
            con = (LogerConnection)moq.Object;
        }

        [Test]
        public void LogPrijemTest()
        {
           Assert.DoesNotThrow(() => con.LogPrijem(new Tuple<CODE, double>(CODE.CODE_ANALOG, 1234)));
        }

        [Test]
        public void LogSkladistenjeTest()
        {
            Assert.DoesNotThrow(() => con.LogSkladistenje(1, DataSet.DATA_SET_1, "test"));
        }

        [Test]
        public void LogSlanjeTest()
        {
            Assert.DoesNotThrow(() => con.LogSlanje(1, DataSet.DATA_SET_1, new Tuple<CODE, double>(CODE.CODE_ANALOG, 1234)));
        }
    }
}
