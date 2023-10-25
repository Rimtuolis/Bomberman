using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public interface IStructureFactory
    {
        IStructure CreateStructure(int startX, int startY, int length, int powerUp);
    }
}
