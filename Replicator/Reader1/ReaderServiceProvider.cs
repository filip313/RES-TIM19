using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.ServiceModel;
using System.Globalization;

namespace Reader1
{
    public class ReaderServiceProvider : IReceiverReader
    {
        public static LoggerConnection loger = new LoggerConnection();
        public static BazaConnection baza = new BazaConnection();

        public void PosljiReaderu(int id, Tuple<CODE, double> vrednost)
        {
            Console.WriteLine("ID:" + id + "CODE:" + vrednost.Item1 + "Value:" + vrednost.Item2);
            loger.LogPrijem(id, vrednost);
            int dataSet = ReaderServer.dataSet;
           
            if (vrednost.Item1 == CODE.CODE_DIGITAL)
            {
                DateTime dt = DateTime.Now;
                baza.bazaProxy.PosaljiNaBazu(id, vrednost.Item1, vrednost.Item2, dataSet,dt);
                loger.LogUpis(id,vrednost,dataSet,dt);
                
            }
            else
            {
                var prijem = baza.bazaProxy.VratiIzBaze(id, dataSet);


                if (prijem == null)
                {
                    DateTime dt = DateTime.Now;
                    baza.bazaProxy.PosaljiNaBazu(id, vrednost.Item1, vrednost.Item2, dataSet,dt);
                    loger.LogUpis(id, vrednost, dataSet, dt);
                }
                else
                {
                    if (ProveraDeadband(vrednost.Item2, prijem.Item3))
                    {
                        DateTime dt = DateTime.Now;
                        baza.bazaProxy.PosaljiNaBazu(id, vrednost.Item1, vrednost.Item2, dataSet,dt);
                        loger.LogUpdate(id, vrednost, dataSet, dt);
                    }
                    else
                    {
                        DateTime dt = DateTime.Now;
                        Console.WriteLine("Podatak nije ispunio Deadband");
                        loger.LogDeadbandNeuspeli(id, vrednost, dataSet, dt);
                    }
                }
            }
        }
        public bool ProveraDeadband(double poslati, double vracen)
        {
            double vrednost = ((vracen) / 100) * 2;
            double broj = Math.Abs(vracen - poslati);
            if (broj > vrednost)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        
    }
}
