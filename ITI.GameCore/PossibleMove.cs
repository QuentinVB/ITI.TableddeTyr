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
        public readonly int X;
        public readonly int Y;
        public readonly int Up;
        public readonly int Down;
        public readonly int Left;
        public readonly int Right;
        /// <summary>
        /// Initializes a new instance of the <see cref="PossibleMove" /> struct.
        /// </summary>
        /// <param name="x">The x position of the analyzed pawn.</param>
        /// <param name="y">The y position of the analyzed pawn.</param>
        /// <param name="north">The north maximum move for this pawn.</param>
        /// <param name="south">The south maximum move for this pawn.</param>
        /// <param name="east">The east maximum move for this pawn.</param>
        /// <param name="west">The west maximum move for this pawn.</param>
        public PossibleMove(int x, int y, int up, int down, int left, int right )
        {
            X = x;
            Y = y;
            Up = up;
            Down = down;
            Left = left;
            Right = right;
        }
    }
}
