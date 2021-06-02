﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace ReplicatorReceiver
{
    public interface IReaderConnection
    {
        void Connect();

        bool Posalji(int id, DataSet ds, Tuple<CODE, double> vrednost);
    }
}
