using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public interface IGameLevelBuilder
    {
        void BuildBricks();
        void BuildBoxes();
        GameLevel GetResult();
    }
}
