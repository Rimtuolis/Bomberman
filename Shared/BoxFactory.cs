using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public class BoxFactory : IStructureFactory
    {
        public IStructure CreateStructure(int startX, int startY, int length,int powerUp)
        {
            return new Box { StartX = startX, Length = length, StartY = startY, PowerUp = powerUp };
        }
    }
}
