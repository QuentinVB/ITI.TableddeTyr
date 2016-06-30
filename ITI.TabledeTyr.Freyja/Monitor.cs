using System;
using System.Collections.Generic;

namespace ITI.TabledeTyr.Freyja
{
    class Monitor
    {
        private Freyja_Core freyja_Core;
        readonly int _maxSimTurn = 2;
        readonly int _maxIncubatedNode = 180;
        readonly SortBy _equalResultMethod = SortBy.Turn;

        public Monitor(Freyja_Core freyja_Core)
        {
            this.freyja_Core = freyja_Core;
        }
        public int maxIncubatedNode { get { return _maxIncubatedNode; } }
        public int MaxSim { get { return _maxSimTurn; } }
        public SortBy EqualResultMethod { get { return _equalResultMethod; } }
    }
}
