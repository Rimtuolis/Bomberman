using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public class Scoreboard
    {
     /*   private static Scoreboard _instance;
        private List<Player> players = new List<Player>();

        private Scoreboard() { }

        public static Scoreboard Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Scoreboard();
                }
                return _instance;
            }
        }

        public void AddPlayer(Player player)
        {
            if (!players.Exists(player => player.ConnectionId != player.ConnectionId))
            {
                players.Add(player);
            }
            else
            {
                Console.WriteLine("Cannot add player");
            }
        }

        public void IncrementScore(string id, int points)
        {
            Player player = players.Find(p => p.ConnectionId == id);
            if (player != null)
            {
                player.Points += points;
            }
            else
            {
                Console.WriteLine("Player not found.");
            }
        }

        public int GetScore(string id)
        {
            Player player = players.Find(p => p.ConnectionId == id);
            if (player != null)
            {
                return player.Points;
            }
            else
            {
                Console.WriteLine("Player not found.");
                return 0;
            }
        }

        public List<Player> GetAllPlayers()
        {
            return players;
        }
*/

    }
}
