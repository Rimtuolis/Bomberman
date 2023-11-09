using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public interface IMovement
    {
		int Dx { get; }
		int Dy { get; }
	}
}
