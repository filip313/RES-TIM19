using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace ReplicatorReceiver.Interfejsi
{
    public interface ICollectionDescription
    {
        int Id { get; set; }
        DataSet DataSet { get; set; }
        HistoricalCollection historicalCollection { get; set; }
    }
}
