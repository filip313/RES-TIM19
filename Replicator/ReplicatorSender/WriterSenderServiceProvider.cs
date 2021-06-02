using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;


namespace ReplicatorSender
{
    public class WriterSenderServiceProvider : IWriterSenderService
    {
        public static List<Tuple<CODE, double>> buffer = new List<Tuple<CODE, double>>();
        public static Connection connection = new Connection();
        public virtual void PosaljiNaSender(CODE code, double value)
        {
            lock (Connection.lockObj)
            {
                buffer.Add(new Tuple<CODE, double>(code, value));
            }
            string data = "";
            data += DateTime.Now.ToString();
            data += " Od: Replicator sender primio-" + code + "; VALUE = " + value;
            try
            {
                connection.logerProxy.LogData(data);
            }
            catch (Exception)
            {
                Console.WriteLine("Nije moguce poslati podatke Loger-u.");
            }
            
        }
    }
}
