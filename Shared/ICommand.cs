using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public interface ICommand
    {
        void Execute(SpecialBomb bomb);
        void Undo(SpecialBomb bomb);
    }
}
