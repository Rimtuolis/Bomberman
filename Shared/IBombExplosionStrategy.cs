using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public interface IBombExplosionStrategy
    {
        public List<int[]> Explode();
    }
}
