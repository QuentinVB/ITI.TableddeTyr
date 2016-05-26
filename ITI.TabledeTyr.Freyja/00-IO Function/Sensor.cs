using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.TabledeTyr.Freyja
{
    class Sensor : ISensor
    {
        Freyja_Core _ctx;

        public Sensor(Freyja_Core ctx)
        {
            _ctx = ctx;
        }
    }
}
