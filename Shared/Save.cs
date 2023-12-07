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
		private List<Bot> bots;

		public Save(OfflineArena offlineArena, Arena arena, List<Bot> bots)
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

			this.bots = new List<Bot>(bots); // 
		}

		public void Restore()
		{
			offlineArena.arena = arena;
			offlineArena.bots = bots;
		}
	}
}
