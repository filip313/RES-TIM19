using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.ServiceModel;

namespace ReplicatorReceiver
{
    public class LogerConnection
    {
        public ILoger logerProxy;

        public LogerConnection()
        {
            Connect();
        }

        private void Connect()
        {
            var binding = new NetTcpBinding();
            

            binding = new NetTcpBinding();
            ChannelFactory<ILoger> logerFactory = new ChannelFactory<ILoger>(binding, new EndpointAddress("net.tcp://localhost:7000/LogerServiceProvider"));
            logerProxy = logerFactory.CreateChannel();
        }

        public void LogPrijem(Tuple<CODE, double> vrednost)
        {
            string tmp = "";
            tmp += DateTime.Now.ToString();
            tmp += " Od: Replikator Receiver: Primio : CODE:" + vrednost.Item1 + ": VALUE: " + vrednost.Item2;
            try
            {
                logerProxy.LogData(tmp);
            }
            catch (Exception)
            {
                Console.WriteLine("Nije moguce poslati podatke na Loger.");
            }
        }

        public void LogSkladistenje(int id, DataSet ds, string str)
        {
            string tmp = "";
            tmp += DateTime.Now.ToString();
            tmp += " Od: Replikator Receiver: Sacuvao " + str + " element: ID: " + id + " DATA SET: " + ds;
            try
            {
                logerProxy.LogData(tmp);
            }
            catch (Exception)
            {
                Console.WriteLine("Nije moguce poslati podatke na Loger.");
            }
        }

        public void LogSlanje(int id, DataSet ds, Tuple<CODE, double> vrednost)
        {
            string tmp = "";
            tmp += DateTime.Now.ToString();
            tmp += " Od: Replikator Receiver: Poslao na Reader-a: ID: " + id + ", Data Set: " + ds + ", CODE: " + vrednost.Item1 + ", Value: " + vrednost.Item2;
            try
            {
                logerProxy.LogData(tmp);
            }
            catch (Exception)
            {
                Console.WriteLine("Nije moguce poslati podatke na Loger.");
            }
        }
    }
}
