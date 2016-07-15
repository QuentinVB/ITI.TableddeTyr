﻿using ITI.GameCore;
using System;
using System.Collections.Generic;

namespace ITI.TabledeTyr.Freyja
{
    /// <summary>
    /// Return the result of the IA's work : 
    /// a Move struct containing the coordinate of the pawn moved and the destination.
    /// </summary>
    class Effector
    {
        Freyja_Core _ctx;
        /// <summary>
        /// Initializes a new instance of the <see cref="Effector"/> class.
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

                if (control.destinationX == 0
                    && control.destinationY == 0
                    && control.sourceX == 0
                    && control.sourceY == 0) throw new ArgumentException("There is no move stored, try updating freyja BEFORE asking any movement");
                Helper.CheckRange(_ctx.Sensor.ActiveTafl.Width, _ctx.Sensor.ActiveTafl.Height, control.sourceX, control.sourceY); 
                Helper.CheckRange(_ctx.Sensor.ActiveTafl.Width, _ctx.Sensor.ActiveTafl.Height, control.sourceY, control.destinationY);
                return control;
            }
        }
    }
}
