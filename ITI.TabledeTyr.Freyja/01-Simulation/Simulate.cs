using ITI.GameCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.TabledeTyr.Freyja
{
    class Simulate
    {
        private Freyja_Core _ctx;
        string _key;
        bool _isSimulatedFreyjaAtk;
        Game _simulatedGame;
        SimulationNode root;
        string activeNode;
        //collection
        Dictionary<string, SimulationNode> SimulationTree = new Dictionary<string, SimulationNode>();//dictionnary containing the tree
        /// <summary>
        /// Initializes a new instance of the <see cref="Simulate"/> class.
        /// </summary>
        /// <param name="ctx">The CTX.</param>
        public Simulate(Freyja_Core ctx)
        {
            _ctx = ctx;
            _isSimulatedFreyjaAtk = _ctx.Sensor.IsFreyjaAtk;
            _simulatedGame = _ctx.Sensor.ActiveGame.DeepCopy();//copy the initial game and and a copy of the tafl inside
        }
        /// <summary>
        /// Updates the simulation. aka : CPU and RAM now suffers !!
        /// </summary>
        internal void UpdateSimulation()
        {
            //create the root of the tree (getting the current state of the system)
            root = new SimulationNode(Guid.NewGuid().ToString(),_ctx.Sensor.ActiveTafl ,0,_simulatedGame.IsAtkPlaying);
            SimulationTree.Add(root.ID,root);//Add it to the tree
            simulateBranchs(root);//simulate the branchs of the root

            foreach (SimulationNode node in SimulationTree.Values)
            {
                 simulateBranchs(node);
            }
        }
        /// <summary>
        /// Simulated nodes.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        SimulationNode GenerateNode(int x,int y,int x2,int y2,SimulationNode node)
        {
            _simulatedGame = new Game(node.TaflStored, node.IsAtkPlaying); //INSIDE !
            _simulatedGame.MovePawn(x, y, x2, y2);
    
                bool stillPlayable = _simulatedGame.UpdateTurn();
                Move move = new Move(x, y, x2, y2);

                _key = Guid.NewGuid().ToString();//generating new key
                return new SimulationNode(_key, _simulatedGame.Tafl, 0, move, stillPlayable,_simulatedGame.IsAtkPlaying);//creating new node               
        }
        void simulateBranchs(SimulationNode node)
        {
            for (int i = 0; i < node.TaflStored.Width; i++)
            {
                for (int j = 0; j < node.TaflStored.Height; j++)
                {
                    if(node.TaflStored[i,j]==Pawn.None)
                    { }
                    else
                    { 
                     PossibleMove possibleMove = _ctx.Sensor.ActiveGame.CanMove(i, j);

                    if (possibleMove.IsFree() == true)
                    {
                        if (node.IsAtkPlaying == true)
                        {
                            if (_ctx.Sensor.ActiveTafl[i, j] == Pawn.Attacker)
                            {
                                if (possibleMove.Up() > 0)
                                {
                                    for (int up = 0; up < possibleMove.Up(); up++)
                                    {
                                        //linking node just created, designating the new created node as one of childs of the active node
                                        node.AddChild(GenerateNode(i, j, i, up,node));
                                    }
                                }
                                if (possibleMove.Down() > 0)
                                {
                                    for (int down = 0; down < possibleMove.Down(); down++)
                                    {
                                        node.AddChild(GenerateNode(i, j, i, down, node));
                                    }
                                }
                                if (possibleMove.Left() > 0)
                                {
                                    for (int left = 0; left < possibleMove.Left(); left++)
                                    {
                                        node.AddChild(GenerateNode(i, j, left, j, node));
                                    }
                                }
                                if (possibleMove.Right() > 0)
                                {
                                    for (int right = 0; right < possibleMove.Right(); right++)
                                    {
                                        node.AddChild(GenerateNode(i, j, right, j, node));
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (_ctx.Sensor.ActiveTafl[i, j] == Pawn.Defender || _ctx.Sensor.ActiveTafl[i, j] == Pawn.King)
                            {
                                if (possibleMove.Up() > 0)
                                {
                                    for (int up = 0; up < possibleMove.Up(); up++)
                                    {
                                        node.AddChild(GenerateNode(i, j, i, up, node));
                                    }
                                }
                                if (possibleMove.Down() > 0)
                                {
                                    for (int down = 0; down < possibleMove.Down(); down++)
                                    {
                                        node.AddChild(GenerateNode(i, j, i, down, node));
                                    }
                                }
                                if (possibleMove.Left() > 0)
                                {
                                    for (int left = 0; left < possibleMove.Left(); left++)
                                    {
                                        node.AddChild(GenerateNode(i, j, left, j, node));
                                    }
                                }
                                if (possibleMove.Right() > 0)
                                {
                                    for (int right = 0; right < possibleMove.Right(); right++)
                                    {
                                        node.AddChild(GenerateNode(i, j, right, j, node));
                                    }
                                }
                            }
                        }
                    }
                    //possible move
                }
            }
         }
        }
        internal Dictionary<string, SimulationNode>  GetSimulationTree { get { return SimulationTree; } }
    }
}
