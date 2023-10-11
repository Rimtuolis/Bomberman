using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public class Bomb
    {
        public string? Id { get; set; } 
        public int Timer { get; set; }
        public int Radius { get; set; }
        public double StartX { get; set; }
        public int Length { get; set; }
        public double StartY { get; set; }
        public Bomb(int timer, int radius, int startX, int length, int startY, string id)
        {
            Id = id;
            Timer = timer;
            Radius = radius;
            StartX = startX;
            Length = length;    
            StartY = startY;

        }
        public Bomb() { }
    }
    
}
