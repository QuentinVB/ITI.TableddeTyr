using System;
using System.Collections.Generic;

namespace ITI.TabledeTyr.Freyja
{
    class Decision
    {
        private Freyja_Core _ctx;
        readonly Incubator _incubator;
        Random rnd = new Random();

        public Decision(Freyja_Core freyja_Core)
        {
            _ctx = freyja_Core;
            _incubator = _ctx.Simulate.Incubator;
        }

        internal Move Result
        {
            get
            {
                //if the firsts node of the incubator are the same, choose it (by random, by their turn value...)             
                if (_incubator.BestNode.Score == _incubator[1].Score)
                {
                    List<SimulationNode> topOfTheList = new List<SimulationNode>();
                    int i=0;
                    do
                    {
                       topOfTheList.Add(_incubator[i]);
                        i++;
                    } while (_incubator.BestNode.Score == _incubator[i].Score);
                    //by random
                    int rand = rnd.Next(0, i);
                    return _incubator[rand].OriginMove;
                }
                else
                {
                    return _incubator.BestNode.OriginMove;
                }               
            }
        }
    }
}
