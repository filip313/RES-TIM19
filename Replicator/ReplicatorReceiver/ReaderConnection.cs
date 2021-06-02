using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.ServiceModel;

namespace ReplicatorReceiver
{
    public class ReaderConnection : IReaderConnection
    {
        public IReceiverReader set1Proxy;
        public  IReceiverReader set2Proxy;
        public IReceiverReader set3Proxy;
        public IReceiverReader set4Proxy;

        public ReaderConnection()
        {
            Connect();
        }

        public void Connect()
        {
            var binding = new NetTcpBinding();
            ChannelFactory<IReceiverReader> readerFactory = new ChannelFactory<IReceiverReader>(binding, new EndpointAddress("net.tcp://localhost:9000/ReaderServiceProvider"));
            set1Proxy = readerFactory.CreateChannel();

            binding = new NetTcpBinding();
            readerFactory = new ChannelFactory<IReceiverReader>(binding, new EndpointAddress("net.tcp://localhost:9001/ReaderServiceProvider"));
            set2Proxy = readerFactory.CreateChannel();

            binding = new NetTcpBinding();
            readerFactory = new ChannelFactory<IReceiverReader>(binding, new EndpointAddress("net.tcp://localhost:9002/ReaderServiceProvider"));
            set3Proxy = readerFactory.CreateChannel();

            binding = new NetTcpBinding();
            readerFactory = new ChannelFactory<IReceiverReader>(binding, new EndpointAddress("net.tcp://localhost:9003/ReaderServiceProvider"));
            set4Proxy = readerFactory.CreateChannel();
        }

        public bool Posalji(int id, DataSet ds, Tuple<CODE, double> vrednost)
        {
            bool ret = true;
            switch ((int)ds)
            {
                case 0:
                    try
                    {
                        set1Proxy.PosljiReaderu(id, vrednost);
                    }
                    catch (Exception)
                    {
                        ret = false;
                        Console.WriteLine("Nije moguce poslati podatke na Reader. Proverite da li je Reader pokrenut");
                    }
                    break;
                case 1:
                    try
                    {
                        set2Proxy.PosljiReaderu(id, vrednost);
                    }
                    catch (Exception)
                    {
                        ret = false;
                        Console.WriteLine("Nije moguce poslati podatke na Reader. Proverite da li je Reader pokrenut");
                    }
                    break;
                case 2:
                    try
                    {
                        set3Proxy.PosljiReaderu(id, vrednost);
                    }
                    catch (Exception)
                    {
                        ret = false;
                        Console.WriteLine("Nije moguce poslati podatke na Reader. Proverite da li je Reader pokrenut");
                    }
                    break;
                case 3:
                    try
                    {
                        set4Proxy.PosljiReaderu(id, vrednost);
                    }
                    catch (Exception)
                    {
                        ret = false;
                        Console.WriteLine("Nije moguce poslati podatke na Reader. Proverite da li je Reader pokrenut");
                    }
                    break;
            }

            return ret;
        }

    }
}
