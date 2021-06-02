using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Moq;
using Baza;
using System.Data;
using System.Globalization;

namespace BazaTest
{
    [TestFixture]
    class BazaHendlerTest
    {

        [Test]
        public void ProveraBaze_NullTest()
        {
            var commandMock = new Mock<IDbCommand>();
            var readerMock = new Mock<IDataReader>();
            readerMock.Setup(o => o.Read()).Returns(false);
            commandMock.Setup(o => o.ExecuteReader()).Returns(readerMock.Object).Verifiable();
            var connectionMock = new Mock<IDbConnection>();
            connectionMock.SetupGet(o => o.State).Returns(ConnectionState.Open);
            connectionMock.Setup(o => o.CreateCommand()).Returns(commandMock.Object).Verifiable();

            BazaHendler hendler = new BazaHendler(connectionMock.Object);

            Assert.IsNull(hendler.ProveraBaze(1, "DATA_SET_1"));
        }

        [Test]
        public void ProveraBaze_NotNullTest()
        {
            var commandMock = new Mock<IDbCommand>();
            var readerMock = new Mock<IDataReader>();
            readerMock.SetupSequence(o => o.Read()).Returns(true).Returns(false);
            readerMock.Setup(o => o.GetValue(0)).Returns(1);
            readerMock.Setup(o => o.GetValue(1)).Returns((Decimal)123);
            readerMock.Setup(o => o.GetValue(2)).Returns(0);
            commandMock.Setup(o => o.ExecuteReader()).Returns(readerMock.Object).Verifiable();
            var connectionMock = new Mock<IDbConnection>();
            connectionMock.SetupGet(o => o.State).Returns(ConnectionState.Open);
            connectionMock.Setup(o => o.CreateCommand()).Returns(commandMock.Object).Verifiable();

            BazaHendler hendler = new BazaHendler(connectionMock.Object);

            var item = hendler.ProveraBaze(1, "DATA_SET_1");
            Assert.NotNull(item);
            Assert.AreEqual(item.Item1, 1);
            Assert.AreEqual(item.Item2, CODE.CODE_ANALOG);
            Assert.AreEqual(item.Item3, 123);
        }
        [Test]
        public void Upis_Test()
        {
            var commandMock = new Mock<IDbCommand>();
            var connectionMock = new Mock<IDbConnection>();
            connectionMock.SetupGet(o => o.State).Returns(ConnectionState.Open);
            connectionMock.Setup(o => o.CreateCommand()).Returns(commandMock.Object).Verifiable();

            BazaHendler hendler = new BazaHendler(connectionMock.Object);

            Assert.DoesNotThrow(() => hendler.Upis(1, 0, 213, Common.DataSet.DATA_SET_1, DateTime.Now.ToString(new CultureInfo("en-US"))));
        }

        [Test]
        public void Update_Test()
        {
            var commandMock = new Mock<IDbCommand>();
            var connectionMock = new Mock<IDbConnection>();
            connectionMock.SetupGet(o => o.State).Returns(ConnectionState.Open);
            connectionMock.Setup(o => o.CreateCommand()).Returns(commandMock.Object).Verifiable();

            BazaHendler hendler = new BazaHendler(connectionMock.Object);

            Assert.DoesNotThrow(() => hendler.Upadate(1, 1234, Common.DataSet.DATA_SET_1, DateTime.Now.ToString(new CultureInfo("en-US"))));
        }
    }
}
