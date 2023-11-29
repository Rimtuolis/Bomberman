﻿using System.Drawing;

namespace BomberGopnik.Shared
{
	public class Player 
    {
		public string? ConnectionId { get; set; }
		public string? Color { get; set; }
		public int Top { get; set; }
		public int Left { get; set; }
		public int Points { get; set; }
		public bool IsPaused { get; set; }
		public string Name { get; set; }
		public bool ExtraSpeed { get; set; }
		
		IBombExplosionStrategy BombExplosionStrategy { get; set; }

		public void setBombExplosionStrategy(IBombExplosionStrategy strategy) {
			BombExplosionStrategy = strategy;
		}

		public List<int[]> executeStrategy() {
			return BombExplosionStrategy.Explode();
		}

		public Player(string connectionId, string color, int top, int left, int points, string name)
		{
			ConnectionId = connectionId;
			Color = color;
			Top = top;
			Left = left;
			Points = points;
			BombExplosionStrategy = new SimpleExplosionStrategy();
			Name = name;
            ExtraSpeed = false;

        }
        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
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
