using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public class SpecialBomb: Abstractbomb
    {
        public SpecialBomb(IBombImplementor implementor, int timer, int radius, int startX, int length, int startY, string id, double power) : base(implementor, timer, radius, startX, length, startY, id, power) { }

        public SpecialBomb(IBombImplementor implementor) : base(implementor) { }
        public SpecialBomb() 
        {
            this.bombImplementor = new SpecialBombImplementor();
        }

        public override void placeBomb(Player player)
        {
            bombImplementor.placeBomb(this, player);
        }
    }
}
