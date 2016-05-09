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
        bool _atkTurn; //true if it is the turn of attacker, else false if the turn of defensor

        //collection
        internal ITafl _tafl;

        //constructor(s)        
        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class.
        /// </summary>
        public Game()
        {
            _tafl = new TaflBasic (11, 11);
            //Set an empty tafl
            for(int x = 0; x < 11; x++ )
            {
                for(int y = 0; y < 11; y++)
                {
                    _tafl[x, y] = Pawn.None;
                }
            }
            //Set board for a standard 11*11 game [Hardcoded for IT1]
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
            
            //set the attacker as the first turn, allowing the game to start
            _atkTurn = true;
        }
        
        //properties

        public bool IsAtkPlaying //get the current team who play turn, true if it is the the attacker
        {
            get
            {
                return _atkTurn;
            }
        }

        //Methods - internal                
        /// <summary>
        /// check the capture around this piece then remove the piece(s).
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns>If the piece captured is the king, return true</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        internal bool CheckCapture(int x, int y)
        {
            //heavy code here ! Checking capture AND checking capture of the king (aka circling the king and his defensor)
            throw new NotImplementedException();
            
        }
        /// <summary>
        ///check if victory condition for the defensor are met (aka the king reach the forteress)
        ///or stop while recieving true from <see cref="CheckCapture"/> the king is alredy dead. Long live the king !
        /// </summary>
        /// <returns>true : someone as won, false : nobody won, next turn</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        internal bool CheckVictoryCondition()
        {
            if (_tafl[0, 0] == Pawn.King) return true;
            if (_tafl[0, 10] == Pawn.King) return true;
            if (_tafl[10, 0] == Pawn.King) return true;
            if (_tafl[10, 10] == Pawn.King) return true;
            if (!_tafl.HasKing) return true;
            return false;
        }
        //methodes - public        
        /// <summary>
        /// Send to the UI ou AI the piece(s) that are movable for this turn.
        /// </summary>
        /// <returns>an array of bool giving witch pieces are allowed to move for this turn</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool[,] CheckMove()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Send to the UI ou AI the possible position for this piece for this turn.
        /// </summary>
        /// <param name="x">The x position of the piece who tries to move.</param>
        /// <param name="y">The y position of the piece who tries to move.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool[,] TryMove(int x, int y)//
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Allows the designated pieces to move the piece to another coordinate, 
        /// call <see cref="CheckMove"/> by secure.
        /// </summary>
        /// <param name="x">The x position of the piece who move.</param>
        /// <param name="y">The y position of the piece who move.</param>
        /// <param name="x2">The x2 targeted position of the piece who move.</param>
        /// <param name="y2">The y2 targeted position of the piece who move.</param>
        /// <returns>true if the move is good. false something bad happend. FI: god(s) kill(s) a kitten</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool AllowMove(int x, int y, int x2, int y2)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Called by the player's UI after getting the confirmation of his move in <see cref="AllowMove"/>
        /// Call <see cref="CheckCapture"/>, <see cref="CheckVictoryCondition"/> and switch to next player.
        /// </summary>
        /// <returns>false if the game is over and break before flipping the turn. The current <paramref name="_atkTurn"/> is the winner.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool UpdateTurn()
        {
            /*
             * called after AllowMove by the UI
             * call CheckVictory
             * break if victory condition return true
             * then flip turn
             */
            throw new NotImplementedException();
        }

    }
}
