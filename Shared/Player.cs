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
		public bool IsPaused { get; set; }

		public Player(string connectionId, string color, double top, double left, int points)
		{
			ConnectionId = connectionId;
			Color = color;
			Top = top;
			Left = left;
			Points = points;
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
