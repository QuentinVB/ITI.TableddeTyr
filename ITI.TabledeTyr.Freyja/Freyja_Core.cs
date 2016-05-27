using ITI.GameCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.TabledeTyr.Freyja
{
    public class Freyja_Core
    {
        //IO
        Sensor Sensor;
        Effector Effector;
        //Core
        Simulate Simulate;
        Analyze Analyze;
        Decision Decison;

        public Freyja_Core(Game game,bool isFreyjaAtk)
        {
            //IO
            Sensor = new Sensor(this,game, isFreyjaAtk);
            Effector = new Effector(this);
            //Core
            Simulate = new Simulate(this);
            Analyze = new Analyze(this);
            Decison = new Decision(this);
            
        }

    }
}
