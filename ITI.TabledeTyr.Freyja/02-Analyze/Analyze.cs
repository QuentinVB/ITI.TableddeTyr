using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.TabledeTyr.Freyja
{
    class Analyze : IAnalyze
    {
        Freyja_Core _ctx;
        Dictionary<string, SimulationNode> SimulatedTree;

        public Analyze(Freyja_Core freyja_Core)
        {
            _ctx= freyja_Core;
            SimulatedTree = _ctx.Simulate.GetSimulationTree;
        }
        public Dictionary<string, SimulationNode> PonderateTree {get ;}
    }
    class AnalyzeBasic : IAnalyze
    {
        Freyja_Core freyja_Core;

        public AnalyzeBasic(Freyja_Core freyja_Core)
        {
            this.freyja_Core = freyja_Core;
        }
        public Dictionary<string, SimulationNode> PonderateTree { get; }
    }
}
