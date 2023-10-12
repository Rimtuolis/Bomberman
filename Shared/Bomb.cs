using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public class Bomb : Entity
    {
        public override int StartX { get; set; }
        public override int Length { get; set; }
        public override int StartY { get; set; }
        public override int Timer { get; set; }
        public override int Radius { get; set; }
        public override int PlayerId { get; set; }

        public Bomb(int startX, int length, int startY, int timer, int radius, int playerId)
        {
            this.StartX = startX;
            this.Length = length;
            this.StartY = startY;   
            this.Timer = timer;
            this.Radius = radius;
            this.PlayerId = playerId;
        }
        public Bomb() { }
    }
}
