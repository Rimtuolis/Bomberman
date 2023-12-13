using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
	public class Save
	{
		public OfflineArena offlineArena;
		private Arena arena;
		private List<TemplateBot> bots;

		public Save(OfflineArena offlineArena, Arena arena, List<TemplateBot> bots)
		{
			this.offlineArena = offlineArena;

			string tempArena = JsonConvert.SerializeObject(arena, new JsonSerializerSettings()
			{
				TypeNameHandling = TypeNameHandling.Auto
			});

			this.arena = JsonConvert.DeserializeObject<Arena>(tempArena, new JsonSerializerSettings()
			{
				TypeNameHandling = TypeNameHandling.Auto
			});

			this.bots = new List<TemplateBot>(bots); // 
		}

		public void Restore()
		{
			offlineArena.arena = arena;
			offlineArena.bots = bots;
		}
	}
}
