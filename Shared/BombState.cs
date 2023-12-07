using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public abstract class BombState
    {
        public abstract void Handle(Bomb bomb);
    }
}
