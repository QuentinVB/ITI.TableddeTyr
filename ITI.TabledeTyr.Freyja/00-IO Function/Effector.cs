using ITI.GameCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.TabledeTyr.Freyja
{
    class Effector
    {
        Freyja_Core _ctx;
        public Effector(Freyja_Core ctx)
        {
            _ctx = ctx;
        }
        public Move UpdateEffector
        {
            get {
                Move control = _ctx._Decision.Result();
                Helper.CheckRange(_ctx._Sensor.currentTafl.Width, _ctx._Sensor.currentTafl.Height, control.sourceX, control.sourceY); 
                Helper.CheckRange(_ctx._Sensor.currentTafl.Width, _ctx._Sensor.currentTafl.Height, control.sourceY, control.destinationY);
                return control;
            }
        }
    }
}
