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
        Dictionary<string, SimulationNode> simulatedTree;

        public Analyze(Freyja_Core freyja_Core)
        {
            _ctx = freyja_Core;
            simulatedTree = _ctx.Simulate.GetSimulationTree;
        }
        public Dictionary<string, SimulationNode> PonderateTree { get; }
    }
    class AnalyzeBasic : IAnalyze
    {
        Freyja_Core _ctx;
        Dictionary<string, SimulationNode> simulatedTree;

        public AnalyzeBasic(Freyja_Core freyja_Core)
        {
             _ctx = freyja_Core;
            simulatedTree = _ctx.Simulate.GetSimulationTree;
        }
        public Dictionary<string, SimulationNode> PonderateTree { get; }
    }
}
