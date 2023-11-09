using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public class SuperExplosionStrategy : IBombExplosionStrategy
    {
        public SuperExplosionStrategy()
        {
        }

        public int[,] Explode()
        {
			int[,] temp = { { 1, 1, 1, 1, 1 }, { 0, 0, 1, 0, 0 }, { 1, 1, 1, 1, 1 }, { 0, 0, 1, 0, 0 }, { 1, 1, 1, 1, 1 } };

			return temp;
        }
    }
}
