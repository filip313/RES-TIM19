using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace ReplicatorReceiver.Interfejsi
{
    public interface IHistoricalCollection
    {
        void Add(Tuple<CODE, double> vrednost);
    }
}
