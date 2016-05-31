using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.TabledeTyr.Freyja
{
    class Decision
    {
        private Freyja_Core freyja_Core;

        public Decision(Freyja_Core freyja_Core)
        {
            this.freyja_Core = freyja_Core;
        }

        internal Move Result()
        {
            throw new NotImplementedException();
        }
    }
}
