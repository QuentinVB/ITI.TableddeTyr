using System;
using System.Collections.Generic;

namespace ITI.TabledeTyr.Freyja
{
    class Monitor
    {
        private Freyja_Core freyja_Core;
        readonly int _maxSimTurn = 2;

        public Monitor(Freyja_Core freyja_Core)
        {
            this.freyja_Core = freyja_Core;
        }

        public int maxIncubatedNode { get; internal set; }

        public int MaxSim { get { return _maxSimTurn; } }
    }
}
