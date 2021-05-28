using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace ReplicatorReceiver
{
    public class ReceiverProperty
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
