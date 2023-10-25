using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public class UndoAddSpecialBombCommand : ICommand
    {
        private Receiver receiver;

        public UndoAddSpecialBombCommand(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public void Execute(SpecialBomb bomb)
        {
            receiver.removeBomb(bomb);
        }
        public void Undo(SpecialBomb bomb)
        {
            receiver.addBomb(bomb);
        }
    }
}
