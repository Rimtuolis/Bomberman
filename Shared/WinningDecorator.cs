using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public class WinningDecorator : IGameOverScreenDecorator
    {
        public string DecorateMessage(string message)
        {
            return $"{message} You won";
        }
    }
}
