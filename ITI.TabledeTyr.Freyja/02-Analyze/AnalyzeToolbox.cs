using ITI.GameCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.TabledeTyr.Freyja
{
    class AnalyzeToolbox
    {
        static internal bool IsFriendly(Pawn target,bool isAtkTeam)
        {
            if (target == Pawn.Attacker && isAtkTeam == true) return true;
            if ((target == Pawn.Defender || target == Pawn.King) && (isAtkTeam == true)) return true;
            return false;
        }
    }
}
