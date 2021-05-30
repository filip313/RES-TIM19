using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Writer;

namespace WriterTest
{
    [TestFixture]
    public class GeneratorTest
    {
        [Test]
        public void GenerateCodeRangeTest()
        {
            for (int i = 0; i < 10; i++)
            {
                var code = Generator.GenerateCode();
                Assert.GreaterOrEqual(code, CODE.CODE_ANALOG);
                Assert.LessOrEqual(code, CODE.CODE_SOURCE);
            }
        }

        [Test]
        public void GenerateValueTypeTest()
        {
            for (int i = 0; i < 10; i++)
            {
                var vrednost = Generator.GenerateValue((CODE)i);
                Assert.IsInstanceOf(typeof(double), vrednost);
            }
        }

        [Test]
        public void GeneratorDigitalRangeTest()
        {
            for(int i = 0; i < 10; i++)
            {
                var vrednost = Generator.GenerateValue(CODE.CODE_DIGITAL);
                Assert.GreaterOrEqual(vrednost, 0);
                Assert.LessOrEqual(vrednost, 1);
            }
        }

        [Test]
        public void GeneratorLimitsetTest()
        {
            for(int i = 0; i < 10; i++)
            {
                var vrednost = Generator.GenerateValue(CODE.CODE_LIMITSET);
                Assert.Less(vrednost, 0);
            }
        }

        [Test]
        public void GeneratorSourceValueTest()
        {
            for (int i = 0; i < 10; i++)
            {
                var vrednost = Generator.GenerateValue(CODE.CODE_SOURCE);
                Assert.AreNotEqual(0, vrednost % 2);
            }
        }

        [Test]
        public void GeneratorConsumerValueTest()
        {
            for (int i = 0; i < 10; i++)
            {
                var vrednost = Generator.GenerateValue(CODE.CODE_CONSUMER);
                Assert.AreEqual(0, vrednost % 2);
            }
        }
    }
}
