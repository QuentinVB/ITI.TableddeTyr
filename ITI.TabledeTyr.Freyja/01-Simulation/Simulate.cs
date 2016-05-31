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
        internal string _key;
        internal bool _isSimulatedFreyjaAtk;
        internal Game _simulatedGame;

        Dictionary<string, SimulationNode> SimulatedTree = new Dictionary<string, SimulationNode>();//dictionnary containing the tree
        

        public Simulate(Freyja_Core ctx)
        {
            _ctx = ctx;
            _isSimulatedFreyjaAtk = _ctx._Sensor._isFreyjaAtk;
            _simulatedGame = _ctx._Sensor._game.DeedCopy();
        }
        void UpdateSimulation()
        {
            SimulationNode root = new SimulationNode(Guid.NewGuid().ToString(),_ctx._Sensor.currentTafl , 0);//create the root of the tree (getting the current state of the system)

            for (int i = 0; i < _ctx._Sensor.currentTafl.Width; i++)
            {
                for (int j = 0; j < _ctx._Sensor.currentTafl.Height; j++)
                {
                    if( _isSimulatedFreyjaAtk == true)
                    {
                        PossibleMove possibleMove = _ctx.originGame.CanMove(i, j);
                        if (possibleMove.IsFree() == true)
                        {
                            if (_ctx._Sensor.currentTafl[i, j] == Pawn.Attacker)
                            {
                                if(possibleMove.Up > 0)
                                {
                                    for (int up = 0; up < possibleMove.Up; up++)
                                    {
                                        //createnode HERE
                                    }
                                }
                                if (possibleMove.Down > 0)
                                {
                                    for (int down = 0; down < possibleMove.Up; down++)
                                    {
                                        //createnode HERE
                                    }
                                }
                                if (possibleMove.Left > 0)
                                {
                                    for (int left = 0; left < possibleMove.Up; left++)
                                    {
                                        //createnode HERE
                                    }
                                }
                                if (possibleMove.Right > 0)
                                {
                                    for (int right = 0; right < possibleMove.Up; right++)
                                    {
                                        //createnode HERE
                                    }
                                }
                            }                            
                        }
                    }
                    else
                    {
                        if (_ctx._Sensor.currentTafl[i, j] == Pawn.Defender || _ctx._Sensor.currentTafl[i, j] == Pawn.King)
                        {

                        }
                    }
                    


                }
            }


        }
        void Movement(int x,int y,int x2,int y2)
        {
            _simulatedGame.MovePawn(x, y, x2, y2);
            _simulatedGame.UpdateTurn();
        }
        /*
        Dictionary<string, SimulationNode> SimulatedTree = new Dictionary<string, SimulationNode>();//dictionnary containing the tree
        SimulationNode root = new SimulationNode(Guid.NewGuid().ToString(),_ctx._Sensor.currentTafl , 0);//create the root of the tree (getting the current state of the system)
           
        string key = Guid.NewGuid().ToString();//generating new key
        SimulatedTree[key] = new SimulationNode(key);//creating new node
        root.AddChild(SimulatedTree[key]);//linking root, designating the new created node as one of his childs 
        */
    }
}
