using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.ServiceModel;
using System.IO;
using System.Threading;

namespace Logger
{
    public class LogerServiceProvider : ILoger
    {
        private static ReaderWriterLock locker= new ReaderWriterLock();
        public LogerServiceProvider()
        {
        }

        public void LogData(string data)
        {
            try
            {
                locker.AcquireWriterLock(100);

                using (StreamWriter sw = File.AppendText("Log.txt"))
                {
                    sw.Write(data + "\n");
                    //Console.WriteLine(data);
                    sw.Close();
                }
            }
            finally
            {
                locker.ReleaseWriterLock();
            }
        }
    }
}
