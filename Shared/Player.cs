using System.Drawing;

namespace BomberGopnik.Shared
{
    public class Player
    {
       // private IBombExplosion explosion;
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

       /* public Player(IBombExplosion exp)
        {
            explosion = exp;
        }
        public void SetStrategy(IBombExplosion bombExplosion)
        {
            explosion = bombExplosion;
        }
        public void Detonate(Bomb bomb)
        {
            explosion.Explode(bomb);
        }*/
    }

}
