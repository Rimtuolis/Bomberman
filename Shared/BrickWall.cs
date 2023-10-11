using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public class BrickWall
    {
        public int StartX { get; set; }
        public int Length { get; set; }
        public int StartY { get; set; }

        public BrickWall(int startX, int length, int startY)
        {
            StartX = startX;
            Length = length;
            StartY = startY;
        }
    }
}
