using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public class Arena : IAggregate, IStructure
    {
        public IStructure[,] grid = new IStructure[10, 10];

        public List<Player> players = new List<Player>();
        public List<Bomb> bombs = new List<Bomb>();
        //public Dictionary<int,List<int>> powerups = new Dictionary<int, List<int>>();
        public int[,] powerups = new int[10, 10];
        List<IStructure> structures = new List<IStructure>();

        public Arena(GameLevel level)
        {
            structures = level.Boxes.Concat(level.Bricks).ToList();

            foreach (var structure in structures)
            {
                int i = structure.GetStartX() / 10;
                int j = structure.GetStartY() / 10;
                grid[i, j] = structure;
            }
        }
        public Arena()
        {
        }
        public IIterator<IStructure> CreateIterator()
        {
            return new ArenaIterator(this);
        }
        public void AddStructure(IStructure structure)
        {
            structures.Add(structure);
        }

        public void RemoveStructure(IStructure structure)
        {
            structures.Remove(structure);
        }
        public void Build()
        {
            Console.WriteLine("Building the Arena");
        }

        public int GetStartX()
        {
            return 0;
        }

        public int GetStartY()
        {
            return 0;
        }

        public int GetLength()
        {
            return structures.Count;
        }

    }
}
