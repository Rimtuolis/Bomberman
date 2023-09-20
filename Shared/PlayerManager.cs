using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
	public class PlayerManager
	{
		private static readonly List<Player> players = new List<Player>();
		private static readonly object locker = new object();

		public static List<Player> Players => players;

		public static void AddPlayer(Player player)
		{
			lock (locker)
			{
				players.Add(player);
			}
		}

		public static void EditPlayer(Player player)
		{

			int playerIndex = players.FindIndex(e => e.ConnectionId == player.ConnectionId);

			if (playerIndex != -1) {
				players[playerIndex] = player;
			}
		}
		// Add methods for removing players, updating player data, etc.
	}
}
