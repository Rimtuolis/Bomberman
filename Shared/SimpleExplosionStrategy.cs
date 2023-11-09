using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    internal class SimpleExplosionStrategy : IBombExplosionStrategy
    {
        public List<int[]> Explode()
        {
			List<int[]> temp = new List<int[]>{ new int[] { 0, 0, 1, 0, 0 }, new int[] { 0, 0, 1, 0, 0 }, new int[] { 1, 1, 1, 1, 1 }, new int[] { 0, 0, 1, 0, 0 }, new int[] { 0, 0, 1, 0, 0 } };

			return temp;
		}
    }
}
