using System;
using System.Collections.Generic;

namespace ITI.GameCore
{
    public class Game : IGame
    {
        //ATTRIBUTES        
        bool _atkTurn; //true if it is the turn of attacker, else false if the turn of defender
        //COLLECTION
        ITafl _tafl;
        //CONSTRUCTOR(s)        
        /// <summary>
        /// Initializes a new instance of the <see cref="Game" /> class. If nothing recieved, create a default game and initalize the game
        /// </summary>
        //if nothing is send : create a default game 11*11, atk start.
        public Game()
            : this(Helper.GetDefaultTafl(), true)
        {
        }
        //if w,h recieved, try to find a saved xml version with those size, if failed... open a blank game with those size
        public Game(int width, int height)
            : this(GetWHTafl(width,height), true)
        {}
        static IReadOnlyTafl GetWHTafl(int width, int height)
        {
            XML_Tafl XmlIO = new XML_Tafl();
            TaflBasic tafl;
            try
            {
                tafl = XmlIO.ReadXmlTafl(width, height);
            }
            catch
            {
                tafl = new TaflBasic(Helper.GetDefaultTafl());
            }

            return tafl;
        }
        //if an xml string is recieved, try to load the game from it
        public Game(string xmlPath)
            : this(GetXMLTafl(xmlPath), true)
        {
        }
        static IReadOnlyTafl GetXMLTafl(string path)
        {
            XML_Tafl XmlIO = new XML_Tafl();
            TaflBasic tafl;
            try
            {
                tafl = XmlIO.ReadXmlTafl(path);
            }
            catch
            {
                tafl = new TaflBasic(Helper.GetDefaultTafl());
            }
            return tafl;
        }
        //Base, a game need a description of a tafl and wich player start to begin
        public Game(IReadOnlyTafl tafl, bool atkTurn)
        {
            _tafl = new TaflBasic(tafl);
            _atkTurn = atkTurn;
        }
        //PROPERTIES
        public bool IsAtkPlaying => _atkTurn;//get the current player turn, true if it is the the attacker     
        public IReadOnlyTafl Tafl => _tafl;
        //METHODS - INTERNAL                
        /// <summary>
        /// check the capture around this piece then remove the piece(s).
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        internal void CheckCapture(int x, int y)
        {
            Pawn movedPawn = _tafl[x, y];
            List<StudiedPawn> targetedGroup = new List<StudiedPawn>(); // List defined for GetGroup to use
            //Test basic capture, then if there is a group
            if (!Helper.CheckWalls(x, y - 1, _tafl)) //up
            {
                if (!IsFriendly(movedPawn, x, y - 1))
                {
                    if (_tafl[x, y - 1] != Pawn.King && (IsFriendly(movedPawn, x, y - 2) || Helper.CheckWalls(x, y - 2, _tafl))) _tafl[x, y - 1] = Pawn.None;
                    if (_tafl[x, y - 1] != Pawn.None)
                    {
                        targetedGroup = new List<StudiedPawn>();
                        GetGroup(x, y - 1, targetedGroup);
                        if (IsCircled(targetedGroup)) Execute(targetedGroup);
                    }

                }
            }

            if (!Helper.CheckWalls(x, y + 1, _tafl)) //down
            {
                if (!IsFriendly(movedPawn, x, y + 1))
                {
                    if (_tafl[x, y + 1] != Pawn.King && (IsFriendly(movedPawn, x, y + 2) || Helper.CheckWalls(x, y + 2, _tafl))) _tafl[x, y + 1] = Pawn.None;
                    if (_tafl[x, y + 1] != Pawn.None)
                    {
                        targetedGroup = new List<StudiedPawn>();
                        GetGroup(x, y + 1, targetedGroup);
                        if (IsCircled(targetedGroup)) Execute(targetedGroup);
                    }
                }
            }
            if (!Helper.CheckWalls(x - 1, y, _tafl)) //left
            {
                if (!IsFriendly(movedPawn, x - 1, y))
                {
                    if (_tafl[x - 1, y] != Pawn.King && (IsFriendly(movedPawn, x - 2, y) || Helper.CheckWalls(x - 2, y, _tafl))) _tafl[x - 1, y] = Pawn.None;
                    if (_tafl[x - 1, y] != Pawn.None)
                    {
                        targetedGroup = new List<StudiedPawn>();
                        GetGroup(x - 1, y, targetedGroup);
                        if (IsCircled(targetedGroup)) Execute(targetedGroup);
                    }
                }
            }
            if (!Helper.CheckWalls(x + 1, y, _tafl)) //right
            {
                if (!IsFriendly(movedPawn, x + 1, y))
                {
                    if (_tafl[x + 1, y] != Pawn.King && (IsFriendly(movedPawn, x + 2, y) || Helper.CheckWalls(x + 2, y, _tafl))) _tafl[x + 1, y] = Pawn.None;
                    if (_tafl[x + 1, y] != Pawn.None)
                    {
                        targetedGroup = new List<StudiedPawn>();
                        GetGroup(x + 1, y, targetedGroup);
                        if (IsCircled(targetedGroup)) Execute(targetedGroup);
                    }

                }
            }
        }
        //Search and define a possible group of Pawn (for capture)
        internal void GetGroup(int x, int y, List<StudiedPawn> pawnList)
        {
            StudiedPawn Current = new StudiedPawn(x, y);
            if (!pawnList.Contains(Current))
            {
                pawnList.Add(Current);
                if (IsFriendly(_tafl[x, y], x, y - 1)) GetGroup(x, y - 1, pawnList);
                if (IsFriendly(_tafl[x, y], x, y + 1)) GetGroup(x, y + 1, pawnList);
                if (IsFriendly(_tafl[x, y], x - 1, y)) GetGroup(x - 1, y, pawnList);
                if (IsFriendly(_tafl[x, y], x + 1, y)) GetGroup(x + 1, y, pawnList);
            }
        }
        //Complex capture and King capture algorithm
        internal bool IsCircled(List<StudiedPawn> pawnList)
        {
            foreach (StudiedPawn current in pawnList)
            {
                if (CanMove(current.X, current.Y).IsFree) return false;
            }
            return true;
        }
        //Kills the whole list of targetedPawns
        internal void Execute(List<StudiedPawn> pawnList)
        {
            foreach (StudiedPawn current in pawnList) _tafl[current.X, current.Y] = Pawn.None;
        }
        //Checks if the pawn is friendly
        internal bool IsFriendly(Pawn target, int x, int y)
        {
            if (target == Pawn.Attacker && _tafl[x, y] == Pawn.Attacker) return true;
            if ((target == Pawn.Defender || target == Pawn.King) && (_tafl[x, y] == Pawn.Defender || _tafl[x, y] == Pawn.King)) return true;
            return false;
        }

