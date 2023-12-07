using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
	public abstract class Bot
	{
		public int Top { get; set; }
		public int Left { get; set; }
		public string Color { get; set; }

		public abstract void PerformAction(Arena arena, Player player);
		public abstract Bot Clone();
	}
}
