using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
	public class HardBot : Bot
	{
		public HardBot() {
			Top = 50;
			Left = 50;
			Color = "#008000";
		}
        public override void SetMediator(CollisionMediator mediator)
        {
            this.mediator = mediator;
        }
        public override void CollideWithPlayer(Player player)
        {
            mediator.PlayerEnemyCollision(player, this);
        }
        public override Bot Clone()
		{
			return (Bot)this.MemberwiseClone();
		}
		public override void PerformAction(Arena arena, Player player)
		{
			int playerTop = player.Top;
			int playerLeft = player.Left;

			int distanceToPlayer = Math.Abs(Top - playerTop) + Math.Abs(Left - playerLeft);

			if (distanceToPlayer > 1)
			{
				MoveTowardsPlayer(arena, playerTop, playerLeft);
			}
			else
			{
				this.CollideWithPlayer(player);
			}
			/*else
			{
				PlaceBomb();
			}*/
		}

		private void MoveTowardsPlayer(Arena arena, int playerTop, int playerLeft)
		{
			

			if (Top < playerTop)
			{
				if (IsMoveValid(arena, Top + 5, Left))
				{
					Top += 5;
				}
			}
			else if (Top > playerTop)
			{
				// Move up
				if (IsMoveValid(arena, Top - 5, Left))
				{
					Top -= 5;
				}
			}
			else if (Left < playerLeft)
			{
				// Move right
				if (IsMoveValid(arena, Top, Left + 5))
				{
					Left += 5;
				}
			}
			else if (Left > playerLeft)
			{
				// Move left
				if (IsMoveValid(arena, Top, Left - 5))
				{
					Left-=5;
				}
			}
		}

		private bool IsMoveValid(Arena arena, int top, int left)
		{
			bool legalMove = true;

			for (int i = 0; i < 10; i++)
			{
				for (int j = 0; j < 10; j++)
				{
					if (arena.grid[i, j] != null)
					{
						if (left >= arena.grid[i, j].GetStartX() && left <= arena.grid[i, j].GetStartX() + 6 && top >= arena.grid[i, j].GetStartY() && top <= arena.grid[i, j].GetStartY() + 6 ||
						left >= arena.grid[i, j].GetStartX() - 6 && left <= arena.grid[i, j].GetStartX() && top >= arena.grid[i, j].GetStartY() - 6 && top <= arena.grid[i, j].GetStartY())
						{
							legalMove = false;
						}
					}
				}
			}
			return top >= 6 && top < 94 && left >= 6 && left < 94 && legalMove;
		}

	}
}
