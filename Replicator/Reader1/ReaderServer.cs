using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Common;
namespace Reader1
{
   public class ReaderServer
    {
        public ServiceHost serviceHost;
        public static int dataSet;

        public ReaderServer(string port)
        {
            Int32.TryParse(port, out dataSet);
            Start(port);
        }
        public void Start(string port)
        {
            serviceHost = new ServiceHost(typeof(ReaderServiceProvider));
            NetTcpBinding binding = new NetTcpBinding();
            serviceHost.AddServiceEndpoint(typeof(IReceiverReader), binding, new Uri("net.tcp://localhost:900" + port + "/ReaderServiceProvider"));
            try
            {
                serviceHost.Open();
            }
            catch (Exception)
            {
                Console.WriteLine("Nije moguce otvoriti vezu ka Replikator Receiver komponenti.");
            }

            Console.WriteLine("Reader" + port + " " + "je spreman za prijem podataka !");
        }
    }
}
