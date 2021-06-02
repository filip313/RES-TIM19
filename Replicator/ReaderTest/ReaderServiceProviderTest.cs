using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Reader1;
using Moq;
using System.ServiceModel;

namespace ReaderTest
{
    [TestFixture]
    class ReaderServiceProviderTest
    {
        ReaderServiceProvider service;
        [SetUp]
        public void SetUp()
        {
            var moq = new Mock<ReaderServiceProvider>();
            service = (ReaderServiceProvider)moq.Object;
            var baza_moq = new Mock<IReaderBaza>();
            baza_moq.Setup(o => o.VratiIzBaze(It.IsAny<int>(), It.IsAny<int>())).Returns(new Tuple<int, CODE, double>(1, CODE.CODE_MULTIPLENODE, 100));
            baza_moq.Setup(o => o.PosaljiNaBazu(It.IsAny<int>(), It.IsAny<CODE>(), It.IsAny<double>(), It.IsAny<int>(), It.IsAny<DateTime>()));
            ReaderServiceProvider.baza.bazaProxy = baza_moq.Object;
        }

        [Test]
        [TestCase(100, 120, true)]
        [TestCase(100, 102, false)]
        public void ProveriDeadbandTest(double poslati, double vracen, bool actual)
        {
            bool expected = service.ProveraDeadband(poslati, vracen);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(1, CODE.CODE_DIGITAL, 1)]
        [TestCase(2, CODE.CODE_LIMITSET, 120)]
        [TestCase(2, CODE.CODE_LIMITSET, 102)]
        public void PosaljiReaderuTest_EndpointNotFound(int id, CODE code, double vrednost)
        {
            Assert.DoesNotThrow(() =>service.PosljiReaderu(id, new Tuple<CODE, double>(code, vrednost)));
        }

        [Test]
        public void PosaljiReaderuTest_PrijemNull()
        {
            var baza_moq = new Mock<IReaderBaza>();
            baza_moq.Setup(o => o.VratiIzBaze(It.IsAny<int>(), It.IsAny<int>())).Returns((Tuple<int, CODE, double>)null);
            baza_moq.Setup(o => o.PosaljiNaBazu(It.IsAny<int>(), It.IsAny<CODE>(), It.IsAny<double>(), It.IsAny<int>(), It.IsAny<DateTime>()));
            ReaderServiceProvider.baza.bazaProxy = baza_moq.Object;

            Assert.DoesNotThrow(() => service.PosljiReaderu(1, new Tuple<CODE, double>(CODE.CODE_ANALOG, 100)));
        }

    }
}
