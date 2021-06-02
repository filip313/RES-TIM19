using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common;

namespace ReplicatorSender
{
    public class Connection
    {
        public ILoger logerProxy;
        public ISenderReceiver receiverProxy;
        public static object lockObj = new object();

        public Connection()
        {
            Connect();
            Task.Run(() => Posalji());
        }

        public void Connect()
        {
            var binding = new NetTcpBinding();
            ChannelFactory<ISenderReceiver> receiverFactory = new ChannelFactory<ISenderReceiver>(binding, new EndpointAddress("net.tcp://localhost:8000/SenderReceiverServiceProvider"));
            receiverProxy = receiverFactory.CreateChannel();

             binding = new NetTcpBinding();
            ChannelFactory<ILoger> logerFactory = new ChannelFactory<ILoger>(binding, new EndpointAddress("net.tcp://localhost:7000/LogerServiceProvider"));
            logerProxy = logerFactory.CreateChannel();
        }

        public void Posalji()
        {
            while (true)
            {
                lock (lockObj)
                {
                    List<Tuple<CODE, double>> lista = WriterSenderServiceProvider.buffer;

                        if (lista.Count > 0)
                        {
                            Tuple<CODE, double> vrednost = lista[0];
                            lista.RemoveAt(0);
                            string data = "";
                            data += DateTime.Now.ToString();
                            data += " Od: Replicator sender poslao-" + vrednost.Item1 + "; VALUE = " + vrednost.Item2;
                            try
                            {
                                logerProxy.LogData(data);
                                try
                                {
                                    receiverProxy.PosaljiNaReceiver(vrednost);

                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Nije moguce poslati podatke na Replikator Receiver.");
                                }
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Nije moguce poslati podatke na Loger.");
                            }
                        }

                }
                    
            }
        }
    }
}
