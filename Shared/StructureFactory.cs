using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public class StructureFactory  
    {

        public IStructure CreateStructure(string type, int startX, int startY, int length, int powerUp = 0, int radius = 0, int playerId = 0, int timer = 0)
        {
            switch (type.ToLower())
            {
                case "brickwall":
                    return new BrickWall { StartX = startX, Length = length, StartY = startY };
                //case "bomb":
                //    return new Bomb { StartX = startX, Length = length, StartY = startY, Radius = radius, PlayerId = playerId, Timer = timer };
                case "fire":
                    return new Fire { StartX = startX, Length = length, StartY = startY };
                default:
                    throw new ArgumentException("Invalid structure type");
            }
        }
    }
}
