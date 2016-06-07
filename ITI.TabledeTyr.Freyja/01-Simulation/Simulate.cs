using ITI.GameCore;
using System;
using System.Collections.Generic;

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
        readonly Dictionary<string, SimulationNode> _simulationTree = new Dictionary<string, SimulationNode>();//dictionnary containing the tree
        /// <summary>
        /// Initializes a new instance of the <see cref="Simulate"/> class. 
        /// The simulate object will simulate each of pawn
        /// </summary>
        /// <param name="ctx">The contexte.</param>
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
            _simulationTree.Add(root.ID,root);//Add it to the tree
            simulateBranchs(root);//simulate the branchs of the root to populate the dictionnary
            foreach (SimulationNode node in _simulationTree.Values)
            {
                if (node.Turn == _ctx.Monitor.MaxSim) break;
                 simulateBranchs(node);
            }
        }
        void simulateBranchs(SimulationNode node)
        {
            Game controlGame = new Game(node.TaflStored, node.IsAtkPlay); //serve as reference for possible move
            //explore each pawn
            for (int i = 0; i < node.TaflStored.Width; i++)
            {
                for (int j = 0; j < node.TaflStored.Height; j++)
                {
                    if (node.TaflStored[i,j]==Pawn.None)
                    { }//if pawn none : avoid
                    else
                    {
                     //start simulate the moves of this pawn                      
                    PossibleMove possibleMove = controlGame.CanMove(i, j);
                    if (possibleMove.IsFree() == true)//if the pawn cannot move, leave
                        {
                        if (controlGame.IsAtkPlaying == true && controlGame.Tafl[i, j] == Pawn.Attacker)
                        {
                           GenerateEachDirection(i, j, possibleMove, node);
                        }
                        else if (controlGame.IsAtkPlaying == false && ( controlGame.Tafl[i, j] == Pawn.Defender || controlGame.Tafl[i, j] == Pawn.King))
                        {                            
                           GenerateEachDirection(i, j, possibleMove, node);
                        }
                     }                    
                }
            }
         }
        }
        /// <summary>
        /// Generates node for eachs directions possible for this pawn .
        /// </summary>
        /// <param name="i">The i.</param>
        /// <param name="j">The j.</param>
        /// <param name="possibleMove">The possible move datas.</param>
        /// <param name="node">The current node.</param>
        void GenerateEachDirection(int i, int j, PossibleMove possibleMove, SimulationNode node)
        {
            //by using possible move up/down/left/right 
            if (possibleMove.Up() > 0)
            {
                for (int up = 0; up < possibleMove.Up(); up++)
                {
                    //linking node just created, designating the new created node as one of childs of the active node
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
        /// <summary>
        /// Simulate nodes.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        SimulationNode GenerateNode(int x, int y, int x2, int y2, SimulationNode node)
        {
            _simulatedGame = new Game(node.TaflStored, node.IsAtkPlay); //create a Game for this pawn move, at this tafl state and turn state.
            _simulatedGame.MovePawn(x, y, x2, y2);//move the pawn (finally !)
            bool stillPlayable = _simulatedGame.UpdateTurn();
            Move move = new Move(x, y, x2, y2);
            _key = Guid.NewGuid().ToString();//generating new key
            //creating new node containing ALL the data
            return new SimulationNode(_key, _simulatedGame.Tafl, 0, move, stillPlayable, node.Turn + 1, _simulatedGame.IsAtkPlaying);               
        }
        
        internal Dictionary<string, SimulationNode> GetSimulationTree { get { return _simulationTree; } }
    }
}
