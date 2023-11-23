using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public abstract class Abstractbomb
    {
        protected IBombImplementor bombImplementor;
        public string? Id { get; set; }
        public bool Exploded { get; set; }
        public int Timer { get; set; }
        public int Radius { get; set; }
        public int StartX { get; set; }
        public int Length { get; set; }
        public int StartY { get; set; }
        public double Power { get; set; }
        public List<int[]> Path { get; set; }

        public bool viewed { get; set; }
        public Abstractbomb(IBombImplementor implementor,int timer, int radius, int startX, int length, int startY, string id, double power)
        {
            bombImplementor = implementor;
            viewed = false;
            Exploded = false;
            Id = id;
            Timer = timer;
            Radius = radius;
            StartX = startX;
            Length = length;
            StartY = startY;
            Power = power;
        }
        public Abstractbomb(IBombImplementor implementor)
        {
            bombImplementor = implementor;
			Exploded = false;
		}
        public Abstractbomb() { }
        public abstract void placeBomb(Player player);
    }
}
