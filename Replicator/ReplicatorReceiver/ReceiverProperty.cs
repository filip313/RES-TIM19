using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using ReplicatorReceiver.Interfejsi;

namespace ReplicatorReceiver
{
    public class ReceiverProperty : IReceiverProperty
    {
        public CODE Code { get; set; }
        public double ReceiverValue { get; set; }

        public ReceiverProperty(CODE code, double value)
        {
            this.Code = code;
            this.ReceiverValue = value;
        }
    }
}
