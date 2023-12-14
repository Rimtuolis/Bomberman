using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{

	public class PlayerManager
	{
		private static readonly Dictionary<String, Player> players = new Dictionary<string, Player>();
		private static readonly Dictionary<String, PlayerInfo> playerInfo = new Dictionary<string, PlayerInfo>();
		private static readonly object locker = new object();
        private static List<string> lobbyNames = new List<string>();
      
		public static Dictionary<String, Player> Players => players;

		public static void AddPlayer(Player player)
		{
			lock (locker)
			{
				players[player.ConnectionId] = player;
			}
		}
        public static void AddNames(string name)
        {
            lock(locker)
            {
                lobbyNames.Add(name);
            }
        }
		public static PlayerInfo getPlayerInfo(string color, string skin)
		{
			PlayerInfo? result = playerInfo.GetValueOrDefault(color);
			if (result == null)
			{
				result = new PlayerInfo(color, skin);
				playerInfo.Add(color, result);
			}
			return result;
		}

		public static void EditPlayer(Player player)
		{
			players[player.ConnectionId] = player;
		}

		public static void RemovePlayer(Player player)
		{
			players.Remove(player.ConnectionId);
		}
		private static PlayerManager _instance;
        
        public static PlayerManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new PlayerManager();
                }
                return _instance;
            }
        }

        public void IncrementScore(Player player, int points)
        {
            if (player != null)
            {
                
                players[player.ConnectionId].Points += points;
            }
            else
            {
                Console.WriteLine("Player not found.");
            }
        }

        public int GetScore(Player player)
        {
            if (player != null)
            {
                return players[player.ConnectionId].Points;

            }
            else
            {
                Console.WriteLine("Player not found.");
                return 0;
            }
        }

        public List<Player> GetAllPlayers()
        {
            return players.Values.ToList();
        }
        public List<string> GetNames()
        {
            return lobbyNames;
        }
    }
}
