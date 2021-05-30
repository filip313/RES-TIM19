using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace ReplicatorReceiver.Interfejsi
{
    public interface IServiceProvider
    {
        int GenerisiId();

        DataSet OdrediDataSet(CODE code);

        Dictionary<int, CollectionDescription> GetDict  { get; set;}
    }
}
