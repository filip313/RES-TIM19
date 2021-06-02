using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Reader1;
using Moq;

namespace ReaderTest
{
    [TestFixture]
    class LoggerConnectionTest
    {
        LoggerConnection con;
        int id = 1;
        Tuple<CODE, double> vrednost = new Tuple<CODE, double>(CODE.CODE_ANALOG, 1243);

        [SetUp]
        public void SetUp()
        {
            Mock moq = new Mock<LoggerConnection>();
            con = (LoggerConnection)moq.Object;
        }
        [Test]
        public void LogPrijem_Test()
        {
            Assert.DoesNotThrow(() => con.LogPrijem(id, vrednost));
        }

        [Test]
        public void LogUpis_Test()
        {
            Assert.DoesNotThrow(() => con.LogUpis(id, vrednost, 1, DateTime.Now));
        }

        [Test]
        public void LogDeadbandNeuspeli_Test()
        {
            Assert.DoesNotThrow(() => con.LogDeadbandNeuspeli(id, vrednost, 1, DateTime.Now));
        }

        [Test]
        public void LogUpdate_Test()
        {
            Assert.DoesNotThrow(() => con.LogUpdate(id, vrednost, 1, DateTime.Now));
        }
    }
}
