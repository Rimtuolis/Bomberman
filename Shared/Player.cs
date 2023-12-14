using System;
using System.Drawing;

namespace BomberGopnik.Shared
{
	public class Player 
    {
		public string? ConnectionId { get; set; }

		public int Top { get; set; }
		public int Left { get; set; }
		public int Points { get; set; }
		public bool IsPaused { get; set; }
		public string Name { get; set; }
		public bool ExtraSpeed { get; set; }
		public bool Dead { get; set; }
		public PlayerInfo PlayerInfo { get; set; }


		IBombExplosionStrategy BombExplosionStrategy { get; set; }

		private CollisionMediator mediator;

		public void setBombExplosionStrategy(IBombExplosionStrategy strategy) {
			BombExplosionStrategy = strategy;
		}

		public List<int[]> executeStrategy() {
			return BombExplosionStrategy.Explode();
		}
        public void SetMediator(CollisionMediator mediator)
        {
            this.mediator = mediator;
        }

        public void CollideWithEnemy(TemplateBot enemy)
        {
            mediator.PlayerEnemyCollision(this, enemy);
        }

        public Player(string connectionId, int top, int left, int points, string name, PlayerInfo info)
		{
			ConnectionId = connectionId;
			Top = top;
			Left = left;
			Points = points;
			BombExplosionStrategy = new SimpleExplosionStrategy();
			Name = name;
            ExtraSpeed = false;
			Dead = false;
			PlayerInfo = info;
		}
        public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Player p = (Player)obj;
                return p.ConnectionId == this.ConnectionId;
            }
        }
    }

}
