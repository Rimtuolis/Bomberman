using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public class Bomb : Abstractbomb
    {
        public DateTime BombPlaced { get; }

       
        public Bomb(IBombImplementor implementor, int timer, int radius, int startX, int length, int startY, string id, double power) : base(implementor,timer,radius,startX,length,startY,id, power) { }

        public Bomb(IBombImplementor implementor) : base(implementor) { }

        public Bomb() 
        {
            BombPlaced = DateTime.Now;
            this.bombImplementor = new DefaultBombImplementor();
        }

        public override void placeBomb(Player player)
        {
            bombImplementor.placeBomb(this, player);
        }
    }
}
