using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.ServiceModel;
using ReplicatorReceiver.Interfejsi;
using System.Diagnostics.CodeAnalysis;

namespace ReplicatorReceiver
{
    public class SenderReceiverServiceProvider : Interfejsi.IServiceProvider, ISenderReceiver 
    {
        public static Dictionary<int, CollectionDescription> collectionDescription = new Dictionary<int, CollectionDescription>();
        public static LogerConnection logerConnection = new LogerConnection();
        public static ReaderConnection readerConnection = new ReaderConnection();
        private static Random rand = new Random();

        public void PosaljiNaReceiver(Tuple<CODE, double> vrednost)
        {
            logerConnection.LogPrijem(vrednost);

            int id = GenerisiId();
            DataSet ds = OdrediDataSet(vrednost.Item1);

            if (collectionDescription.ContainsKey(id))
            {
                collectionDescription[id].historicalCollection.Add(vrednost);
                logerConnection.LogSkladistenje(id, ds, "postojeci");
            }
            else
            {
                CollectionDescription cd = new CollectionDescription(id, ds);
                cd.historicalCollection.Add(vrednost);
                collectionDescription.Add(id, cd);
                logerConnection.LogSkladistenje(id, ds, "novi");
            }
            Console.WriteLine("ID: " + id + " DS: " + ds + " CODE: " + vrednost.Item1);

            if(readerConnection.Posalji(id, ds, vrednost))
            {
                logerConnection.LogSlanje(id, ds, vrednost);
            }
        }

        [ExcludeFromCodeCoverage]
        public virtual int GenerisiId()
        {
            return rand.Next(0, 100);
        }

        public DataSet OdrediDataSet(CODE code)
        {
            int c = (int)code;
            if (c <= 1)
            {
                return DataSet.DATA_SET_1;
            }
            else if (c > 1 && c <= 3)
            {
                return DataSet.DATA_SET_2;
            }
            else if (c > 3 && c <= 5)
            {
                return DataSet.DATA_SET_3;
            }
            else if (c > 5 && c <= 7)
            {
                return DataSet.DATA_SET_4;
            }
            else
            {
                return 0;
            }
        }

        public Dictionary<int, CollectionDescription> GetDict { get { return collectionDescription; } set { collectionDescription = value; } }
    }
}
