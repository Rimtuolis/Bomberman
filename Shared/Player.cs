using System.Drawing;

namespace BomberGopnik.Shared
{
	public class Player
    {
		public string? ConnectionId { get; set; }
		public string? Color { get; set; }
		public double Top { get; set; }
		public double Left { get; set; }
		public int Points { get; set; }

		public Player(string connectionId, string color, double top, double left, int points)
		{
			this.ConnectionId = connectionId;
            this.Color = color;
            this.Top = top;
            this.Left = left;
            this.Points = points;
		}

    }

}
