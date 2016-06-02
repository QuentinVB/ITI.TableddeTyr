using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.TabledeTyr.Freyja
{
    /// <summary>
    /// A move is a compacted structure containing the moved pawn's coordinate and the destination coordinate, making easier to manipulate
    /// </summary>
    public struct Move
    {
        public readonly int sourceX;
        public readonly int sourceY;
        public readonly int destinationX;
        public readonly int destinationY;
        public Move(int x, int y, int x2, int y2)
        {
            sourceX = x;            
            sourceY = y;
            destinationX = x2;
            destinationY = y2;
        }
    }
    static internal class Helper
    {
        static internal void CheckRange(int width, int height, int x, int y)
        {
            if (x < 0 || x > width) throw new ArgumentOutOfRangeException("Can't aim out of the tafl", nameof(x));
            if (y < 0 || y > height) throw new ArgumentOutOfRangeException("Can't aim out of the tafl", nameof(y));
        }
    }
}
