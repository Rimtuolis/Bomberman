using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public class BreakableFactory : AbstractFactory
    {
        public  Glass CreateGlass(int startX, int startY, int length)
        {
            return new BreakableGlass { StartX = startX, Length = length, StartY = startY};
        }

        public  Door CreateDoor(int startX, int startY, int length)
        {
            return new BreakableDoor { StartX = startX, Length = length, StartY = startY };
        }
    }
}
