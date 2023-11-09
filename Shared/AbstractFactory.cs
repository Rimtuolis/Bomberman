using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public interface  AbstractFactory
    {
        Glass CreateGlass(int startX, int startY, int length);
        Door CreateDoor(int startX, int startY, int length);
    }
}
