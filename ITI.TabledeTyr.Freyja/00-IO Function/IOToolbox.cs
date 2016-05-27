using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.TabledeTyr.Freyja
{
    public struct Move
    {
        public readonly int x;
        public readonly int x2;
        public readonly int y;
        public readonly int y2;
        public Move(int x, int y, int x2, int y2)
        {
            this.x = x;
            this.y = y;
            this.x2 = x2;
            this.y2 = y2;
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
