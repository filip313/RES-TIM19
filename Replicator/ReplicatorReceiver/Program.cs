using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplicatorReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            ReceiverServer server = new ReceiverServer();
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
