using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public class GameLevel
    {
         public List<IStructure> Bricks { get; set; }
         public List<IStructure> Boxes { get; set; }
    }
}
