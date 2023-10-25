using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public class AddSpecialBombCommand : ICommand
    {
        private Receiver receiver;

        public AddSpecialBombCommand(Receiver receiver)
        {
            this.receiver = receiver;
        }

        public void Execute(SpecialBomb bomb)
        {
            receiver.addBomb(bomb);
        }
        public void Undo(SpecialBomb bomb)
        {
            receiver.removeBomb(bomb);
        }

    }
}
