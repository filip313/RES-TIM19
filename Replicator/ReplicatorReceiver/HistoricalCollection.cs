using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using ReplicatorReceiver.Interfejsi;

namespace ReplicatorReceiver
{
    public class HistoricalCollection : IHistoricalCollection
    {
        public List<ReceiverProperty> receiverProperties;

        public HistoricalCollection()
        {
            receiverProperties = new List<ReceiverProperty>(); 
        }

        public void Add(Tuple<CODE, double> vrednost)
        {
            receiverProperties.Add(new ReceiverProperty(vrednost.Item1, vrednost.Item2));
        }
    }
}
