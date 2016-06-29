using ITI.GameCore;
using System;
using System.Collections.Generic;

namespace ITI.TabledeTyr.Freyja
{
    class Effector
    {
        Freyja_Core _ctx;
        /// <summary>
        /// Initializes a new instance of the <see cref="Effector"/> class.
        /// Return the result of the IA's work : 
        /// a Move struct containing the coordinate of the pawn moved and the destination.
        /// </summary>
        /// <param name="ctx">The context, Freyja's Core.</param>
        internal Effector(Freyja_Core ctx)
        {
            _ctx = ctx;
        }
        internal Move UpdateEffector
        {
            get {
                Move control = _ctx.Decision.Result;
                Helper.CheckRange(_ctx.Sensor.ActiveTafl.Width, _ctx.Sensor.ActiveTafl.Height, control.sourceX, control.sourceY); 
                Helper.CheckRange(_ctx.Sensor.ActiveTafl.Width, _ctx.Sensor.ActiveTafl.Height, control.sourceY, control.destinationY);
                return control;
            }
        }
    }
}
