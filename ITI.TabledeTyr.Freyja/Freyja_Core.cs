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
        Sensor _Sensor;
        Effector _Effector;
        //Core
        Simulate _Simulate;
        Analyze _Analyze;
        Decision _Decision;
        //data
        Game _originGame;

        public Freyja_Core(Game game,bool isFreyjaAtk)
        {
            _originGame = game;
            //Input
            _Sensor = new Sensor(this, isFreyjaAtk);          
            //Core
            _Simulate = new Simulate(this);
            _Analyze = new Analyze(this);
            _Decision = new Decision(this);
            //output
            _Effector = new Effector(this);

        }
        //IO
        internal Sensor Sensor { get { return _Sensor; } set { value = _Sensor; } }
        internal Effector Effector { get { return _Effector; } set { value = _Effector; } }
        //Core
        internal Simulate Simulate { get { return _Simulate; } set { value = _Simulate; } }
        internal Analyze Analyze { get { return _Analyze; } set { value = _Analyze; } }
        internal Decision Decision { get { return _Decision; } set { value = _Decision; } }
        //data
        internal Game originGame { get { return _originGame; } set { value = _originGame; } }

        public void UpdateFreyja()
        {
            _Simulate.UpdateSimulation();
        }
        public void UpdateSensor(Game newGameTurn)
        {
            Sensor.UpdateSensor(newGameTurn);
        }
        public Move UpdateEffector()
        {
            return Effector.UpdateEffector;
        }

    }
}
