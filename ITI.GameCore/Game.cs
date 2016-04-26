using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.GameCore
{
    public class Game
    {
        /*
        0 : 00 : empty
        1 : 01 : atk : attacker
        2 : 10 : def : defensor
        3 : 11 : king
        */        
        //attributes

        //byte _tafl ; //NEED TEST AND DOC !

        byte _width; //the size of the tafl
        byte _height; //the size of the tafl
        bool _atkTurn; //true if is the turn of attacker, else the turn of defendor
        byte _defensorAlive; //amount of defensor alive
        byte _attackerAlive;//amount of attacker alive

        //collection
        byte[,] tafl;
         
        //constructor        
        /// <summary>
        /// Initializes a new instance of the <see cref="Game"/> class.
        /// </summary>
        public Game(byte width, byte height)
        {
            _width = width;
            _height = height;
            byte[,] tafl = new byte[width,height];
            //create default tafl
        }
        //properties
        public byte GetWidth //get width of the tafl
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public byte GetHeight//get height of the tafl
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public byte[,] GetMap //return the int map for the UI, the capture conditions...
        {
            get //later here stand the mighty "byte avec tableau"
            {
                throw new NotImplementedException();
            }
        }
        public bool IsAtkPlaying //get the current team who play turn
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        //Methods - internal
        internal bool SetCase(byte x, byte y,int newValue)//set the state of the case
        {
            throw new NotImplementedException();
        }

        public bool CheckCapture(byte[,] thisPiece)//check the capture around this piece, then call for removing if needed
        {
            throw new NotImplementedException();
        }

        //public - public
        public bool TryMove(byte[,] thisPiece, byte x, byte y)//try of a specified piece is allowed to move to the designated position
        {
            throw new NotImplementedException();
        }
        public bool MovePiece(byte[,] thisPiece, byte x, byte y)//move a selected piece to a specified position
        {
            throw new NotImplementedException();
        }
        public byte CheckVictoryCondition(byte[,])//check if victory condition for the attacker are met (aka circling the king and his defensor) and  victory condition for defender are met (aka the king is in a forteress)
        {
            throw new NotImplementedException();
        }
        /*return : 
        0 : nobody
        1 : atk
        2 : def         
        */
        public byte UpdateTurn()//called by a player during his turn, moving a piece, check capture condition, victory condition and switch to next player
        {
            throw new NotImplementedException();
        }
        /*return : 
        0 : nobody
        1 : atk
        2 : def         
        */
    }
}
