using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public class Bomb
    {
        public int Timer { get; set; }
        public int Radius { get; set; }
        public int StartX { get; set; }
        public int Length { get; set; }
        public int StartY { get; set; }
    }
}
