using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.TabledeTyr.Freyja
{
    class Analyze
    {
        Freyja_Core _ctx;
        public Analyze(Freyja_Core freyja_Core)
        {
            _ctx = freyja_Core;            
        }
        
        internal SimulationNode UpdateAnalyze(SimulationNode father, SimulationNode child)
        {
            throw new NotImplementedException();
            return child;
        }
    }
}
