using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public class DetonatedStateBomb : BombState
    {
        public override void Handle(Bomb bomb)
        {
            Console.WriteLine("Boom");
        }
    }
}
