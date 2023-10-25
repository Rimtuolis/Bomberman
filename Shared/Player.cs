namespace BomberGopnik.Shared
{
	public class Player 
    {
		public string? ConnectionId { get; set; }
		public string? Color { get; set; }
		public double Top { get; set; }
		public double Left { get; set; }

		public Player(string connectionId, string color, double top, double left)
		{
			ConnectionId = connectionId;
			Color = color;
			Top = top;
			Left = left;
		}
    }
}
