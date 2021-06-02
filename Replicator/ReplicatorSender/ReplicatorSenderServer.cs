using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace ReplicatorSender
{
   public class ReplicatorSenderServer
    {
        public ServiceHost serviceHost;

        public ReplicatorSenderServer()
        {
            Start();
        }

        private void Start()
        {
            serviceHost = new ServiceHost(typeof(WriterSenderServiceProvider));
            NetTcpBinding binding = new NetTcpBinding();
            serviceHost.AddServiceEndpoint(typeof(IWriterSenderService), binding, new Uri("net.tcp://localhost:6000/WriterSenderServiceProvider"));
            try
            {
                serviceHost.Open();
            }
            catch (Exception)
            {
                Console.WriteLine("Nije moguce otvoriti vezu ka Writer komponenti/ma.");
            }

            Console.WriteLine("Replicator Sender je spreman za prijem podataka !");

            
        }
    }
}
