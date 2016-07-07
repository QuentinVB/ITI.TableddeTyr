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
        internal Freyja_Core _ctx;
        internal string _key;
        internal bool _isSimulatedFreyjaAtk;
        internal Game _simulatedGame;
        SimulationNode root;
        //COLLECTION
        List<RootPawnResult> finalResult;
        /// <summary>
        /// Initializes a new instance of the <see cref="Simulate"/> class.         
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
            _simulatedGame = _ctx.Sensor.ActiveGame.DeepCopy();
            //i create the root of the tree (getting the current state of the system)                       
            root = new SimulationNode(Guid.NewGuid().ToString(), _simulatedGame.Tafl, 0, _simulatedGame.IsAtkPlaying);
            //turn 0 : initalisation
            //turn 1 : first turn (atk for ex)
            //turn 2 : etc...
            //get the list of simulable roots pawn
            Game controlGame = new Game(root.TaflStored, root.IsAtkPlay);

            List<StudiedPawn> SourcePawnsToSimulate = new List<StudiedPawn>();
            SourcePawnsToSimulate = playmyteam(SourcePawnsToSimulate, root);
            SourcePawnsToSimulate = PawnSimulatedSelector(SourcePawnsToSimulate, controlGame);
            //create an incubator for each of theses pawns and start simulate each
            finalResult = new List<RootPawnResult>();
            foreach (StudiedPawn rootpawn in SourcePawnsToSimulate)
            {
                PawnTree treeresult = new PawnTree(_ctx,_ctx.Monitor.maxIncubatedNode, _isSimulatedFreyjaAtk, _simulatedGame, rootpawn);
                RootPawnResult output = treeresult.update();               
                finalResult.Add(output);                
            }
            bool test = true;
        }
        internal static List<StudiedPawn> playmyteam(List<StudiedPawn> PawnsToSimulate, SimulationNode node)
        {
            for (int i = 0; i < node.TaflStored.Width; i++)
            {
                for (int j = 0; j < node.TaflStored.Height; j++)
                {
                    if (node.TaflStored[i, j] != Pawn.None)
                    {
                        if (AnalyzeToolbox.IsFriendly(node.TaflStored[i, j], node.IsAtkPlay)) PawnsToSimulate.Add(new StudiedPawn(i, j));
                    }
                }
            }
            return PawnsToSimulate;
        }
        /// <summary>
        /// Select the Pawn to simulate. Remove the useless pawns.
        /// </summary>
        /// <param name="PawnToSimulate">The pawns to simulate.</param>
        /// <param name="controlGame">The control game.</param>
        internal static List<StudiedPawn> PawnSimulatedSelector(List<StudiedPawn> PawnsToSimulate, Game controlGame)
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
        internal static SimulationNode GenerateNode(int x, int y, int x2, int y2, SimulationNode father)
        {
            //create a Game for this pawn move, at this tafl state and turn state.
            Game _simulatedGame = new Game(father.TaflStored, father.IsAtkPlay);
            //move the pawn (finally !)
            if (
                (father.TaflStored[x,y] == Pawn.Attacker && father.IsAtkPlay == false)
                 || (father.TaflStored[x,y] == Pawn.Defender && father.IsAtkPlay == true)
                 || (father.TaflStored[x,y] == Pawn.King && father.IsAtkPlay == true)
               ) throw new Exception(string.Format("try moved pawn {0} from [{1},{2}] at [{3},{4}] as atk = {5} ",_simulatedGame.Tafl[x,y], x,y, x2,y2, _simulatedGame.IsAtkPlaying));
           
                _simulatedGame.MovePawn(x, y, x2, y2);
           
           _simulatedGame.UpdateTurn();
            //store the move
            Move thisMove = new Move(x, y, x2, y2);
            string _key = Guid.NewGuid().ToString();//generating new key
            //creating new node containing ALL the data
            //if the origin move is on, replace to create the root of the tree
            Move origin;
            if (father.OriginMove.sourceX == 0
                && father.OriginMove.sourceY == 0
                && father.OriginMove.destinationX == 0
                && father.OriginMove.destinationY == 0) origin = thisMove;
            else { origin = father.OriginMove; }               
            return new SimulationNode(_key, _simulatedGame.Tafl, 0, origin, !father.IsAtkPlay,father.Turn+1,thisMove );
        }
        internal List<RootPawnResult> FinalResult
        {
            get
            {
                return finalResult;
            }
        }        
    }
    internal class PawnTree
    {
        internal Freyja_Core _ctx;
        string _key;
        bool _isSimulatedFreyjaAtk;
        Game _simulatedGame;
        SimulationNode root;
        int _maxIncubatedNode;
        StudiedPawn rootpawn;
        SimulationNode best;
        //collection
        Incubator incubator;
        Incubator incubatorTemp;
        //properties

        internal PawnTree (Freyja_Core ctx, int maxIncubatedNode, bool isSimulatedFreyjaAtk, Game simulatedGame, StudiedPawn rootpawn)
        {
            _ctx = ctx;
            _maxIncubatedNode = maxIncubatedNode;
            if (_maxIncubatedNode % 2 == 0) _maxIncubatedNode++;
            incubator = new Incubator(_maxIncubatedNode);

            _isSimulatedFreyjaAtk = isSimulatedFreyjaAtk;
            _simulatedGame = simulatedGame;
            this.rootpawn =  rootpawn;
        }

        internal RootPawnResult update()
        {
            //fill the incubator with possible position for the designated node
            root = new SimulationNode(Guid.NewGuid().ToString(), _simulatedGame.Tafl, 0, _simulatedGame.IsAtkPlaying);
            incubator.Add(root);//Add it to the incubator
            //set up a Game for reference the possible move
            Game controlGame = new Game(root.TaflStored, root.IsAtkPlay);
            //where can i simulate them ?
            List<StudiedPawn> PossibleSimulation = controlGame.CanMove(rootpawn.X, rootpawn.Y).FreeSquares;
            incubatorTemp = new Incubator(incubator);
            foreach (StudiedPawn d in PossibleSimulation)
            {
                //how should i simulate these pawns ?
                if(AnalyzeToolbox.IsFriendly((root.TaflStored[rootpawn.X, rootpawn.Y]),root.IsAtkPlay))
                {
                    //generate the simulated nodes, then send it to the analyze and store it to the Incubator
                    SimulationNode data = Simulate.GenerateNode(rootpawn.X, rootpawn.Y, d.X, d.Y, root);
                    data = _ctx.Analyze.UpdateAnalyze(root, data); // THING GET MESSY HERE !
                    incubatorTemp.Add(data);
                }      
            }
            incubator = new Incubator(incubatorTemp);
            //how many turn should i simulate ?
            for (int turn = 1; turn < _maxIncubatedNode; turn++)
            {
                //i send the incubator for this pawn and turn into the temp version, allowing to edit while exploring the collection
                incubatorTemp = new Incubator(incubator);
                //i get the nodes from the incubator
                foreach (SimulationNode node in incubator)
                {
                    //if the turn stored into the node into the incubator is n+1 from the turn, 
                    //then break (aka :  every pawn simulable are simulated for this turn)
                    if (node == null) break;
                    //set up a Game for reference the possible move
                    controlGame = new Game(node.TaflStored, node.IsAtkPlay);
                    //which pawns should i simulate ?
                    List<StudiedPawn> PawnsToSimulate = new List<StudiedPawn>();
                    //get all the pawn that are on the team i simulate
                    PawnsToSimulate = Simulate.playmyteam(PawnsToSimulate, node);
                    //purge the pawn list to 
                    PawnsToSimulate = Simulate.PawnSimulatedSelector(PawnsToSimulate, controlGame);
                    //i simulate each of these pawns
                    foreach (StudiedPawn p in PawnsToSimulate)
                    {
                        //where can i simulate them ?                     
                        PossibleSimulation = controlGame.CanMove(p.X, p.Y).FreeSquares;
                        foreach (StudiedPawn d in PossibleSimulation)
                        {
                            //how should i simulate these pawns ?

                            //keep only a few studied pawn into possible simulation
                           
                            if (AnalyzeToolbox.IsFriendly((node.TaflStored[p.X, p.Y]), node.IsAtkPlay))
                            {
                                //generate the simulated nodes, then send it to the analyze and store it to the Incubator
                                SimulationNode data = Simulate.GenerateNode(p.X, p.Y, d.X, d.Y, node);
                                data = _ctx.Analyze.UpdateAnalyze(node, data); // THING GET MESSY HERE !
                                incubatorTemp.Add(data);
                            }      
                        }
                    }
                }
                if (turn == 1) { incubatorTemp.RemovebyId(root.ID); }
                incubator = new Incubator(incubatorTemp);
            }
            //if (incubator != null) incubator.RemovebyTeam(_ctx.Sensor.IsFreyjaAtk);
            best =  incubator.BestNode;
            if (best.OriginMove.sourceX != rootpawn.X || best.OriginMove.sourceY != rootpawn.Y) throw new ArgumentException("NUKE THE MATRIX !");
            RootPawnResult output = new RootPawnResult(rootpawn.X, rootpawn.Y, best.Score, best.OriginMove.destinationX, best.OriginMove.destinationY);
            return output;
        }
    }
}
//int up = controlGame.CanMove(rootpawn.X, rootpawn.Y).Up;
//int down = controlGame.CanMove(rootpawn.X, rootpawn.Y).Down;
//int left = controlGame.CanMove(rootpawn.X, rootpawn.Y).Left;
//int right = controlGame.CanMove(rootpawn.X, rootpawn.Y).Right;
/*
                           int targetDistance = Math.Max(node.TaflStored.Height, node.TaflStored.Width) /( _ctx.Monitor.TargetRatio*2);
                           int distance = AnalyzeToolbox.Distance(p.X, p.Y, d.X, d.Y);
                           if(distance < targetDistance)
                           {*/
