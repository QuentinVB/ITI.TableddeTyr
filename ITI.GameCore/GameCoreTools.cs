using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.GameCore
{
    //struct for can move to answer
    public struct PossibleMove
    {
        public readonly int X;
        public readonly int Y;
        public readonly List<StudiedPawn> FreeSquares;
        public readonly Pawn Value;
        /// <summary>
        /// Initializes a new instance of the <see cref="PossibleMove" /> struct.
        /// </summary>
        /// <param name="x">The x position of the analyzed pawn.</param>
        /// <param name="y">The y position of the analyzed pawn.</param>
        /// <param name="north">The north maximum move for this pawn.</param>
        /// <param name="south">The south maximum move for this pawn.</param>
        /// <param name="east">The east maximum move for this pawn.</param>
        /// <param name="west">The west maximum move for this pawn.</param>
        public PossibleMove(int x, int y, List<StudiedPawn> freeSquares, Pawn value)
        {
            X = x;
            Y = y;
            FreeSquares = freeSquares;
            Value = value;
        }
        public bool IsFree()
        {
            if (FreeSquares.Count == 0) return false;
            return true;
        }
        public int Up()
        {
            int up = 0;
            foreach (StudiedPawn value in FreeSquares)
            {
                if (value.X == X && value.Y < Y) up++;
            }
            return up;
        }
        public int Down()
        {
            int down = 0;
            foreach (StudiedPawn value in FreeSquares)
            {
                if (value.X == X && value.Y > Y) down++;
            }
            return down;
        }
        public int Left()
        {
            int left = 0;
            foreach (StudiedPawn value in FreeSquares)
            {
                if (value.X < X && value.Y == Y) left++;
            }
            return left;
        }
        public int Right()
        {
            int right = 0;
            foreach (StudiedPawn value in FreeSquares)
            {
                if (value.X > X && value.Y == Y) right++;
            }
            return right;
        }
    }
    public struct StudiedPawn
    {
        public readonly int X;
        public readonly int Y;

        public StudiedPawn(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}