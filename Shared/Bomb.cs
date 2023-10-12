using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public class Bomb : Entity
    {
<<<<<<< HEAD
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
=======
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

>>>>>>> 53a3d11550fdaf84bbf507760be143e7c56871d7
        }
        public Bomb() { }
    }
    
}