        /// <summary>
        ///check if victory condition for the defensor are met (aka the king reach the forteress)
        ///or stop while recieving true from <see cref="CheckCapture"/> the king is alredy dead. Long live the king !
        /// </summary>
        /// <returns>true : someone as won, false : nobody won, next turn</returns>
        internal bool CheckVictoryCondition()
        {
            //check presence of the king in each forteress
            if ((_tafl[0, 0] == Pawn.King)
                || (_tafl[0, _tafl.Height - 1] == Pawn.King)
                || (_tafl[_tafl.Width - 1, 0] == Pawn.King)
                || (_tafl[_tafl.Width - 1, _tafl.Height - 1] == Pawn.King)
                || (!_tafl.HasKing)//check if the king is still alive
                ) return true;
            return false;
        }

        //METHODES - PUBLIC        
        /// <summary>
        /// Determines if the pawn designated by x and y can move and how many step in each direction. 
        /// Store it inside a Struct <see cref="PossibleMove"/>.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        public PossibleMove CanMove(int x, int y)
        {
            //Exception goes here
            Helper.CheckRange(_tafl.Width, _tafl.Height, x, y);
            //Creating directions
            List<StudiedPawn> FreeSquares = new List<StudiedPawn>();
            int m; //Martyr, gonna be used and abused  in the checkers - replaces the line or collumn where the checkers work
            //Checks above
            m = y;
            while (Helper.CheckUp(x, m, _tafl))
            {
                if (Helper.CheckWalls(x, m - 1, _tafl) && _tafl[x, y] == Pawn.King)
                {
                    StudiedPawn studiedPawn = new StudiedPawn(x, m - 1);
                    FreeSquares.Add(studiedPawn);
                    m--;
                }
                else if (!Helper.CheckWalls(x, m - 1, _tafl))
                {
                    StudiedPawn studiedPawn = new StudiedPawn(x, m - 1);
                    FreeSquares.Add(studiedPawn);
                    m--;
                }
                else m--;

            }
            //Check below
            m = y;
            while (Helper.CheckDown(x, m, _tafl))
            {
                if (Helper.CheckWalls(x, m + 1, _tafl) && _tafl[x, y] == Pawn.King)
                {
                    StudiedPawn studiedPawn = new StudiedPawn(x, m + 1);
                    FreeSquares.Add(studiedPawn);
                    m++;
                }
                else if (!Helper.CheckWalls(x, m + 1, _tafl))
                {
                    StudiedPawn studiedPawn = new StudiedPawn(x, m + 1);
                    FreeSquares.Add(studiedPawn);
                    m++;
                }
                else m++;

            }
            //Check left
            m = x;
            while (Helper.CheckLeft(m, y, _tafl))
            {
                if (Helper.CheckWalls(m - 1, y, _tafl) && _tafl[x, y] == Pawn.King)
                {
                    StudiedPawn studiedPawn = new StudiedPawn(m - 1, y);
                    FreeSquares.Add(studiedPawn);
                    m--;
                }
                else if (!Helper.CheckWalls(m - 1, y, _tafl))
                {
                    StudiedPawn studiedPawn = new StudiedPawn(m - 1, y);
                    FreeSquares.Add(studiedPawn);
                    m--;
                }
                else m--;

            }
            //Check right
            m = x;
            while (Helper.CheckRight(m, y, _tafl))
            {
                if (Helper.CheckWalls(m + 1, y, _tafl) && _tafl[x, y] == Pawn.King)
                {
                    StudiedPawn studiedPawn = new StudiedPawn(m + 1, y);
                    FreeSquares.Add(studiedPawn);
                    m++;
                }
                else if (!Helper.CheckWalls(m + 1, y, _tafl))
                {
                    StudiedPawn studiedPawn = new StudiedPawn(m + 1, y);
                    FreeSquares.Add(studiedPawn);
                    m++;
                }
                else m++;

            }
            //struct ConstrucTHOR & return
            PossibleMove _possibleMove = new PossibleMove(x, y, FreeSquares, _tafl[x, y]);
            return _possibleMove;
        }
        /// <summary>
        /// Allows the designated pieces to move the piece to another coordinate,
        /// call <see cref="CheckWalls" /> by secure.
        /// </summary>
        /// <param name="x">The x position of the piece who move.</param>
        /// <param name="y">The y position of the piece who move.</param>
        /// <param name="x2">The x2 targeted position of the piece who move.</param>
        /// <param name="y2">The y2 targeted position of the piece who move.</param>
        /// <returns>
        /// true if the move is good. false something bad happend. FI: god(s) kill(s) a kitten
        /// </returns>
        /// <exception cref="System.ArgumentException">Cannot enter the throne you puny pawn !</exception>
        /// <exception cref="System.ArgumentException">Cannot move opposite pawn, you bastard cheater !</exception>
        public bool MovePawn(int x, int y, int x2, int y2)
        {
            //Exceptions and tests goes here
            if (IsAtkPlaying == true && (_tafl[x, y] == Pawn.Defender || _tafl[x, y] == Pawn.King)) throw new ArgumentException("Cannot move opposite pawn, you bastard cheater !");
            if (IsAtkPlaying == false && _tafl[x, y] == Pawn.Attacker) throw new ArgumentException("Cannot move opposite pawn, you bastard cheater !");
            Helper.CheckRange(_tafl.Width, _tafl.Height, x, y);
            Helper.CheckRange(_tafl.Width, _tafl.Height, x2, y2);
            if (x == x2 && y == y2) return false;
            //Core
            foreach (StudiedPawn current in CanMove(x, y).FreeSquares)
            {
                if (current.X == x2 && current.Y == y2)
                {
                    _tafl[x2, y2] = _tafl[x, y];
                    _tafl[x, y] = Pawn.None;
                    CheckCapture(x2, y2);
                    return true;
                }
            }
            return false;

        }
        /// <summary>
        /// Called by the player's UI after getting the confirmation of his move in <see cref="MovePawn" />
        /// Call <see cref="CheckCapture" />, <see cref="CheckVictoryCondition" /> and switch to next player.
        /// </summary>
        /// <returns>
        /// false if the game is over and break before flipping the turn. The current <paramref name="_atkTurn" /> is the winner.
        /// </returns>
        public bool UpdateTurn()
        {
            CheckVictoryCondition();
            if (CheckVictoryCondition()) return false;
            else
            {
                _atkTurn = !_atkTurn;
                return true;
            }
        }

        //tools for freyja :p
        /// <summary>
        /// Copy in deep the game and the tafl.
        /// </summary>
        /// <returns>A clone of this Game</returns>
        public Game DeepCopy()
        {
            Game copy = (Game)MemberwiseClone();
            copy._tafl = new TaflBasic(_tafl);
            return copy;
        }
    }
}