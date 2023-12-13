using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
	public class OfflineArena
	{
		public Arena arena { get; set; }
		public List<TemplateBot> bots { get; set; }

		public OfflineArena(Arena arena, List<TemplateBot> bots)
		{
			this.arena = arena;
			this.bots = bots;
		}
		public Save CreateSaveFile() {
			return new Save(this, arena, bots);
		}
	}
}
