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
                if (_incubator != null) _incubator.RemovebyTeam(_ctx.Sensor.IsFreyjaAtk);
                if(_incubator.Length == 0 || _incubator == null || _incubator[1] == null)
                {
                    return new Move(0, 0, 0, 0);
                }
                if (_incubator[0].Score == 0) return _incubator.BestNode.OriginMove;
                //if the firsts node of the incubator are the same, choose it (by random, by their turn value...)             
                if (_incubator.BestNode.Score == _incubator[1].Score)
                {
                    List<SimulationNode> topOfTheList = new List<SimulationNode>();
                    int i=0;
                    while (_incubator.BestNode.Score == _incubator[i].Score)
                    {
                        if ( _incubator[i] == null) break;
                        topOfTheList.Add(_incubator[i]);
                        i++;
                        if (i == _ctx.Monitor.MaxComparaison || i >= _incubator.Length - 1) break;
                    } 
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
