﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplicatorSender
{
    class Program
    {
        static void Main(string[] args)
        {
            ReplicatorSenderServer server = new ReplicatorSenderServer();
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
