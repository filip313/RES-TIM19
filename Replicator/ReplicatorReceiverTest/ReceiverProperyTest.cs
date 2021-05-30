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
    public class ReceiverProperyTest
    {
        [Test]
        [TestCase(CODE.CODE_DIGITAL, 0)]
        [TestCase(CODE.CODE_LIMITSET, 2134.123)]
        public void ReceieverPropertyKonstruktorTest(CODE code, double value)
        {
            ReceiverProperty prop = new ReceiverProperty(code, value);

            Assert.AreEqual(prop.Code, code);
            Assert.AreEqual(prop.ReceiverValue, value);
        }
    }
}
