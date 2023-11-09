using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public class PlayerObserver : IGameObserver
    {
        private Player player;
        public string ID { get; set; }

        public PlayerObserver(Player player)
        {
            this.player = player;
            this.ID = player.ConnectionId;
        }

        public void UpdateGameStatus(bool isPaused)
        {
            player.IsPaused = isPaused;
        }
    }
}
