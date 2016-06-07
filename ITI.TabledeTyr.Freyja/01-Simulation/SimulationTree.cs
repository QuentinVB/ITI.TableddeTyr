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
    /// <param name="Parent">The parent of the node.</param>
    /// <param name="GetChilds">The childs of the node.</param>
    /// <param name="ID">The UUID of the node.</param>
    /// <param name="TaflStored">The stored Tafl of the node. BasicTafl actualy</param>
    /// <param name="Move">The Move made to get to the Tafl stored at this node</param>
    /// <param name="Score">The score of the Node, todo : recursive addition</param>
    /// <param name="IsAtkPlayed">The score of the Node, todo : recursive addition</param>
    /// <param name="StillPlayable">Indicate that the node is not a dead-end (aka no winner)</param>
    /// <seealso cref="System.Collections.Generic.IEnumerable{ITI.TabledeTyr.Freyja.SimulationNode}" />
    class SimulationNode : IEnumerable<SimulationNode>
    {
        //attributes
        readonly string id; //UUID of the node
        readonly IReadOnlyTafl _taflstored;
        internal readonly Move _move;
        internal int _score;
        internal bool isAtkPlaying;
        readonly bool _stillPlayable;
        readonly int _turn;
        //collections
        Dictionary<string, SimulationNode> _childs = new Dictionary<string, SimulationNode>(); //dictionnary of his childs
        //constructor
        internal SimulationNode(string id, IReadOnlyTafl tafl, int score, bool isAtkPlaying)//if the node is the first node : no move
            :this(id, tafl, 0, new Move(), isAtkPlaying, 0,true)
            {
                Parent = null;
            }
        internal SimulationNode(string id, IReadOnlyTafl tafl, int score, Move move, bool isAtkPlaying, int turn, bool stillPlayable)//constructor
        {
            this.id = id;
            _taflstored = tafl;
            _move = move;
            _score = score;
            _stillPlayable = stillPlayable;
            _turn = turn;
        }
        //props to communicate with the data stored
        internal string ID { get { return id; } } 
        internal IReadOnlyTafl TaflStored { get { return _taflstored; } }
        internal Move MoveStored{ get { return _move; } }
        internal int Score { get { return _score; } set { _score = value; } }//to do : recursive addition for childs scores
        public bool IsAtkPlay { get { return isAtkPlaying; } internal set { isAtkPlaying=value; }  }
        public bool StillPlayable { get { return _stillPlayable; } }
        public int Turn { get { return _turn; } }
        #region node managment methods and props
        public SimulationNode Parent { get; private set; } //get,set of the parent
        public SimulationNode GetChilds(string id)//return the child named by his UUID of this node
        {
            return this._childs[id];
        }
        public void AddChild(SimulationNode node)//add a new child to this node
        {
            if (node.Parent != null)//if the child has already a parent,
            {
                node.Parent._childs.Remove(node.id);//remove this node from child list of the older parent
            }

            node.Parent = this;//add the active node has the parent of the added node
            this._childs.Add(node.id, node);//add the new node inside the list using his UUID as key
        }
        public IEnumerator<SimulationNode> GetEnumerator()//allow the child list to be enumerable
        {
            return this._childs.Values.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        public int Count//return the number of childs of this node
        {
            get { return this._childs.Count; }
        }

      
        #endregion
        /*
        Dictionary<string,SimulationNode> SimulatedTree = new Dictionary<string, SimulationNode>();//dictionnary containing the tree
        SimulationNode root =  new SimulationNode(Guid.NewGuid().ToString());//create the root of the tree (getting the current state of the system)
        string key = Guid.NewGuid().ToString();//generating new key
        SimulatedTree[key] = new SimulationNode(key);//creating new node
        root.AddChild(SimulatedTree[key]);//linking root, designating the new created node as one of his childs  
        */
    }
}
