using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public class EasyGameLevelBuilder : IGameLevelBuilder
    {
        private GameLevel level = new GameLevel();
        private StructureFactory factory = new StructureFactory();
        private IStructureFactory boxFactory = new BoxFactory();
        public void BuildBoxes()
        {
            level.Boxes = new List<IStructure>()
            {
            boxFactory.CreateStructure(90, 10, 30, 1),
            boxFactory.CreateStructure(60, 90, 30, 0)
            };
        }

        public void BuildBricks()
        {
            level.Bricks = new List<IStructure>
            {
                factory.CreateStructure("brickwall", 20, 20, 10),
                factory.CreateStructure("brickwall", 40, 40, 30),
                factory.CreateStructure("brickwall", 80, 80, 30)
            };
        }

        public GameLevel GetResult()
        {
            return level;
        }
    }
}
