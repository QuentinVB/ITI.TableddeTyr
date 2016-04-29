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

        }
        //properties
        
        public bool IsAtkPlaying //get the current team who play turn, true if it is the the attacker
        {
            get
            {
                throw new NotImplementedException();
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
            throw new NotImplementedException();
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
