using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
namespace Writer
{
    public class Generator
    {
        private static Random gen = new Random();
        public static CODE GenerateCode()
        {
            CODE ret;
            gen = new Random();

            ret = (CODE)(gen.Next() % 8);

            return ret;
        }

        public static double GenerateValue(CODE code)
        {
            switch (code)
            {
                case CODE.CODE_ANALOG:
                    return GenerisiAnalog();
                case CODE.CODE_DIGITAL:
                    return GenerisiDigital();
                case CODE.CODE_CUSTOM:
                    return GenerisiCustom();
                case CODE.CODE_LIMITSET:
                    return GenerisiLimitset();
                case CODE.CODE_SINGLENODE:
                    return GenerisiSingle();
                case CODE.CODE_MULTIPLENODE:
                    return GenerisiMulti();
                case CODE.CODE_CONSUMER:
                    return GenerisiConsumer();
                case CODE.CODE_SOURCE:
                    return GenerisiSource();
            }
            return 0;
        }

        private static double GenerisiSource()
        {
            double ret = gen.Next();
            if(ret % 2 == 0)
            {
                ret -= 1;
            }
            return (double)ret;
        }

        private static double GenerisiConsumer()
        {
            double ret = gen.Next();
            if(ret % 2 != 0)
            {
                ret += 1;
            }
            return (double)ret;
        }

        private static double GenerisiMulti()
        {
            double ret = gen.NextDouble()* 1000;
            return Math.Round(ret, 2);
        }

        private static double GenerisiSingle()
        {
            double ret = gen.NextDouble();
            return Math.Round(ret, 2);
        }

        private static double GenerisiLimitset()
        {
            double ret = gen.NextDouble();
            return ret * -1;
        }

        private static double GenerisiCustom()
        {
            double ret = gen.NextDouble();
            return 1 / ret;
        }

        private static double GenerisiDigital()
        {
            int ret = gen.Next();
            return (double)(ret % 2);
        }

        private static double GenerisiAnalog()
        {
            double ret = gen.Next();
            return ret;
        }
    }
}
