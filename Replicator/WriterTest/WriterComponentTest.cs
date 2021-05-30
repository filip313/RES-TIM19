using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Writer;
using Moq;
using System.Diagnostics;
using System.IO;

namespace WriterTest
{
    [TestFixture]
    class WriterComponentTest
    {
        [SetUp]
        public void SetUp()
        {
            var f = File.Create("procesi.txt");
            f.Close();
        }

        [Test]
        public void WriterComponentKonstruktorTest()
        {
            WriterComponent component = new WriterComponent(1234);

            Assert.AreEqual(1234, component.Id);
        }

        [Test]
        public void WriterComponentKreirajWriterBezEx()
        {
            WriterComponent writer = new WriterComponent(123);
            Assert.DoesNotThrow(() => { writer.KreirajWriter(); });
        }

        [Test]
        public void WriterComponentKerijrajWriterMaxIdTest()
        {
            WriterComponent wcMoq;
            var moq = new Mock<WriterComponent>();
            moq.SetupGet(w => w.aktivniWriteri).Returns(new Dictionary<int, int> { { 1, 1234 } });
            wcMoq = moq.Object;

            Assert.DoesNotThrow(()=>wcMoq.KreirajWriter());
        }

        [Test]
        public void WriterComponentUgasiWriterBezEx()
        {
            WriterComponent wc = new WriterComponent(1);
            wc.aktivniWriteri.Add(2, 21455);

            Assert.DoesNotThrow(() => { wc.UgasiWritera(2); });
        }

        [Test]
        public void WriterComponentUgasiWriterUspesan()
        {
            var tmp = Process.Start(@"..\..\..\Writer\bin\Debug\Writer.exe", "1");
            WriterComponent wcMoq = new WriterComponent(0);
            wcMoq.aktivniWriteri.Add(1, tmp.Id);

            Assert.DoesNotThrow(()=>wcMoq.UgasiWritera(1));
        }


        [Test]
        public void WriterComponentUgasiWriteraLosId()
        {
            WriterComponent wc = new WriterComponent(1);
            wc.UgasiWritera(12);
        }
    }
}
