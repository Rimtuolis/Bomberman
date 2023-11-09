using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public class UnBreakableDoor : Door
    {
        public int StartX { get; set; }
        public int Length { get; set; }
        public int StartY { get; set; }
        public int PowerUp { get; set; }

        public void Build()
        {
            Console.WriteLine("Door was built");
        }

        public int GetLength()
        {
            return Length;
        }

        public int GetStartX()
        {
            return StartX;
        }

        public int GetStartY()
        {
            return StartY;
        }
    }
}
