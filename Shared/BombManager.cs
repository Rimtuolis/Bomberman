using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BomberGopnik.Shared
{
    public class BombManager
    {
        private static readonly Dictionary<String, Bomb> bombs = new Dictionary<string, Bomb>();
      
        private static readonly object locker = new object();

        public static Dictionary<String, Bomb> Bombs => bombs;

        public static void Addbomb(Bomb bomb)
        {
            lock (locker) 
            {
                bombs[bomb.Id] = bomb;
            }
        }

      
    }
}
