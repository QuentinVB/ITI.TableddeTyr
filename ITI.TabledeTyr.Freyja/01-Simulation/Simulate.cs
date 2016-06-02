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

        internal Dictionary<string, SimulationNode> SimulatedTree = new Dictionary<string, SimulationNode>();//dictionnary containing the tree
        /// <summary>
        /// Initializes a new instance of the <see cref="Simulate"/> class.
        /// </summary>
        /// <param name="ctx">The CTX.</param>
        public Simulate(Freyja_Core ctx)
        {
            _ctx = ctx;
            _isSimulatedFreyjaAtk = _ctx.Sensor.IsFreyjaAtk;
            _simulatedGame = _ctx.Sensor.ActiveGame.DeepCopy();//copy the initial game and ad a copy
        }
        /// <summary>
        /// Updates the simulation.
        /// </summary>
        internal void UpdateSimulation()
        {
            root = new SimulationNode(Guid.NewGuid().ToString(),_ctx.Sensor.ActiveTafl , 0);//create the root of the tree (getting the current state of the system)
            activeNode = root.ID;

            foreach (ValueType s in SimulatedTree)//NOPE
            {
                simulateBranch();
            }


        }
        /// <summary>
        /// Simulated nodes.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        void SimulatedNode(int x,int y,int x2,int y2)
        {
            SimulationNode Parent;
            SimulatedTree.TryGetValue(activeNode, out Parent);

            _simulatedGame = new Game(_simulatedGame.Tafl, _ctx.Sensor.IsActiveAtkPlaying);
            _simulatedGame.MovePawn(x, y, x2, y2);
            _simulatedGame.UpdateTurn();

            Move move = new Move(x, y, x2, y2);

            _key = Guid.NewGuid().ToString();//generating new key
            SimulatedTree[_key] = new SimulationNode(_key, _simulatedGame.Tafl,0, move);//creating new node

            Parent.AddChild(SimulatedTree[_key]);//linking root, designating the new created node as one of his childs 
        }
        /*
        Dictionary<string, SimulationNode> SimulatedTree = new Dictionary<string, SimulationNode>();//dictionnary containing the tree
        SimulationNode root = new SimulationNode(Guid.NewGuid().ToString(),_ctx._Sensor.ActiveTafl , 0);//create the root of the tree (getting the current state of the system)
           
        string key = Guid.NewGuid().ToString();//generating new key
        SimulatedTree[key] = new SimulationNode(key);//creating new node
        root.AddChild(SimulatedTree[key]);//linking root, designating the new created node as one of his childs 
        */
        void simulateBranch()
        {
            for (int i = 0; i < _ctx.Sensor.ActiveTafl.Width; i++)
            {
                for (int j = 0; j < _ctx.Sensor.ActiveTafl.Height; j++)
                {
                    PossibleMove possibleMove = _ctx.originGame.CanMove(i, j);
                    if (possibleMove.IsFree() == true)
                    {
                        if (_isSimulatedFreyjaAtk == true)
                        {

                            if (_ctx.Sensor.ActiveTafl[i, j] == Pawn.Attacker)
                            {
                                if (possibleMove.Up > 0)
                                {
                                    for (int up = 0; up < possibleMove.Up; up++)
                                    {
                                        SimulatedNode(i, j, i, up);
                                    }
                                }
                                if (possibleMove.Down > 0)
                                {
                                    for (int down = 0; down < possibleMove.Up; down++)
                                    {
                                        SimulatedNode(i, j, i, down);
                                    }
                                }
                                if (possibleMove.Left > 0)
                                {
                                    for (int left = 0; left < possibleMove.Up; left++)
                                    {
                                        SimulatedNode(i, j, left, j);
                                    }
                                }
                                if (possibleMove.Right > 0)
                                {
                                    for (int right = 0; right < possibleMove.Up; right++)
                                    {
                                        SimulatedNode(i, j, right, j);
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (_ctx.Sensor.ActiveTafl[i, j] == Pawn.Defender || _ctx.Sensor.ActiveTafl[i, j] == Pawn.King)
                            {
                                if (possibleMove.Up > 0)
                                {
                                    for (int up = 0; up < possibleMove.Up; up++)
                                    {
                                        SimulatedNode(i, j, i, up);
                                    }
                                }
                                if (possibleMove.Down > 0)
                                {
                                    for (int down = 0; down < possibleMove.Up; down++)
                                    {
                                        SimulatedNode(i, j, i, down);
                                    }
                                }
                                if (possibleMove.Left > 0)
                                {
                                    for (int left = 0; left < possibleMove.Up; left++)
                                    {
                                        SimulatedNode(i, j, left, j);
                                    }
                                }
                                if (possibleMove.Right > 0)
                                {
                                    for (int right = 0; right < possibleMove.Up; right++)
                                    {
                                        SimulatedNode(i, j, right, j);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
