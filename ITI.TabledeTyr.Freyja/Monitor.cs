using ITI.GameCore;
using System;
using System.Collections.Generic;

namespace ITI.TabledeTyr.Freyja
{
    /// <summary>
    /// Expose a LOT of data from the inner system of Freyja 
    /// Allow user and dev to change internal value of freyja
    /// </summary>
    public class Monitor
    {
        private Freyja_Core ctx;
        readonly int _maxSimTurn = 100;
        readonly int _maxIncubatedNode = 180;
        readonly SortBy _equalResultMethod = SortBy.Turn;

        /// <summary>
        /// Initializes a new instance of the <see cref="Monitor"/> class.       
        /// </summary>
        /// <param name="freyja_Core">The freyja_ core.</param>
        public Monitor(Freyja_Core freyja_Core)
        {
            ctx = freyja_Core;
        }
        public int maxIncubatedNode { get { return _maxIncubatedNode; } }
        public int MaxSim { get { return _maxSimTurn; } }
        public SortBy EqualResultMethod { get { return _equalResultMethod; } }

        //exposure of : SENSOR
        public Game Sensor_ActiveGame { get { return ctx.Sensor.ActiveGame; } }
        public bool Sensor_IsAtkPlaying { get { return ctx.Sensor.IsActiveAtkPlaying; } }
        public bool Sensor_IsFreyjaAtk { get { return ctx.Sensor.IsFreyjaAtk; } }
        public IReadOnlyTafl Sensor_ActiveTafl { get { return ctx.Sensor.ActiveTafl; } }

        //exposure of : EFFECTOR
        public Move Effector_MoveResult { get { return ctx.Effector.UpdateEffector; } }

        //exposure of : DECISON
        public Move Decision { get { return ctx.Decision.Result; } }

        //exposure fof : SIMULATE


    }
}
