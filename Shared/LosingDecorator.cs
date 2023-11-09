using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public class LosingDecorator : IGameOverScreenDecorator
    {
        public string DecorateMessage(string message)
        {
            return $"{message} Better luck next time.";
        }
    }
}
