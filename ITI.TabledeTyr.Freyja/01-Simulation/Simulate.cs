using ITI.GameCore;
using System;
using System.Collections.Generic;

namespace ITI.TabledeTyr.Freyja
{
    /// <summary>
    /// The simulate object will simulate each of pawn 
    /// </summary>
    class Simulate
    {
        private Freyja_Core _ctx;
        string _key;
        bool _isSimulatedFreyjaAtk;
        Game _simulatedGame;
        SimulationNode root;
        //collection
        Incubator incubator;
        Incubator incubatorTemp;
        /// <summary>
        /// Initializes a new instance of the <see cref="Simulate"/> class.         
        /// </summary>
        /// <param name="ctx">The contexte.</param>
        public Simulate(Freyja_Core ctx)
        {
            _ctx = ctx;
            incubator = new Incubator(_ctx.Monitor.maxIncubatedNode);
            _isSimulatedFreyjaAtk = _ctx.Sensor.IsFreyjaAtk;
            _simulatedGame = _ctx.Sensor.ActiveGame.DeepCopy();//copy the initial game and and a copy of the tafl inside
        }
        /// <summary>
        /// Updates the simulation. aka : CPU and RAM now suffers !!
        /// </summary>
        internal void UpdateSimulation()
        {
            //i create the root of the tree (getting the current state of the system)
            root = new SimulationNode(Guid.NewGuid().ToString(),_simulatedGame.Tafl ,0,_simulatedGame.IsAtkPlaying);
            //turn 0 : initalisation
            //turn 1 : first turn (atk for ex)
            //turn 2 : etc...
            incubator.Add(root);//Add it to the incubator
            //how many turn should i simulate ?
            for (int turn = 1; turn < _ctx.Monitor.MaxSim; turn++)
            {
                //i send the incubator for this turn into the temp version, allowing to edit while exploring the collection
                incubatorTemp = new Incubator(incubator);
                //i get the nodes from the incubator
                foreach (SimulationNode node in incubator)
                {
                    //if the turn stored into the node into the incubator is n+1 from the turn, 
                    //then break (aka :  every pawn simulable are simulated for this turn)
                    if (node == null) break;
                    //set up a Game for reference the possible move
                    Game controlGame = new Game(node.TaflStored, node.IsAtkPlay);

                    //which pawns should i simulate ?
                    List<StudiedPawn> PawnsToSimulate = new List<StudiedPawn>();
                    //get all the pawn that are on the team i simulate
                    for (int i = 0; i < node.TaflStored.Width; i++)
                    {
                        for (int j = 0; j < node.TaflStored.Height; j++)
                        {
                            if(node.TaflStored[i, j] != Pawn.None)
                            { 
                              if (AnalyzeToolbox.IsFriendly(node.TaflStored[i, j], node.IsAtkPlay)) PawnsToSimulate.Add(new StudiedPawn(i, j));
                            }
                        }
                    }
                    //purge the pawn list to 
                    PawnsToSimulate = PawnSimulatedSelector(PawnsToSimulate, controlGame);
                    //i simulate each of these pawns
                    foreach (StudiedPawn p in PawnsToSimulate)
                    {
                        //where can i simulate them ?
                        int up = controlGame.CanMove(p.X,p.Y).Up;
                        int down = controlGame.CanMove(p.X,p.Y).Down;
                        int left = controlGame.CanMove(p.X,p.Y).Left;
                        int right = controlGame.CanMove(p.X,p.Y).Right;
                        List<StudiedPawn> PossibleSimulation = controlGame.CanMove(p.X, p.Y).FreeSquares;
                        //how should i simulate these pawns ?
                        //keep only a few studied pawn into possible simulation
                        //int xRatio = 0;

                        foreach (StudiedPawn d in PossibleSimulation)
                        {
                            //generate the simulated nodes, then send it to the analyze and store it to the Incubator
                            incubatorTemp.Add(_ctx.Analyze.UpdateAnalyze(node, GenerateNode(p.X,p.Y, d.X, d.Y, node)));
                        }                      
                    }
                }
                incubator= new Incubator(incubatorTemp);
            }
        }
        /// <summary>
        /// Select the Pawn to simulate. Remove the useless pawns.
        /// </summary>
        /// <param name="PawnToSimulate">The pawns to simulate.</param>
        /// <param name="controlGame">The control game.</param>
        private List<StudiedPawn> PawnSimulatedSelector(List<StudiedPawn> PawnsToSimulate, Game controlGame)
        {
            List<StudiedPawn> outPawnsToSimulate =  new List<StudiedPawn>(PawnsToSimulate);

            foreach (StudiedPawn p in PawnsToSimulate)
            {
                //Remove useless pawn, aka : cannot move this turn
                if (controlGame.CanMove(p.X, p.Y).IsFree == false) outPawnsToSimulate.Remove(p);
            }
            return outPawnsToSimulate;
        }

        /// <summary>
        /// Simulate nodes by using data send.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="x2">The x2.</param>
        /// <param name="y2">The y2.</param>
        SimulationNode GenerateNode(int x, int y, int x2, int y2, SimulationNode father)
        {
            //create a Game for this pawn move, at this tafl state and turn state.
            _simulatedGame = new Game(father.TaflStored, father.IsAtkPlay);
            //move the pawn (finally !)
            _simulatedGame.MovePawn(x, y, x2, y2);
            _simulatedGame.UpdateTurn();
            //store the move
            Move thisMove = new Move(x, y, x2, y2);
            _key = Guid.NewGuid().ToString();//generating new key
            //creating new node containing ALL the data
            return new SimulationNode(_key, _simulatedGame.Tafl, 0, father.OriginMove, !father.IsAtkPlay,father.Turn+1,thisMove );
        }
        internal Incubator Incubator
        {
            get
            {
                return incubator;
            }
        }   
    }
}
