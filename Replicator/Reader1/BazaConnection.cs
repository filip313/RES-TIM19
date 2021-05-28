using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.ServiceModel;

namespace Reader1
{
    public class BazaConnection
    {
        public IReaderBaza bazaProxy;

        public BazaConnection()
        {
            Connect();
        }
        public void Connect()
        {
            var binding = new NetTcpBinding();


            
            ChannelFactory<IReaderBaza> bazaFactory = new ChannelFactory<IReaderBaza>(binding, new EndpointAddress("net.tcp://localhost:10000/BazaServiceProvider"));
            bazaProxy = bazaFactory.CreateChannel();
        }


    }
}
