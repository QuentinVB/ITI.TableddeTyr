using System.Collections.Generic;

namespace ITI.TabledeTyr.Freyja
{
    public interface IAnalyze
    {
        Dictionary<string, SimulationNode> PonderateTree{ get; }
    }
}
