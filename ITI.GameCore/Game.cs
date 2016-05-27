using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.GameCore
{
    public class Game
    {
        //attributes        
        bool _atkTurn; //true if it is the turn of attacker, else false if the turn of defender
        //collection
        internal ITafl _tafl;
        //constructor(s)        
        /// <summary>
        /// Initializes a new instance of the <see cref="Game" /> class.
        /// </summary>
        public Game()
        {
            _tafl = new TaflBasic(11, 11);
            //Sets an empty tafl
            for (int y = 0; y < 11; y++)
            {
                for (int x = 0; x < 11; x++)
                {
                    _tafl[x, y] = Pawn.None;
                }
            }
            //Sets board for a standard 11*11 game [Hardcoded for IT1]
            #region Setting the board
            /*
             x 00 01 02 03 04 05 06 07 08 09 10 x
            00 -- -- -- 01 01 01 01 01 -- -- --
            01 -- -- -- -- -- 01 -- -- -- -- --
            02 -- -- -- -- -- -- -- -- -- -- --
            03 01 -- -- -- -- 10 -- -- -- -- 01
            04 01 -- -- -- 10 10 10 -- -- -- 01
            05 01 01 -- 10 10 11 10 10 -- 01 01
            06 01 -- -- -- 10 10 10 -- -- -- 01
            07 01 -- -- -- -- 10 -- -- -- -- 01
            08 -- -- -- -- -- -- -- -- -- -- --
            09 -- -- -- -- -- 01 -- -- -- -- --
            10 -- -- -- 01 01 01 01 01 -- -- --
            y

            */
            //Set the king and defenders
            _tafl[5, 5] = Pawn.King;
            _tafl[3, 5] = Pawn.Defender;
            _tafl[4, 4] = Pawn.Defender;
            _tafl[4, 5] = Pawn.Defender;
            _tafl[4, 6] = Pawn.Defender;
            _tafl[5, 3] = Pawn.Defender;
            _tafl[5, 4] = Pawn.Defender;
            _tafl[5, 6] = Pawn.Defender;
            _tafl[5, 7] = Pawn.Defender;
            _tafl[6, 4] = Pawn.Defender;
            _tafl[6, 5] = Pawn.Defender;
            _tafl[6, 6] = Pawn.Defender;
            _tafl[7, 5] = Pawn.Defender;
            //Set the attackers
            _tafl[0, 3] = Pawn.Attacker;
            _tafl[0, 4] = Pawn.Attacker;
            _tafl[0, 5] = Pawn.Attacker;
            _tafl[0, 6] = Pawn.Attacker;
            _tafl[0, 7] = Pawn.Attacker;
            _tafl[1, 5] = Pawn.Attacker;
            _tafl[3, 0] = Pawn.Attacker;
            _tafl[3, 10] = Pawn.Attacker;
            _tafl[4, 0] = Pawn.Attacker;
            _tafl[4, 10] = Pawn.Attacker;
            _tafl[5, 0] = Pawn.Attacker;
            _tafl[5, 1] = Pawn.Attacker;
            _tafl[5, 9] = Pawn.Attacker;
            _tafl[5, 10] = Pawn.Attacker;
            _tafl[6, 0] = Pawn.Attacker;
            _tafl[6, 10] = Pawn.Attacker;
            _tafl[7, 0] = Pawn.Attacker;
            _tafl[7, 10] = Pawn.Attacker;
            _tafl[9, 5] = Pawn.Attacker;
            _tafl[10, 3] = Pawn.Attacker;
            _tafl[10, 4] = Pawn.Attacker;
            _tafl[10, 5] = Pawn.Attacker;
            _tafl[10, 6] = Pawn.Attacker;
            _tafl[10, 7] = Pawn.Attacker;
            #endregion

            //Sets the attacker as the first turn, allowing the game to start
            _atkTurn = true;
        }
        //properties
        public bool IsAtkPlaying => _atkTurn;//get the current player turn, true if it is the the attacker     
        public IReadOnlyTafl Tafl => _tafl;

        //Methods - internal                
        /// <summary>
        /// check the capture around this piece then remove the piece(s).
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>If the piece captured is the king, return true</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        internal void CheckCapture(int x, int y)
        {
            #region Checks for defenders and King (a.k.a attackers are playing)
            if (_atkTurn == true)
            {
                //Checking Up (x,y-1)
                #region Up
                if (!CheckWalls(x, y - 1))
                {
                    //Finding a simple defender
                    if (_tafl[x, y - 1] == Pawn.Defender)
                    {
                        if (CheckWalls(x, y - 2))
                        {
                            _tafl[x, y - 1] = Pawn.None;
                        }
                        else if (_tafl[x, y - 2] == Pawn.Attacker)
                        {
                            _tafl[x, y - 1] = Pawn.None;
                        }
                    }
                    //Finding the King
                    if (_tafl[x, y - 1] == Pawn.King)
                    {
                        if (CheckWalls(x, y - 2))//Above
                        {
                            if (CheckWalls(x - 1, y - 1))//Left
                            {
                                if (CheckWalls(x + 1, y - 1))//Right
                                {
                                    _tafl[x, y - 1] = Pawn.None;
                                }
                            }
                        }
                        else if (_tafl[x, y - 2] == Pawn.Attacker)//Above
                        {
                            if (_tafl[x - 1, y - 1] == Pawn.Attacker)//Left
                            {
                                if (_tafl[x + 1, y + 1] == Pawn.Attacker)//Right
                                {
                                    _tafl[x, y - 1] = Pawn.None;
                                }
                            }
                        }
                    }
                }
                #endregion
                //Checking Down (x,y+1)
                #region Down
                if (!CheckWalls(x, y + 1))
                {
                    //Finding a simple defender
                    if (_tafl[x, y + 1] == Pawn.Defender)
                    {
                        if (CheckWalls(x, y + 2))
                        {
                            _tafl[x, y + 1] = Pawn.None;
                        }
                        else if (_tafl[x, y + 2] == Pawn.Attacker)
                        {
                            _tafl[x, y + 1] = Pawn.None;
                        }
                    }
                    //Finding the King
                    if (_tafl[x, y + 1] == Pawn.King)
                    {
                        if (CheckWalls(x, y + 2))//Under
                        {
                            if (CheckWalls(x - 1, y + 1))//Left
                            {
                                if (CheckWalls(x + 1, y + 1))//Right
                                {
                                    _tafl[x, y + 1] = Pawn.None;
                                }
                            }
                        }
                        if (_tafl[x, y + 2] == Pawn.Attacker)//Under
                        {
                            if (_tafl[x - 1, y + 1] == Pawn.Attacker)//Left
                            {
                                if (_tafl[x + 1, y + 1] == Pawn.Attacker)//Right
                                {
                                    _tafl[x, y + 1] = Pawn.None;
                                }
                            }
                        }
                    }
                }
                #endregion
                //Checking Left Left(x-1,y)
                #region Left
                if (!CheckWalls(x - 1, y))
                {
                    //Finding a simple defender
                    if (_tafl[x - 1, y] == Pawn.Defender)
                    {
                        if (CheckWalls(x - 2, y))
                        {
                            _tafl[x - 1, y] = Pawn.None;
                        }
                        else if (_tafl[x - 2, y] == Pawn.Attacker)
                        {
                            _tafl[x - 1, y] = Pawn.None;
                        }
                    }
                    //Finding the King
                    if (_tafl[x - 1, y] == Pawn.King)
                    {
                        if (CheckWalls(x - 1, y - 1))//Above
                        {
                            if (CheckWalls(x - 1, y + 1))//Under
                            {
                                if (CheckWalls(x - 2, y))//Left
                                {
                                    _tafl[x - 1, y] = Pawn.None;
                                }
                            }
                        }
                        if (_tafl[x - 1, y - 1] == Pawn.Attacker)//Above
                        {
                            if (_tafl[x - 1, y + 1] == Pawn.Attacker)//Under
                            {
                                if (_tafl[x - 2, y] == Pawn.Attacker)//Left
                                {
                                    _tafl[x - 1, y] = Pawn.None;
                                }
                            }
                        }
                    }
                }
                #endregion
                //Checking Right(x+1,y)
                #region Right
                if (!CheckWalls(x + 1, y))
                {
                    //Finding a simple defender
                    if (_tafl[x + 1, y] == Pawn.Defender)
                    {
                        if (CheckWalls(x + 2, y))
                        {
                            _tafl[x + 1, y] = Pawn.None;
                        }
                        else if (_tafl[x + 2, y] == Pawn.Attacker)
                        {
                            _tafl[x + 1, y] = Pawn.None;
                        }
                    }
                    //Finding the King
                    if (_tafl[x + 1, y] == Pawn.King)
                    {
                        if (CheckWalls(x + 1, y - 1))//Above
                        {
                            if (CheckWalls(x + 1, y + 1))//Under
                            {
                                if (CheckWalls(x + 2, y))//Right
                                {
                                    _tafl[x + 1, y] = Pawn.None;
                                }
                            }
                        }
                        else if (_tafl[x + 1, y - 1] == Pawn.Attacker)//Above
                        {
                            if (_tafl[x + 1, y + 1] == Pawn.Attacker)//Under
                            {
                                if (_tafl[x + 2, y] == Pawn.Attacker)//Right
                                {
                                    _tafl[x + 1, y] = Pawn.None;
                                }
                            }
                        }
                    }
                }
                #endregion
            }
            #endregion
            #region Checks for attackers (a.k.a defenders are playing)
            if (_atkTurn == false)
            {
                //Checking Up (x,y-1)
                if (!CheckWalls(x, y - 1))
                {
                    if (_tafl[x, y - 1] == Pawn.Attacker)
                    {
                        if (CheckWalls(x, y - 2))
                        {
                            _tafl[x, y - 1] = Pawn.None;
                        }
                        else if (_tafl[x, y - 2] == Pawn.Defender || _tafl[x, y - 2] == Pawn.King)
                        {
                            _tafl[x, y - 1] = Pawn.None;
                        }
                    }
                }
                //Checking Down (x,y+1)
                if (!CheckWalls(x, y + 1))
                {
                    if (_tafl[x, y + 1] == Pawn.Attacker)
                    {
                        if (CheckWalls(x, y + 2))
                        {
                            _tafl[x, y + 1] = Pawn.None;
                        }
                        else if (_tafl[x, y + 2] == Pawn.Defender || _tafl[x, y + 2] == Pawn.King)
                        {
                            _tafl[x, y + 1] = Pawn.None;
                        }
                    }
                }
                //Checking Left Left(x-1,y)
                if (!CheckWalls(x - 1, y))
                {
                    if (_tafl[x - 1, y] == Pawn.Attacker)
                    {
                        if (CheckWalls(x - 2, y))
                        {
                            _tafl[x - 1, y] = Pawn.None;
                        }
                        else if (_tafl[x - 2, y] == Pawn.Defender || _tafl[x - 2, y] == Pawn.King)
                        {
                            _tafl[x - 1, y] = Pawn.None;
                        }
                    }
                }
                //Checking Right(x+1,y)
                if (!CheckWalls(x + 1, y))
                {
                    if (_tafl[x + 1, y] == Pawn.Attacker)
                    {
                        if (CheckWalls(x + 2, y))
                        {
                            _tafl[x + 1, y] = Pawn.None;
                        }
                        else if (_tafl[x + 2, y] == Pawn.Defender || _tafl[x + 2, y] == Pawn.King)
                        {
                            _tafl[x + 1, y] = Pawn.None;
                        }
                    }
                }

            }
            #endregion            
        }
        //Checkers for walls & fortresses
        internal bool CheckWalls(int x, int y)
        {
            if ((_tafl[x, y] == Pawn.Wall)
                ||(x == 0 && y == 0)  //Top left corner
                ||(x == 0 && y == _tafl.Height - 1) //Bot left corner
                ||(x == _tafl.Width - 1 && y == 0)  //top right corner
                ||(x == _tafl.Width - 1 && y == _tafl.Height - 1)  //Bot right corner
                || (x == (_tafl.Width - 1) / 2 && y == (_tafl.Height - 1) / 2)//Throne
                ) return true; 
            return false;
        }
        /// <summary>
        ///check if victory condition for the defensor are met (aka the king reach the forteress)
        ///or stop while recieving true from <see cref="CheckCapture"/> the king is alredy dead. Long live the king !
        /// </summary>
        /// <returns>true : someone as won, false : nobody won, next turn</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        internal bool CheckVictoryCondition()
        {
            //check presence of the king in each forteress
            if (_tafl[0, 0] == Pawn.King) return true;
            if (_tafl[0, _tafl.Height - 1] == Pawn.King) return true;
            if (_tafl[_tafl.Width - 1, 0] == Pawn.King) return true;
            if (_tafl[_tafl.Width - 1, _tafl.Height - 1] == Pawn.King) return true;
            //check if the king is still alive
            if (!_tafl.HasKing) return true;
            return false;
        }
        #region Checkers for emptyness
        internal bool CheckUp(int x, int y)
        {
            if (y - 1 < 0 || _tafl[x, y - 1] != Pawn.None) return false;
            if (_tafl[x, y - 1] == Pawn.None) return true;
            return false;
        }
        internal bool CheckDown(int x, int y)
        {
            if (y + 1 >= _tafl.Height || _tafl[x, y + 1] != Pawn.None) return false;
            if (_tafl[x, y + 1] == Pawn.None) return true;
            return false;
        }
        internal bool CheckLeft(int x, int y)
        {
            if (x - 1 < 0 || _tafl[x - 1, y] != Pawn.None) return false;
            if (_tafl[x - 1, y] == Pawn.None) return true;
            return false;
        }
        internal bool CheckRight(int x, int y)
        {
            if (x + 1 >= _tafl.Width || _tafl[x + 1, y] != Pawn.None) return false;
            if (_tafl[x + 1, y] == Pawn.None) return true;
            return false;
        }
        #endregion
        //methodes - public        
        public PossibleMove CanMove(int x, int y)
        {
            //Exception goes here
            Helper.CheckRange(_tafl.Width, _tafl.Height, x, y);
            //Creating directions
            int up = 0;
            int down = 0;
            int left = 0;
            int right = 0;
            int m; //Martyr, gonna be used and abused  in the checkers - replaces the line or collumn where the checkers work
            //Checks above
            m = y;
            while (CheckUp(x, m))
            {
                m--;
                up++;
            }
            //Check below
            m = y;
            while (CheckDown(x, m))
            {
                m++;
                down++;
            }
            //Check left
            m = x;
            while (CheckLeft(m, y))
            {
                m--;
                left++;
            }
            //Check right
            m = x;
            while (CheckRight(m, y))
            {
                m++;
                right++;
            }
            //struct ConstrucTHOR & return
            PossibleMove _possibleMove = new PossibleMove(x, y, up, down, left, right, _tafl[x,y]);
            return _possibleMove;
        }
        /// <summary>
        /// Allows the designated pieces to move the piece to another coordinate,
        /// call <see cref="CheckMove" /> by secure.
        /// </summary>
        /// <param name="x">The x position of the piece who move.</param>
        /// <param name="y">The y position of the piece who move.</param>
        /// <param name="x2">The x2 targeted position of the piece who move.</param>
        /// <param name="y2">The y2 targeted position of the piece who move.</param>
        /// <returns>
        /// true if the move is good. false something bad happend. FI: god(s) kill(s) a kitten
        /// </returns>
        /// <exception cref="System.ArgumentException">Cannot enter the throne</exception>
        /// <exception cref="System.ArgumentException">Cannot move opposite pawn, you bastard cheater !</exception>
        public bool MovePawn(int x, int y, int x2, int y2)
        {
            if (IsAtkPlaying == true && (_tafl[x, y] == Pawn.Defender || _tafl[x, y] == Pawn.King)) throw new ArgumentException("Cannot move opposite pawn, you bastard cheater !");
            if (IsAtkPlaying == false && _tafl[x, y] == Pawn.Attacker) throw new ArgumentException("Cannot move opposite pawn, you bastard cheater !");
            Helper.CheckRange(_tafl.Width, _tafl.Height, x, y);
            Helper.CheckRange(_tafl.Width, _tafl.Height, x2, y2);
            if (x == x2 && y == y2) return false;
            if (_tafl[x, y] != Pawn.King)
            {
                if (CheckWalls(x2, y2))
                    throw new ArgumentException("Cannot enter the throne or a forteress, you punny pawn  !");
            }

            //Verifying that the move is leggit (TryMove might've been bypassed)
            if (x > x2)
            {
                for (int i = x; i > x2; i--)
                {
                    if (!CheckLeft(i, y)) return false;
                }
                _tafl[x2, y2] = _tafl[x, y];
                _tafl[x, y] = Pawn.None;
                CheckCapture(x2, y2);
                return true;
            }
            if (x < x2)
            {
                for (int i = x; i < x2; i++)
                {
                    if (!CheckRight(i, y)) return false;
                }
                _tafl[x2, y2] = _tafl[x, y];
                _tafl[x, y] = Pawn.None;
                CheckCapture(x2, y2);
                return true;
            }
            if (y > y2)
            {
                for (int i = y; i > y2; i--)
                {
                    if (!CheckUp(x, i)) return false;
                }
                _tafl[x2, y2] = _tafl[x, y];
                _tafl[x, y] = Pawn.None;
                CheckCapture(x2, y2);
                return true;
            }
            if (y < y2)
            {
                for (int i = y; i < y2; i++)
                {
                    if (!CheckDown(x, i)) return false;
                }
                _tafl[x2, y2] = _tafl[x, y];
                _tafl[x, y] = Pawn.None;
                CheckCapture(x2, y2);
                return true;
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
        /// <exception cref="System.NotImplementedException"></exception>
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

    }
}