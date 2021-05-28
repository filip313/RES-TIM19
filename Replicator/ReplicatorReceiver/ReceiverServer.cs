using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.ServiceModel;

namespace ReplicatorReceiver
{
    public class ReceiverServer
    {
        public ServiceHost serviceHost;

        public ReceiverServer()
        {
            Start();
        }

        private void Start()
        {
            serviceHost = new ServiceHost(typeof(SenderReceiverServiceProvider));
            NetTcpBinding binding = new NetTcpBinding();
            serviceHost.AddServiceEndpoint(typeof(ISenderReceiver), binding, new Uri("net.tcp://localhost:8000/SenderReceiverServiceProvider"));
            try
            {
                serviceHost.Open();
            }
            catch (Exception)
            {
                Console.WriteLine("Nije moguce otvoriti vezu ka Replikator Sender komponenti.");
            }

            Console.WriteLine("Replicator Receiver je spreman za prijem podataka !");
        }
    }
}
