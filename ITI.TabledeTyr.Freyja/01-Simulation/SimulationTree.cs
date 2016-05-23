using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.TabledeTyr.Freyja
{
    class SimulationNode : IEnumerable<SimulationNode>
    {
        public readonly string id; //UUID of the node
        Dictionary<string, SimulationNode> _childs = new Dictionary<string, SimulationNode>(); //dictionnary of his childs
        public SimulationNode Parent { get; private set; } //get,set of the parent

        byte[] _tafl;

        int score;

        int sourceX;
        int sourceY;
        int destinationX;
        int destinationY;

        public SimulationNode(string id)//constructor
        {
            this.id = id;
        }
        #region node methods and props
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
