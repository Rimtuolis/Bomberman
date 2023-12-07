using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public class IdleStateBomb : BombState
    {
        public override void Handle(Bomb bomb)
        {
            bomb.SetState(new ExploadingStateBomb());
            bomb.Exploded = true;
            Console.WriteLine("Placed");
        }
    }
}
