using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Common;
using Baza;

namespace BazaTest
{
    [TestFixture]
    class BazaServiceProviderTest
    {
        BazaServiceProvider service;

        [Test]
        public void VratiIzBazeTest()
        {
            var handler_moq = new Mock<IBazaHendler>();
            handler_moq.Setup(o => o.ProveraBaze(It.IsAny<int>(), It.IsAny<string>())).Returns(new Tuple<int, CODE, double>(1, CODE.CODE_ANALOG, 123));
            handler_moq.Setup(o => o.Upis(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<double>(), It.IsAny<DataSet>(), It.IsAny<string>()));
            handler_moq.Setup(o => o.Upadate(It.IsAny<int>(), It.IsAny<double>(), It.IsAny<DataSet>(), It.IsAny<string>()));
            var service_moq = new Mock<BazaServiceProvider>();
            BazaServiceProvider.bazahendler = handler_moq.Object;
            service = new BazaServiceProvider(true);

            var actual = service.VratiIzBaze(1, 1);
            Assert.AreEqual(1, actual.Item1);
        }

        [Test]
        public void PosaljiNaBazu_PostojiTest()
        {
            var handler_moq = new Mock<IBazaHendler>();
            handler_moq.Setup(o => o.ProveraBaze(It.IsAny<int>(), It.IsAny<string>())).Returns(new Tuple<int, CODE, double>(1, CODE.CODE_ANALOG, 123));
            handler_moq.Setup(o => o.Upadate(It.IsAny<int>(), It.IsAny<double>(), It.IsAny<DataSet>(), It.IsAny<string>()));
            var service_moq = new Mock<BazaServiceProvider>();
            BazaServiceProvider.bazahendler = handler_moq.Object;
            service = new BazaServiceProvider(true);

            service.PosaljiNaBazu(1, CODE.CODE_ANALOG, 1234, 1, DateTime.Now);

            handler_moq.Verify(o => o.ProveraBaze(It.IsAny<int>(), It.IsAny<string>()), Times.Exactly(1));
            handler_moq.Verify(o => o.Upadate(It.IsAny<int>(), It.IsAny<double>(), It.IsAny<DataSet>(), It.IsAny<string>()), Times.Exactly(1));
        }

        [Test]
        public void PosaljiNaBazu_NullTest()
        {
            var handler_moq = new Mock<IBazaHendler>();
            handler_moq.Setup(o => o.ProveraBaze(It.IsAny<int>(), It.IsAny<string>())).Returns((Tuple<int, CODE, double>)null);
            handler_moq.Setup(o => o.Upis(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<double>(), It.IsAny<DataSet>(), It.IsAny<string>()));
            var service_moq = new Mock<BazaServiceProvider>();
            BazaServiceProvider.bazahendler = handler_moq.Object;
            service = new BazaServiceProvider(true);

            service.PosaljiNaBazu(1, CODE.CODE_ANALOG, 1234, 1, DateTime.Now);

            handler_moq.Verify(o => o.ProveraBaze(It.IsAny<int>(), It.IsAny<string>()), Times.Exactly(1));
            handler_moq.Verify(o => o.Upis(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<double>(), It.IsAny<DataSet>(), It.IsAny<string>()), Times.Exactly(1));
        }
    }
}
