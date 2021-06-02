using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Baza
{
    public interface IBazaHendler
    {
        Tuple<int, CODE, double> ProveraBaze(int id, string tabela);
        void Upis(int id, int code, double value, DataSet dataset, string dt);
        void Upadate(int id, double value, DataSet dataSet, string dt);
    }
}
