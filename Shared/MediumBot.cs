using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public class MediumBot : Bot
    {
		public MediumBot() {
			Top = 50;
			Left = 50;
			Color = "#808080";
		}
		public override Bot Clone()
		{
			return (Bot)this.MemberwiseClone();
		}

		public override void PerformAction(GameLevel level, Player player)
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

				foreach (var brick in level.Bricks)
				{

					if (tempLeft >= brick.GetStartX() && tempLeft <= brick.GetStartX() + 6 && tempTop >= brick.GetStartY() && tempTop <= brick.GetStartY() + 6 ||
						tempLeft >= brick.GetStartX() - 6 && tempLeft <= brick.GetStartX() && tempTop >= brick.GetStartY() - 6 && tempTop <= brick.GetStartY())
					{
						legalMove = false;
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
