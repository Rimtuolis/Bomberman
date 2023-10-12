using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public abstract class Entity
    {
        public abstract int StartX { get; set; }
        public abstract int Length { get; set; }
        public abstract int StartY { get; set; }

        public virtual int PowerUP { get; set; }
        public virtual int Timer { get; set; }
        public virtual int Radius { get; set;}
        public virtual int PlayerId { get; set;}
    }
}
