using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Common
{
    [ServiceContract]
    public interface IReceiverReader
    {
        [OperationContract]
        void PosljiReaderu(int id, Tuple<CODE, double> vrednost);
    }
}
