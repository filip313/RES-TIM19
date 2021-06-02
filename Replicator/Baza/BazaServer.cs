using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.ServiceModel;

namespace Baza
{
    public class BazaServer
    {
        public ServiceHost serviceHost;

        public BazaServer()
        {
            Start();
        }

        public void Start()
        {
            serviceHost = new ServiceHost(typeof(BazaServiceProvider));
            NetTcpBinding binding = new NetTcpBinding();
            serviceHost.AddServiceEndpoint(typeof(IReaderBaza), binding, new Uri("net.tcp://localhost:10000/BazaServiceProvider"));
            try
            {
                serviceHost.Open();
            }
            catch (Exception)
            {
                Console.WriteLine("Nije moguce otvoriti vezu ka Reader komponentama.");
            }

            Console.WriteLine("Baza je spremana za prijem podataka !");
        }
    }
}
