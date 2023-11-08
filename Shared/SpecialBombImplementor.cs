using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public class SpecialBombImplementor : IBombImplementor
    {
        public void placeBomb(Abstractbomb bomb, Player player)
        {
            bomb.Power = 10;
            bomb.Timer = 5;
            bomb.StartX = player.Left;
            bomb.StartY = player.Top;
        }
    }
}
