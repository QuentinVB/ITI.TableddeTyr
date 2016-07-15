using ITI.GameCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.TabledeTyr.Freyja
{
    static public class AnalyzeToolbox
    {
        static public bool IsFriendly(Pawn target,bool isAtkTeam)
        {
            if (target == Pawn.Attacker && isAtkTeam == true) return true;
            if ((target == Pawn.Defender || target == Pawn.King) && (isAtkTeam == true)) return false;
            if (target == Pawn.Attacker && isAtkTeam == false) return false;
            if ((target == Pawn.Defender || target == Pawn.King) && (isAtkTeam == false)) return true;
            return false;
        }
        static public int Distance(int x, int x2, int y,int y2)
        {
            return Convert.ToInt16(Math.Sqrt(Convert.ToDouble((x - x2) * (x - x2) + (y - y2) * (y - y2))));
        }
    }
}
