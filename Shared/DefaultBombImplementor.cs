using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public class DefaultBombImplementor : IBombImplementor
    {
        public void placeBomb(Abstractbomb bomb, Player player)
        {
            bomb.Power = 5;
            bomb.Timer = 10;
            bomb.StartX = (player.Left / 10) * 10;
            bomb.StartY = (player.Top / 10) * 10;
        }
    }
}
