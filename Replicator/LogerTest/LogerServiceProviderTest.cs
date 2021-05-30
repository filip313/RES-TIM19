using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Logger;
using Moq;

namespace LogerTest
{
    [TestFixture]
    class LogerServiceProviderTest
    {
        [Test]
        public void LogDataBezExe()
        {
            LogerServiceProvider loger = new LogerServiceProvider();

            Assert.DoesNotThrow(() => loger.LogData("data"));
        }
    }
}
