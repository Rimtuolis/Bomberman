namespace BomberGopnik.Shared
{
	public class Player 
    {
		public string? ConnectionId { get; set; }
		public string? Color { get; set; }
		public int Top { get; set; }
		public int Left { get; set; }

		public Player(string connectionId, string color, int top, int left)
		{
			ConnectionId = connectionId;
			Color = color;
			Top = top;
			Left = left;
		}
    }
}
