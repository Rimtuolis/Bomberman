using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public class MediumBot : TemplateBot
    {
		public MediumBot() {
			Top = 50;
			Left = 50;
			Color = "#808080";
		}
        public override void SetMediator(CollisionMediator mediator)
        {
            this.mediator = mediator;
        }
        public override void CollideWithPlayer(Player player)
        {
            mediator.PlayerEnemyCollision(player, this);
        }
        public override TemplateBot Clone()
		{
			return (TemplateBot)this.MemberwiseClone();
		}

		public override void PerformAction(Arena arena, Player player)
		{
			Random random = new Random();
			bool legalMove = true;
			bool move = random.Next(2) == 0;

			if (move)
			{
				int direction = random.Next(4);

				int tempTop = Top;
				int tempLeft = Left;

				switch (direction)
				{
					case 0:
						tempTop -= 5;
						break;
					case 1:
						tempTop += 5;
						break;
					case 2:
						tempLeft -= 5;
						break;
					case 3:
						tempLeft += 5;
						break;
				}

				for (int i = 0; i < 10; i++)
				{
					for (int j = 0; j < 10; j++)
					{
						if (arena.grid[i, j] != null)
						{
							if (tempLeft >= arena.grid[i, j].GetStartX() && tempLeft <= arena.grid[i, j].GetStartX() + 6 && tempTop >= arena.grid[i, j].GetStartY() && tempTop <= arena.grid[i, j].GetStartY() + 6 ||
							tempLeft >= arena.grid[i, j].GetStartX() - 6 && tempLeft <= arena.grid[i, j].GetStartX() && tempTop >= arena.grid[i, j].GetStartY() - 6 && tempTop <= arena.grid[i, j].GetStartY())
							{
								legalMove = false;
							}
						}
					}
				}

				if (tempTop >= 6 && tempTop < 94 && tempLeft >= 9 && tempLeft < 94 && legalMove)
				{
					Top = tempTop;
					Left = tempLeft;
				}
			}
		}
	}
}
