using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reader1
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        static void Main(string[] args)
        {
            int id;
            ReaderServer rs;
            if (args.Count() == 0)
            {
                id = 0;
                rs = new ReaderServer(id.ToString());
                for (int i = 1; i < 4; i++)
                {
                    Process.Start("Reader1.exe", i.ToString());
                }
            }
            else
            {
                rs = new ReaderServer(args[0]);

            }
            string tmp = "";
            while (!tmp.Equals("exit"))
            {
                Console.WriteLine("Unesite exit za gasenje programa");
                tmp = Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
