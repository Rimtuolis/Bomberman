using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
	public abstract class Bot
	{
		public int Top { get; set; }
		public int Left { get; set; }
		public string Color { get; set; }
		
		public CollisionMediator mediator;

        public abstract void PerformAction(GameLevel level, Player player);
		public abstract Bot Clone();

		public abstract void CollideWithPlayer(Player player);
		public abstract void SetMediator(CollisionMediator mediator);



    }
}
