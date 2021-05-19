using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Threading;

namespace Writer
{
    public class Connection
    {
        public IWriterSenderService senderProxy;
        public ILoger logerProxy;
        private int Id;
        public Connection(int id)
        {
            this.Id = id;
            Connect();
            Task t = Task.Factory.StartNew(Posalji);
        }
        private void Connect()
        {
            //Replikator Sender veza
            var binding = new NetTcpBinding();
            ChannelFactory<IWriterSenderService> senderFactory = new ChannelFactory<IWriterSenderService>(binding,
                new EndpointAddress("net.tcp://localhost:6000/WriterSenderServiceProvider"));
            senderProxy = senderFactory.CreateChannel();

            //Loger Veza
            binding = new NetTcpBinding();
            ChannelFactory<ILoger> logerFactory = new ChannelFactory<ILoger>(binding, new EndpointAddress("net.tcp://localhost:7000/LogerServiceProvider"));
            logerProxy = logerFactory.CreateChannel();
        }

        private void Posalji()
        {
            while (true)
            {
                CODE code = Generator.GenerateCode();
                double value = Generator.GenerateValue(code);
                //Console.WriteLine(code + " = " + value);
                
                string data = "";
                data += DateTime.Now.ToString();
                data += " Od: Writer " + Id + ": Generisao CODE = " + code + "; VALUE = " + value;
                try
                {
                    logerProxy.LogData(data);
                    try
                    {
                        senderProxy.PosaljiNaSender(code, value);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Nije moguce poslati podatke na Replikator Sender. Proveriti da li je pokrenuta instanca Replikator Sender-a");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Nije moguce poslati podatke na Loger. Proveriti da li je instanca Loger-a pokrenuta.");
                }
                
                Thread.Sleep(2000);
            }
        }
    }
}
