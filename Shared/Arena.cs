using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public class Arena
    {
		public IStructure[,] grid = new IStructure[10,10];

        public List<Player> players = new List<Player>();
        public List<Bomb> bombs = new List<Bomb>();

        public Arena(GameLevel level)
        {
            List<IStructure> structures = level.Boxes.Concat(level.Bricks).ToList();

            foreach (var structure in structures) {
                int i = structure.GetStartX() / 10;
				int j = structure.GetStartY() / 10;
				grid[i,j] = structure;
            }
        }
        public Arena()
        {
        }
    }
}
