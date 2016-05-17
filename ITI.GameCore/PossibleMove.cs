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
        public int _north;
        public int _south;
        public int _east;
        public int _west;
        /// <summary>
        /// Initializes a new instance of the <see cref="PossibleMove" /> struct.
        /// </summary>
        /// <param name="x">The x position of the analyzed pawn.</param>
        /// <param name="y">The y position of the analyzed pawn.</param>
        /// <param name="north">The north maximum move for this pawn.</param>
        /// <param name="south">The south maximum move for this pawn.</param>
        /// <param name="east">The east maximum move for this pawn.</param>
        /// <param name="west">The west maximum move for this pawn.</param>
        public PossibleMove(int x, int y, int north, int south, int east, int west)
        {
            _x = x;
            _y = y;
            _north = north;
            _south = south;
            _east = east;
            _west = west;
        }
        public int North => _north;
        public int South => _south;
        public int East => _east;
        public int West => _west;
        public int X => _x;
        public int Y => _y;
    }
}
