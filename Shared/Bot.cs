using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
	public interface IBot
	{
		public void PerformAction(GameLevel level, Player player);
		public IBot Clone();
	}
}
