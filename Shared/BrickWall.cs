using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public class BrickWall : Entity
    {
<<<<<<< HEAD
        public override int StartX { get; set; }
        public override int Length { get; set; }
        public override int StartY { get; set; }

        public BrickWall(int startX, int startY, int length)
        {
            this.StartX = startX;
            this.StartY = startY;
            this.Length = length;
=======
        public int StartX { get; set; }
        public int Length { get; set; }
        public int StartY { get; set; }

        public BrickWall(int startX, int length, int startY)
        {
            StartX = startX;
            Length = length;
            StartY = startY;
>>>>>>> 53a3d11550fdaf84bbf507760be143e7c56871d7
        }
    }
}
