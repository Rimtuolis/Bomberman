using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public interface Glass
    {
        public void Build();
        public int GetLength();
        public int GetStartX();
        public int GetStartY();
    }
}
