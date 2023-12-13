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
		public override void PerformAction(GameLevel level, Player player)
		{
			int playerTop = player.Top;
			int playerLeft = player.Left;

			int distanceToPlayer = Math.Abs(Top - playerTop) + Math.Abs(Left - playerLeft);

			if (distanceToPlayer > 1)
			{
				MoveTowardsPlayer(level, playerTop, playerLeft);
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

		private void MoveTowardsPlayer(GameLevel level, int playerTop, int playerLeft)
		{
			

			if (Top < playerTop)
			{
				if (IsMoveValid(level, Top + 5, Left))
				{
					Top += 5;
				}
			}
			else if (Top > playerTop)
			{
				// Move up
				if (IsMoveValid(level, Top - 5, Left))
				{
					Top -= 5;
				}
			}
			else if (Left < playerLeft)
			{
				// Move right
				if (IsMoveValid(level, Top, Left + 5))
				{
					Left += 5;
				}
			}
			else if (Left > playerLeft)
			{
				// Move left
				if (IsMoveValid(level, Top, Left - 5))
				{
					Left-=5;
				}
			}
		}

		private bool IsMoveValid(GameLevel level, int top, int left)
		{
			bool legalMove = true;

			foreach (var brick in level.Bricks)
			{

				if (left >= brick.GetStartX() && left <= brick.GetStartX() + 6 && top >= brick.GetStartY() && top <= brick.GetStartY() + 6 ||
					left >= brick.GetStartX() - 6 && left <= brick.GetStartX() && top >= brick.GetStartY() - 6 && top <= brick.GetStartY())
				{
					legalMove = false;
				}

			}
			return top >= 6 && top < 94 && left >= 6 && left < 94 && legalMove;
		}

	}
}
