namespace BomberGopnik.Shared
{
	public class Player : IPlayer
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

        public void Move()
        {
            throw new NotImplementedException();
        }
    }
}
