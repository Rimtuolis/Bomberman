using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public class ExploadingStateBomb : BombState
    {
        public override void Handle(Bomb bomb)
        {
            bomb.SetState(new DetonatedStateBomb());
            Console.WriteLine("Exploading bomberino");
        }
    }
}
