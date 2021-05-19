using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Writer
{
    class Program
    {
        static void Main(string[] args)
        {
            int id;
            if(args.Count() == 0)
            {
                id = 0;
            }
            else
            {
                id = Int32.Parse(args[0]);
            }
                
            WriterComponent wc = new WriterComponent(id);

            ConsoleKeyInfo key;
            bool ugasi = false;
            while (!ugasi)
            {
                if (wc.Id == 0)
                {
                    Console.WriteLine("========================= GLAVNI WRITER ================================");
                    Console.WriteLine("1 -> Pokreni novu instancu Writer-a");
                    Console.WriteLine("2 -> Izlistaj aktivne Writer-e");
                    Console.WriteLine("3 -> Ugasi odredjenog Writer-a");
                    Console.WriteLine("x -> Ugasi glavnu instancu");
                    key = Console.ReadKey();
                    Console.Clear();
                    switch (key.KeyChar)
                    {
                        case '1':
                            wc.KreirajWriter();
                            break;
                        case '2':
                            wc.ListWriter();
                            Generator.GenerateCode();
                            break;
                        case '3':
                            Console.WriteLine("Odaberi proces za gasenje:");
                            wc.ListWriter();
                            string tmp = Console.ReadLine();
                            int tmpId;
                            if (!Int32.TryParse(tmp, out tmpId))
                            {
                                Console.WriteLine("Potrebno je uneti broj");
                                break;
                            }
                            wc.UgasiWritera(tmpId);
                            break;
                        case 'x':
                            ugasi = wc.Ugasi();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("=========================WRITER " + wc.Id + "================================");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }
}
