﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    internal class SimpleExplosionStrategy : IBombExplosionStrategy
    {
        public int[,] Explode()
        {
			int[,] temp = { { 0, 0, 1, 0, 0 }, { 0, 0, 1, 0, 0 }, { 1, 1, 1, 1, 1 }, { 0, 0, 1, 0, 0 }, { 0, 0, 1, 0, 0 } };

			return temp;
		}
    }
}
