using ITI.GameCore;
using System;
using System.Collections;
using System.Collections.Generic;


namespace ITI.TabledeTyr.Freyja
{
    /// <summary>
    /// A simulation Node contain many element to analyze
    /// </summary>
    class SimulationNode
    {
        //attributes
        readonly string id; //UUID of the node
        readonly IReadOnlyTafl _taflstored;
        internal readonly Move _originalMove;
        internal readonly Move _thisMove;
        internal int _score;
        internal bool _isAtkPlaying;
        readonly int _turn;
        //constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SimulationNode"/> class.
        /// </summary>
        /// <param name="id">The identifier of this node.</param>
        /// <param name="tafl">The tafl to store.</param>
        /// <param name="score">The score.</param>
        /// <param name="isAtkPlaying">if set to <c>true</c> the atk is playing.</param>
        internal SimulationNode(string id, 
                                IReadOnlyTafl tafl, 
                                int score, 
                                bool isAtkPlaying)//if the node is the first node : no move
            :this(id, tafl, 0, new Move(), isAtkPlaying, 0, new Move())
            {}
        internal SimulationNode(string id, 
                                IReadOnlyTafl tafl, 
                                int score, 
                                Move move, 
                                bool isAtkPlaying, 
                                int turn, 
                                Move thismove)//constructor
        {
            this.id = id;
            _taflstored = tafl;
            _originalMove = move;
            _thisMove = thismove;
            _score = score;
            _isAtkPlaying = isAtkPlaying;
            _turn = turn;
        }
        //props to communicate with the data stored
        /// <summary>
        /// Gets the UUID of the node.
        /// </summary>
        internal string ID { get { return id; } }
        /// <summary>
        /// Gets the stored Tafl of the node. BasicTafl actualy.
        /// </summary>
        internal IReadOnlyTafl TaflStored { get { return _taflstored; } }
        /// <summary>
        /// Gets the original Move made at the root that lead to this node.
        /// </summary>
        internal Move OriginMove{ get { return _originalMove; } }
        /// <summary>
        /// Gets the Move made that lead from the parent to this node.
        /// </summary>
        internal Move ThisMove { get { return _thisMove; } }
        /// <summary>
        /// Gets or sets the score of the node.
        /// </summary>
        internal int Score { get { return _score; } set { _score = value; } }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is atk play.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is atk play; otherwise, <c>false</c>.
        /// </value>
        public bool IsAtkPlay { get { return _isAtkPlaying; } internal set { _isAtkPlaying=value; }  }
        /// <summary>
        /// Gets the turn from root, aka the deep of the simulation.
        /// </summary>
        public int Turn { get { return _turn; } }
    }
    /// <summary>
    /// A simulation incubator contain the X element stored and simulated
    /// </summary>
    class Incubator : IEnumerable
    {
        //attributes
        readonly int _maxIncubatedNode;
        readonly SimulationNode[] _incubatorArray;
        //CONSTRUCTORS

        /// <summary>
        /// Initializes a new instance of the <see cref="Incubator"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        internal Incubator(Incubator source)
           : this(source.GetMaxIncubatedNode, source._incubatorArray)
        {
            //_incubatorArray 
         }
        /// <summary>
        /// Initializes a new instance of the <see cref="Incubator"/> class.
        /// </summary>
        /// <param name="maxIncubatedNode">The maximum incubated node.</param>
        internal Incubator(int maxIncubatedNode)
            : this(maxIncubatedNode, new SimulationNode[maxIncubatedNode])
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Incubator"/> class.
        /// </summary>
        /// <param name="maxIncubatedNode">The maximum incubated node.</param>
        /// <param name="sourcearray">The sourcearray.</param>
        internal Incubator(int maxIncubatedNode, SimulationNode[] sourcearray)
        {
            _maxIncubatedNode = maxIncubatedNode;
            _incubatorArray = sourcearray;
        }
        //get data  
        internal int GetMaxIncubatedNode { get { return _incubatorArray.Length; } }

        internal bool RemovebyId(string ID)
        {
            bool ctrl = false;
            int cursor = 0;
            foreach (SimulationNode n in _incubatorArray)
            {
                if (n == null) break;
                if (n.ID == ID)
                {
                    ctrl = true;
                    break;
                }
                cursor++;
            }

            if(ctrl == true)
            {
                for (int i = cursor + 1; (i <= Length - 1); i++)
                {
                    _incubatorArray[i] = _incubatorArray[i + 1];
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gets the best node.
        /// </summary>
        /// <exception cref="System.Exception">There is no node in the incubator</exception>
        internal SimulationNode BestNode
        {
            get
            {
                return _incubatorArray[0];
            }
        }
        /// <summary>
        /// Gets the count of the stored simulation in the incubator.
        /// </summary>
        internal int Length
        { 
            get{ return _incubatorArray.Length; }
        }
        internal SimulationNode this[int i]
        {
            get
            {
                return _incubatorArray[i];
            }
        }
        //set data
        /// <summary>
        /// Adds the specified node to the incubator. 
        /// Then sort the node according to his score (from highest to lowest) and the score of the other nodes. 
        /// </summary>
        /// <param name="node">The node to add.</param>
        internal void Add(SimulationNode node)
        {
            int cursor = 0;
            SimulationNode nodePointed = null;
            foreach (SimulationNode n in _incubatorArray)
            {
                if (n == null) break;
                if (n.Score <= node.Score) { nodePointed = n; break; }
                nodePointed = n;
                cursor++;
            }
            if (nodePointed == null)
            {
                _incubatorArray[cursor] = node;
            }
            else if (nodePointed.Score <= node.Score)
            {                                                
                for (int i = _incubatorArray.Length - 2; (i >= cursor && i >= 0); i--)
                {
                    _incubatorArray[i + 1] = _incubatorArray[i];                       
                }
                _incubatorArray[cursor] = node;
            }

        }
        //allow the array to be enumerable by the interface of Incubator
        public IEnumerator GetEnumerator()
        {
            return _incubatorArray.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        /*
        internal void RemovebyTeam(bool isTeamAtk)
        {

            for (int i = 0; i < _incubatorArray.Length; i++)
            {
                if (_incubatorArray[i] == null) break;
                if (_incubatorArray[i].IsAtkPlay != isTeamAtk)
                {
                    _incubatorArray[i] = null;
                    for (int j = i; (j < _incubatorArray.Length - 2); j++)
                    {
                        _incubatorArray[j] = _incubatorArray[j + 1];
                    }
                }
            }
        }
        */
    }
}
