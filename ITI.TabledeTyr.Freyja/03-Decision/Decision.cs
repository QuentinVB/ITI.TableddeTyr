using System;
using System.Collections.Generic;
using System.Linq;

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
                if(_incubator.Count == 0)
                {
                    return new Move(0, 0, 0, 0);
                }
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
                    if (_ctx.Monitor.EqualResultMethod == SortBy.Random)
                    {
                        int rand = rnd.Next(0, i);
                        return topOfTheList[rand].OriginMove;
                    }
                    //by turn value
                    else if (_ctx.Monitor.EqualResultMethod == SortBy.Turn)
                    {
                        topOfTheList.Sort((x, y) => x.Turn.CompareTo(y.Turn)); //sort by highess turn
                        return topOfTheList[0].OriginMove;
                    }
                    else
                    {
                        return _incubator.BestNode.OriginMove;
                    }
                }
                else
                {
                    return _incubator.BestNode.OriginMove;
                }               
            }
        }
    }
}
