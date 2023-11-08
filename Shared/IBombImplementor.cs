using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public interface IBombImplementor
    {
        void placeBomb(Abstractbomb bomb, Player player);
    }
}
