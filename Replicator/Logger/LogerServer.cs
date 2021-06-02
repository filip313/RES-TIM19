using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Common;

namespace Logger
{
    public class LogerServer
    {
        public ServiceHost serviceHost;
        
        public LogerServer()
        {
            Start();
        }

        private void Start()
        {
            serviceHost = new ServiceHost(typeof(LogerServiceProvider));
            NetTcpBinding binding = new NetTcpBinding();
            serviceHost.AddServiceEndpoint(typeof(ILoger), binding, new Uri("net.tcp://localhost:7000/LogerServiceProvider"));
            try
            {
                serviceHost.Open();
            }
            catch (Exception)
            {
                Console.WriteLine("Nije moguce otvoriti vezu za prijem podataka.");
            }
            Console.WriteLine("Loger pokernut i ceka podatke za logovanje");
        }
    }
}
