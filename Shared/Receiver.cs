using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public class Receiver
    {
        public void addBomb(SpecialBomb bomb)
        {
            Detonator.AddBomb(bomb);
        }
        public void removeBomb(SpecialBomb bomb)
        {
            Detonator.Remove(bomb);
        }
    }
}
