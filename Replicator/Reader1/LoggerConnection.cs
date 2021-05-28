using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Reader1
{
   public class LoggerConnection
    {
        public ILoger logerProxy;

        public LoggerConnection()
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

        public void LogPrijem(int id,Tuple<CODE, double> vrednost)
        {
            string tmp = "";
            tmp += DateTime.Now.ToString();
            tmp += " Od: Readera: Primio :" +" "+ "ID:" + id + " " + "CODE:" + vrednost.Item1 + ": VALUE: " + vrednost.Item2;
            try
            {
                logerProxy.LogData(tmp);
            }
            catch (Exception)
            {
                Console.WriteLine("Nije moguce poslati podatke na Loger.");
            }
        }

        public void LogUpis(int id,Tuple<CODE,double>vrednost,int dataset,DateTime datetime)
        {
            string tmp = "";
            tmp += datetime.ToString();
            tmp += "Od: Readera" + dataset + " " + "Upisao u bazu: ID: " + id + "CODE: " + vrednost.Item1 + "Value: " + vrednost.Item2;
            try
            {
                logerProxy.LogData(tmp);
            }
            catch (Exception)
            {
                Console.WriteLine("Nije moguce poslati podatke na Loger.");
            }
        }

        public void LogDeadbandNeuspeli(int id, Tuple<CODE, double> vrednost, int dataset, DateTime datetime)
        {
            string tmp = "";
            tmp += datetime.ToString();
            tmp += "Od: Readera" + dataset + " " + "Nije ispunio Deadband: ID: " + id + "CODE: " + vrednost.Item1 + "Value: " + vrednost.Item2;
            try
            {
                logerProxy.LogData(tmp);
            }
            catch (Exception)
            {
                Console.WriteLine("Nije moguce poslati podatke na Loger.");
            }

        }
        public void LogUpdate(int id, Tuple<CODE, double> vrednost, int dataset, DateTime datetime)
        {
            string tmp = "";
            tmp += datetime.ToString();
            tmp += "Od: Readera" + dataset + " " + "Updejtovana baza: ID: " + id + "CODE: " + vrednost.Item1 + "Value: " + vrednost.Item2;
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
