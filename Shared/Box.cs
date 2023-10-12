using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public class Box : Entity
    {
        public override int StartX { get; set; }
        public override int Length { get; set; }
        public override int StartY { get; set; }
        public override int PowerUP { get; set; }

        public Box(int startX, int startY, int length)
        {
            this.StartX = startX;
            this.StartY = startY;
            this.Length = length;
            this.PowerUP = 0;

        }
    }
}
