using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.GameCore
{
    //struct for can move answer
    public struct PossibleMove
    {
        public int _x;
        public int _y;
        public int _up;
        public int _down;
        public int _right;
        public int _left;
        /// <summary>
        /// Initializes a new instance of the <see cref="PossibleMove" /> struct.
        /// </summary>
        /// <param name="x">The x position of the analyzed pawn.</param>
        /// <param name="y">The y position of the analyzed pawn.</param>
        /// <param name="north">The north maximum move for this pawn.</param>
        /// <param name="south">The south maximum move for this pawn.</param>
        /// <param name="east">The east maximum move for this pawn.</param>
        /// <param name="west">The west maximum move for this pawn.</param>
        public PossibleMove(int x, int y, int up, int down, int right, int left)
        {
            _x = x;
            _y = y;
            _up = up;
            _down = down;
            _right = right;
            _left = left;
        }
        public int Up => _up;
        public int Down => _down;
        public int Right => _right;
        public int Left => _left;
        public int X => _x;
        public int Y => _y;
    }
}
