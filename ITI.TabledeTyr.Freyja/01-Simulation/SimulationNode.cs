using ITI.GameCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.TabledeTyr.Freyja
{
    /// <summary>
    /// A simulation Node contain :
    /// </summary>
    /// <param name="ID">The UUID of the node.</param>
    /// <param name="TaflStored">The stored Tafl of the node. BasicTafl actualy</param>
    /// <param name="originalMove">The original Move made to get to the Tafl stored at this node</param>
    /// <param name="Score">The score of the Node, todo : recursive addition</param>
    /// <param name="IsAtkPlayed">The score of the Node, todo : recursive addition</param>
    class SimulationNode
    {
        //attributes
        readonly string id; //UUID of the node
        readonly IReadOnlyTafl _taflstored;
        internal readonly Move _originalMove;
        internal int _score;
        internal bool isAtkPlaying;
        readonly int _turn;
        //constructor
        internal SimulationNode(string id, IReadOnlyTafl tafl, int score, bool isAtkPlaying)//if the node is the first node : no move
            :this(id, tafl, 0, new Move(), isAtkPlaying, 0)
            {
            }
        internal SimulationNode(string id, IReadOnlyTafl tafl, int score, Move move, bool isAtkPlaying, int turn)//constructor
        {
            this.id = id;
            _taflstored = tafl;
            _originalMove = move;
            _score = score;
            _turn = turn;
        }
        //props to communicate with the data stored
        internal string ID { get { return id; } } 
        internal IReadOnlyTafl TaflStored { get { return _taflstored; } }
        internal Move OriginMove{ get { return _originalMove; } }
        internal int Score { get { return _score; } set { _score = value; } }//to do : recursive addition for childs scores
        public bool IsAtkPlay { get { return isAtkPlaying; } internal set { isAtkPlaying=value; }  }
        public int Turn { get { return _turn; } }
    }
    class SimulationIncubator
    {
        //attributes
        readonly int _maxIncubatedNode;
        readonly SimulationNode[] _incubatorArray; 

        internal SimulationIncubator(int maxIncubatedNode)
        {
            _maxIncubatedNode = maxIncubatedNode;
            _incubatorArray = new SimulationNode[_maxIncubatedNode];
        }
        internal SimulationNode GetNode(int rank)
        {
            if (_incubatorArray.si == 0) throw new Exception("There is no node in the incubator");
            if (rank >= _maxIncubatedNode || rank <= 0) throw new ArgumentOutOfRangeException("The rank specified is out of the list");
            return _incubatorArray.ElementAt(rank);
        }
        internal SimulationNode GetBestNode
        {
            get
            {
                if (_incubatorArray.Length == 0) throw new Exception("There is no node in the incubator");
                return _incubatorArray[0];
            }
        }
        internal void Add(SimulationNode node)
        {
            if (_incubatorArray.Length == 0) { _incubatorArray[0] = node; }
            else
            {
                int cursor = 0;
                foreach (SimulationNode n in _incubatorArray)
                {
                    if(n.Score<= node.Score)
                    {                                                
                        for (int i = _incubatorArray.Length - 1; i > cursor; i--)
                        {
                            _incubatorArray[i+1] = _incubatorArray[i];                           
                        }
                    }
                    cursor++;
                }
            }
        }

    }
}
