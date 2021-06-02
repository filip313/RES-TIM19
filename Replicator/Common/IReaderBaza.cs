using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;


namespace Common
{
    [ServiceContract]
  public interface IReaderBaza
    {
        [OperationContract]
        void PosaljiNaBazu(int id, CODE code, double value,int dataSet,DateTime datetime);
        [OperationContract]
        Tuple<int, CODE, double> VratiIzBaze(int id,int dataSet);
    }
}
