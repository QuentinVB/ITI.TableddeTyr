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
    }
}
