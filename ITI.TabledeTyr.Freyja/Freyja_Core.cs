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
        internal Sensor _Sensor;
        internal Effector _Effector;
        //Core
        internal Simulate _Simulate;
        internal Analyze _Analyze;
        internal Decision _Decision;
        //data
        internal Game originGame;

        public Freyja_Core(Game game,bool isFreyjaAtk)
        {
            originGame = game;
            //Input
            _Sensor = new Sensor(this, isFreyjaAtk);          
            //Core
            _Simulate = new Simulate(this);
            _Analyze = new Analyze(this);
            _Decision = new Decision(this);
            //output
            _Effector = new Effector(this);

        }

    }
}
