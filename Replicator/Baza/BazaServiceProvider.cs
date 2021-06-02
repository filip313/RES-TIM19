using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.ServiceModel;
using System.Globalization;
using System.Diagnostics.CodeAnalysis;

namespace Baza
{
    public class BazaServiceProvider : IReaderBaza
    {
        public static IBazaHendler bazahendler;
        public static CultureInfo ci = new CultureInfo("en-US");

        [ExcludeFromCodeCoverage]
        public BazaServiceProvider()
        {
            bazahendler = new BazaHendler();
        }

        //Konstruktor za Testove
        public BazaServiceProvider(bool flag) { }

        public void PosaljiNaBazu(int id, CODE code, double value, int dataSet,DateTime dt)
        {

            if (VratiIzBaze(id, dataSet) != null)
            {
                bazahendler.Upadate(id, value, (DataSet)dataSet, dt.ToString(ci));
            }
            else
            {
                bazahendler.Upis(id, (int)code, value, (DataSet)dataSet, dt.ToString(ci));
            }
        }

        public Tuple<int, CODE, double> VratiIzBaze(int id, int dataSet)
        {
            return bazahendler.ProveraBaze(id, ((DataSet)dataSet).ToString());
        }
    }
}
