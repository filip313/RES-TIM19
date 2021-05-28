using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace ReplicatorReceiver
{
    public class CollectionDescription
    {
        public int Id { get; set; }
        public DataSet DataSet { get; set; }
        public HistoricalCollection historicalCollection;

        public CollectionDescription(int Id, DataSet ds)
        {
            this.Id = Id;
            this.DataSet = ds;
            historicalCollection = new HistoricalCollection();
        }
    }
}
