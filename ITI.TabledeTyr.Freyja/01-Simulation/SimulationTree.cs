using ITI.GameCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.TabledeTyr.Freyja
{
	/*
	        Dictionary<string,SimulationNode> SimulatedTree = new Dictionary<string, SimulationNode>();//dictionnary containing the tree
            SimulationNode root =  new SimulationNode(Guid.NewGuid().ToString());//create the root of the tree (getting the current state of the system)
            string key = Guid.NewGuid().ToString();//generating new key
            SimulatedTree[key] = new SimulationNode(key);//creating new node
            root.AddChild(SimulatedTree[key]);//linking root, designating the new created node as one of his childs  
	*/
    class SimulationNode : IEnumerable<SimulationNode>
    {
        //attributes
        internal readonly string id; //UUID of the node
        internal IReadOnlyTafl _taflstored;
        internal readonly Move _move;
        internal int _score;
        //collections
        Dictionary<string, SimulationNode> _childs = new Dictionary<string, SimulationNode>(); //dictionnary of his childs
        //constructor
        internal SimulationNode(string id, IReadOnlyTafl tafl, int score)//if the node is the first node : no move
            :this(id, tafl, 0, new Move())
            { }
        internal SimulationNode(string id, IReadOnlyTafl tafl, int score, Move move)//constructor
        {
            this.id = id;
            _taflstored = tafl;
            _move = move;
            _score = score;
        }

        #region node methods and props
        public SimulationNode Parent { get; private set; } //get,set of the parent
        public SimulationNode GetChild(string id)//return the child named by his UUID of this node
        {
            return this._childs[id];
        }
        public void AddChild(SimulationNode item)//add a new child to this node
        {
            if (item.Parent != null)//if the child has already a parent,
            {
                item.Parent._childs.Remove(item.id);//remove this node from child list of the older parent
            }

            item.Parent = this;//add the active node has the parent of the added node
            this._childs.Add(item.id, item);//add the new node inside the list using his UUID as key
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
    }
}
