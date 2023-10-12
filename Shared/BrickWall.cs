using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public class BrickWall : Entity
    {
        public override int StartX { get; set; }
        public override int Length { get; set; }
        public override int StartY { get; set; }

        public BrickWall(int startX, int startY, int length)
        {
            this.StartX = startX;
            this.StartY = startY;
            this.Length = length;
        }
    }
}
