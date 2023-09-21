using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
	public class PlayerManager
	{
		private static readonly Dictionary<String, Player> players = new Dictionary<string, Player>();
		private static readonly object locker = new object();

		public static Dictionary<String, Player> Players => players;

		public static void AddPlayer(Player player)
		{
			lock (locker)
			{
				players[player.ConnectionId] = player;
			}
		}

		public static void EditPlayer(Player player)
		{
			players[player.ConnectionId] = player;
		}
	}
}
