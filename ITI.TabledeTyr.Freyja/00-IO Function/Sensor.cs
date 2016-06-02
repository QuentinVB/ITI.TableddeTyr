using ITI.GameCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.TabledeTyr.Freyja
{
    class Sensor
    {
        Freyja_Core _ctx;
        Game _activeGame;
        bool _isAtkplaying;
        readonly bool _isFreyjaAtk;
        IReadOnlyTafl _currentTafl;

        /// <summary>
        /// Initializes a new instance of the <see cref="Sensor"/> class. 
        /// The Sensor contain methods an prop exposing information useful for each part of the IA
        /// </summary>
        /// <param name="ctx">The context, freyja's core.</param>
        /// <param name="isFreyjaAtk">if set to <c>true</c> freyja on the atk side.</param>
        public Sensor(Freyja_Core ctx, bool isFreyjaAtk)
        {
            _ctx = ctx;
            _activeGame = _ctx.originGame;
            _isFreyjaAtk = isFreyjaAtk;
            _isAtkplaying = _activeGame.IsAtkPlaying;
            _currentTafl = _activeGame.Tafl;

        }
        //properties
        internal Game ActiveGame { get { return _activeGame; } set { _activeGame = value; } }
        internal bool IsActiveAtkPlaying { get { return _isAtkplaying; } set { _isAtkplaying = value; } }
        internal bool IsFreyjaAtk{ get { return _isFreyjaAtk; }  }
        internal IReadOnlyTafl ActiveTafl { get { return _currentTafl; } set { _currentTafl = value; } }

        internal TaflCompressed ConvertTaflBasicIntoCompressed (TaflBasic source)
        {
            return new TaflCompressed(source);
        }
        internal TaflBasic ConvertTaflCompressedIntoBasic(TaflCompressed source)
        {
            return new TaflBasic(source);
        }
        /// <summary>
        /// Updates the sensor by sending a new game.
        /// Then updating the Active values
        /// </summary>
        /// <param name="newGameTurn">The new game turn.</param>
        public void UpdateSensor(Game newGameTurn)
        {
            ActiveGame = newGameTurn;
            IsActiveAtkPlaying = newGameTurn.IsAtkPlaying;
            ActiveTafl = newGameTurn.Tafl;
        }

    }
}
