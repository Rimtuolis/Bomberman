using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public class ArenaIterator : IIterator<IStructure>
    {
        private readonly Arena arena;
        private int currentX;
        private int currentY;

        public ArenaIterator(Arena arena)
        {
            this.arena = arena;
            Reset();
        }

        public IStructure Next()
        {
            IStructure structure = arena.grid[currentX, currentY];
            MoveToNextPosition();
            return structure;
        }

        public bool HasNext()
        {
            return currentX < 10 && currentY < 10;
        }

        private void MoveToNextPosition()
        {
            currentX++;
            if (currentX >= 10)
            {
                currentX = 0;
                currentY++;
            }
        }

        public void Reset()
        {
            currentX = 0;
            currentY = 0;
        }
    }
}
