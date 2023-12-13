using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
	public abstract class TemplateBot
	{
		public int Top { get; set; }
		public int Left { get; set; }
		public string Color { get; set; }

		
		public CollisionMediator mediator;
        public abstract TemplateBot Clone();
        public abstract void PerformAction(Arena arena, Player player);
		public abstract void CollideWithPlayer(Player player);
		public abstract void SetMediator(CollisionMediator mediator);



    }
}
