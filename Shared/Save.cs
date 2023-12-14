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
			this.arena = DeepCopyArena(arena);
			this.bots = DeepCopyBots(bots);
		}

		public void Restore()
		{
			offlineArena.arena = DeepCopyArena(arena);
			offlineArena.bots = DeepCopyBots(bots);
		}


		private Arena DeepCopyArena(Arena arena) {
			string tempArena = JsonConvert.SerializeObject(arena, new JsonSerializerSettings()
			{
				TypeNameHandling = TypeNameHandling.Auto
			});

			return JsonConvert.DeserializeObject<Arena>(tempArena, new JsonSerializerSettings()
			{
				TypeNameHandling = TypeNameHandling.Auto
			});
		}

		private List<TemplateBot> DeepCopyBots(List<TemplateBot> bots)
		{
			string tempBots = JsonConvert.SerializeObject(bots, new JsonSerializerSettings()
			{
				TypeNameHandling = TypeNameHandling.Auto
			});

			return JsonConvert.DeserializeObject<List<TemplateBot>>(tempBots, new JsonSerializerSettings()
			{
				TypeNameHandling = TypeNameHandling.Auto
			});
		}
	}
}
